using APL.Connections;
using APL.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace APL.Forms
{
    public partial class FormCheckOut : Form
    {
        Protocol pt = new Protocol();
        SocketTCP sckt;
        public FormCheckOut(string Token,SocketTCP sckt)
        {
            InitializeComponent();
            pt.Token = Token;
            this.sckt = sckt;

            
            


        }

        private float totale;
        private string cvv;
        private string numeroCarta;
        private string meseScadenza;
        private string annoScadenza;
        private string indirizzoFatturazione;

        private List<List<string>> CheckOut;
        private List<string> listaPreassemblati;
        private List<string> listaBuildGuidata;
        private List<string> listaBuildSolo;

        public ListView getListView() { return listViewCheckOut; }

        public void calcolaTotale()
        {
            string modello;
            string prezzo;
            string tipo;

            float totPreassemblato=0;
            float totBuildSolo=0;
            float totBuildGuidata=0;

            CheckOut = new List<List<string>>();

            listaPreassemblati=new List<string>();
            listaBuildGuidata=new List<string>();
           listaBuildSolo=new List<string>();

            foreach (ListViewItem item in listViewCheckOut.Items)
            {
                 modello = item.SubItems[0].Text.ToString();
                 prezzo = item.SubItems[2].Text.ToString();
                 tipo = item.SubItems[5].Text.ToString();

                if (tipo == "preassemblato")
                {
                    totPreassemblato += float.Parse(prezzo);
                    listaPreassemblati.Add(modello);
                }

                if(tipo == "Build Guidata")
                {
                    totBuildGuidata += float.Parse(prezzo);
                    listaBuildGuidata.Add(modello);
                }

                if (tipo == "Build Solo")
                {
                    totBuildSolo += float.Parse(prezzo);
                    listaBuildSolo.Add(modello);
                }
            }

            float tot =  (totPreassemblato + totBuildGuidata + totBuildSolo);
            // oltre le due cifre decimali, tronca il valore del totale
            totale = (float)(Math.Truncate((double)tot * 100.0) / 100.0); 
            
            //passo all'interfaccia grafica il totale
            labelTotale.Text = "Costi dei Preassemblati: " + totPreassemblato + "\n" +
                        "Costi Build Solo: " + totBuildSolo + "\n" +
                        "Costi Build Guidata: " + totBuildGuidata + "\n" +
                        "Totale: "+totale;

            //aggiungo le 3 liste ad una lista di liste
            if (listaPreassemblati.Count > 0)
            {
                CheckOut.Add(listaPreassemblati);
            }
            

            if (listaBuildGuidata.Count > 0)
            {
                CheckOut.Add(listaBuildGuidata);
            }

            if (listaBuildSolo.Count > 0)
            {
                CheckOut.Add(listaBuildSolo);
            }

        }


        private async void buttonConfermaCheckout_Click(object sender, EventArgs e)
        {
            meseScadenza = textBoxMese.Text;
            annoScadenza = textBoxAnno.Text;
            cvv = textBoxCVV.Text;
            indirizzoFatturazione = textBoxIndirizzoFatturazione.Text;
            numeroCarta = textBoxNumeroCarta.Text;

            if (indirizzoFatturazione != string.Empty && meseScadenza != string.Empty && annoScadenza != string.Empty
                && cvv != string.Empty && numeroCarta != string.Empty )
            {

                //-----comunicazione con il server, che a sua volta comunica con il database--------------------------------------
                InfoPayment info = new InfoPayment();
                info.CreditCard = new CreditCard();
                info.CreditCard.CVV = int.Parse(cvv);
                info.CreditCard.Month = int.Parse(meseScadenza);
                info.CreditCard.Year = int.Parse(annoScadenza);
                info.CreditCard.Number = long.Parse(numeroCarta);
                info.IndirizzoFatturazione = indirizzoFatturazione;
                info.Email = String.Empty;
                string JsonInfop = JsonConvert.SerializeObject(info);
                string Json = System.Text.Json.JsonSerializer.Serialize(
                    new
                    {
                        id_token = pt.Token,
                        acquisto = new
                        {
                            Lista = CheckOut,
                            Prezzo = totale
                        }
                    }
                    );
                pt.SetProtocolID("CheckOut");pt.Data = Json;
                sckt.GetMutex().WaitOne();
                sckt.send(pt);
                string okmsg = await sckt.receive();
                sckt.sendSingleMsg(JsonInfop+"\n");
                string response = await sckt.receive();
                sckt.GetMutex().ReleaseMutex();
                if (response.Contains("done")) {
                    Debug.WriteLine(response);
                }
                
            }
            else
            {
                MessageBox.Show("Riempire tutti i campi",
                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void FormCheckOut_Load(object sender, EventArgs e)
        {
            calcolaTotale();

            InfoPayment infoPayment;
            pt.SetProtocolID("getInfoPayment"); pt.Data = String.Empty;
            Debug.WriteLine("token: " + pt.Token);
            sckt.GetMutex().WaitOne();
            sckt.send(pt);
            string infop = await sckt.receive();
            sckt.GetMutex().ReleaseMutex();

            if (!infop.Contains("notFound"))
            {
                infoPayment = JsonConvert.DeserializeObject<InfoPayment>(infop);
                textBoxIndirizzoFatturazione.Text = infoPayment.IndirizzoFatturazione;
                textBoxMese.Text = Convert.ToString(infoPayment.CreditCard.Month);
                textBoxAnno.Text = Convert.ToString(infoPayment.CreditCard.Year);
                textBoxCVV.Text = Convert.ToString(infoPayment.CreditCard.CVV);
                textBoxNumeroCarta.Text = Convert.ToString(infoPayment.CreditCard.Number);
            }
        }
    } 
}
