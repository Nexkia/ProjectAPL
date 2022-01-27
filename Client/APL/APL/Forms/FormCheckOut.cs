using APL.Cache;
using APL.Connections;
using APL.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace APL.Forms
{
    public partial class FormCheckOut : Form
    {
        private Protocol pt;
        private bool disableCloseEvent;
        private FormHome vecchiaHome;
        public FormCheckOut(FormHome vecchiaHome)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormHome_FormClosing);
            disableCloseEvent = true;
            this.vecchiaHome = vecchiaHome;
            pt = new Protocol();
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

        #region Chiusura--------------------------------------------------------
        public void EnableCloseEvent() { this.disableCloseEvent = false; }
        void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (disableCloseEvent == true)
            {

                //impedisce alla finestra di chiudersi
                e.Cancel = true;

                //rende la finestra invisibile
                this.Visible = false;

                //resetto i parametri dentro il checkout
                listViewCheckOut.Items.Clear();


            }
            else { e.Cancel = false; } //permette alla finestra di chiudersi
        }
        #endregion


        #region riempi Checkout-------------------------------------------------------
        private void FormCheckOut_Load(object sender, EventArgs e)
        {
            calcolaTotale();
            InfoPayment? infoPayment;
            pt.SetProtocolID("getInfoPayment"); pt.Data = String.Empty;
            /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER
            SocketTCP.Wait();
            SocketTCP.Send(pt.ToString());
            string infop = SocketTCP.Receive();
            SocketTCP.Release();
            /// FINE SCAMBIO DI MESSAGGI CON IL SERVER


            if (!infop.Contains("notFound"))
            {
                try
                {
                    infoPayment = JsonConvert.DeserializeObject<InfoPayment>(infop);
                    if (infoPayment != null)
                    {
                        textBoxIndirizzoFatturazione.Text = infoPayment.IndirizzoFatturazione;
                        textBoxMese.Text = Convert.ToString(infoPayment.CreditCard.Month);
                        textBoxAnno.Text = Convert.ToString(infoPayment.CreditCard.Year);
                        textBoxCVV.Text = Convert.ToString(infoPayment.CreditCard.CVV);
                        textBoxNumeroCarta.Text = Convert.ToString(infoPayment.CreditCard.Number);
                    }
                }
                catch (JsonException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
        public void calcolaTotale()
        {
            string modello;
            string prezzo;
            string tipo;

            float totPreassemblato = 0;
            float totBuildSolo = 0;
            float totBuildGuidata = 0;

            CheckOut = new List<List<string>>();

            listaPreassemblati = new List<string>();
            listaBuildGuidata = new List<string>();
            listaBuildSolo = new List<string>();

            foreach (ListViewItem item in listViewCheckOut.Items)
            {
                modello = item.SubItems[0].Text.ToString();
                prezzo = item.SubItems[2].Text.ToString();
                tipo = item.SubItems[5].Text.ToString();

                if (tipo == "preassemblato")
                {
                    totPreassemblato += float.Parse(prezzo);
                    totPreassemblato = (float)(Math.Truncate((double)totPreassemblato * 100.0) / 100.0);
                    listaPreassemblati.Add(modello);
                }

                if (tipo == "Build Guidata")
                {
                    totBuildGuidata += float.Parse(prezzo);
                    totBuildGuidata = (float)(Math.Truncate((double)totBuildGuidata * 100.0) / 100.0);
                    listaBuildGuidata.Add(modello);
                }

                if (tipo == "Build Solo")
                {
                    totBuildSolo += float.Parse(prezzo);
                    totBuildSolo = (float)(Math.Truncate((double)totBuildSolo * 100.0) / 100.0);
                    listaBuildSolo.Add(modello);
                }
            }

            float tot = (totPreassemblato + totBuildGuidata + totBuildSolo);
            // oltre le due cifre decimali, tronca il valore del totale
            totale = (float)(Math.Truncate((double)tot * 100.0) / 100.0);

            //passo all'interfaccia grafica il totale
            labelTotale.Text = "Costi dei Preassemblati: " + totPreassemblato + "\n" +
                        "Costi Build Solo: " + totBuildSolo + "\n" +
                        "Costi Build Guidata: " + totBuildGuidata + "\n" +
                        "Totale: " + totale;

            //aggiungo le 3 liste ad una lista di liste
            if (listaPreassemblati.Count > 0)
                CheckOut.Add(listaPreassemblati);
            if (listaBuildGuidata.Count > 0)
                CheckOut.Add(listaBuildGuidata);
            if (listaBuildSolo.Count > 0)
                CheckOut.Add(listaBuildSolo);
        }
        #endregion


        #region Conferma CheckOut--------------------------------------------------------
        private void buttonConfermaCheckout_Click(object sender, EventArgs e)
        {
            meseScadenza = textBoxMese.Text;
            annoScadenza = textBoxAnno.Text;
            cvv = textBoxCVV.Text;
            indirizzoFatturazione = textBoxIndirizzoFatturazione.Text;
            numeroCarta = textBoxNumeroCarta.Text;

            if (indirizzoFatturazione != string.Empty && meseScadenza != string.Empty && annoScadenza != string.Empty
                && cvv != string.Empty && numeroCarta != string.Empty)
            {
                //-----comunicazione con il server, che a sua volta comunica con il database--------------------------------------
                InfoPayment info = new()
                {
                    CreditCard = new CreditCard()
                    {
                        CVV = int.Parse(cvv),
                        Month = int.Parse(meseScadenza),
                        Year = int.Parse(annoScadenza),
                        Number = long.Parse(numeroCarta)
                    },
                    IndirizzoFatturazione = indirizzoFatturazione,
                    Email = String.Empty
                };
                string JsonInfop = JsonConvert.SerializeObject(info);
                string Json = System.Text.Json.JsonSerializer.Serialize(new
                {
                    acquisto = new
                    {
                        Lista = CheckOut,
                        Prezzo = totale,
                        Data = DateTime.Now
                    }
                });
                pt.SetProtocolID("CheckOut"); pt.Data = Json;
                /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER
                SocketTCP.Wait();
                SocketTCP.Send(pt.ToString());
                SocketTCP.Send(JsonInfop + "\n");
                string response = SocketTCP.Receive();
                SocketTCP.Release();
                /// FINE SCAMBIO DI MESSAGGI CON IL SERVER
                if (response.Contains("Un elemento non presente"))
                {
                    MessageBox.Show("Checkout non confermato",
                      "Conferma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resetCache();
                    //resetto i parametri dentro il checkout
                    listViewCheckOut.Items.Clear();
                    this.Visible = false;
                    //resetto i parametri dentro il carrello
                    vecchiaHome.svuotaCarrello();
                    //resetto i parametri dentro a BuildSolo (solo se l'utente lo tiene aperto)
                    vecchiaHome.ricaricaBuildSolo();
                }
                else
                {
                    Debug.WriteLine(response);
                    MessageBox.Show("CheckOut confermato",
                    "Conferma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Riempire tutti i campi",
                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void resetCache()
        {
            List<Componente> schedaMadreMessage = CachingProviderBase.Instance.GetItem("schedaMadreBuildSolo");
            List<Componente> cpuMessage = CachingProviderBase.Instance.GetItem("cpuBuildSolo");
            List<Componente> ramMessage = CachingProviderBase.Instance.GetItem("ramBuildSolo");
            List<Componente> schedaVideoMessage = CachingProviderBase.Instance.GetItem("schedaVideoBuildSolo");
            List<Componente> alimentatoreMessage = CachingProviderBase.Instance.GetItem("alimentatoreBuildSolo");
            List<Componente> casepcMessage = CachingProviderBase.Instance.GetItem("casepcBuildSolo");
            List<Componente> memoriaMessage = CachingProviderBase.Instance.GetItem("memoriaBuildSolo");
            List<Componente> dissipatoreMessage = CachingProviderBase.Instance.GetItem("dissipatoreBuildSolo");

            if (schedaMadreMessage != null)
                CachingProviderBase.Instance.RemoveItems("schedaMadreBuildSolo");
            if (cpuMessage != null)
                CachingProviderBase.Instance.RemoveItems("cpuBuildSolo");
            if (ramMessage != null)
                CachingProviderBase.Instance.RemoveItems("ramBuildSolo");
            if (schedaVideoMessage != null)
                CachingProviderBase.Instance.RemoveItems("schedaVideoBuildSolo");
            if (alimentatoreMessage != null)
                CachingProviderBase.Instance.RemoveItems("alimentatoreBuildSolo");
            if (casepcMessage != null)
                CachingProviderBase.Instance.RemoveItems("casepcBuildSolo");
            if (memoriaMessage != null)
                CachingProviderBase.Instance.RemoveItems("memoriaBuildSolo");
            if (dissipatoreMessage != null)
                CachingProviderBase.Instance.RemoveItems("dissipatoreBuildSolo");

        }
        #endregion


        #region Controlli TextBox--------------------------------------------------------
        private void textBoxNumeroCarta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Fa si che all'interno delle textBox si possano inserire solo numeri
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxMese_TextChanged(object sender, EventArgs e)
        {
            //impediamo di inserire un mese non valido
            if (textBoxMese.Text != string.Empty)
            {
                if (int.Parse(textBoxMese.Text) > 12)
                    textBoxMese.Text = "12";
                if (int.Parse(textBoxMese.Text) == 0)
                    textBoxMese.Text = "1";
            }
        }
        #endregion
    }
}
