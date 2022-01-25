using APL.Connections;
using APL.Data;
using APL.Properties;
using APL.UserControls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using ListViewItem = System.Windows.Forms.ListViewItem;
using APL.Cache;

namespace APL.Forms
{
    public partial class FormHome : Form
    {
        Protocol pt = new Protocol();
        FormLogin_Register parent;
        
        FormCarrello carrelloForm;
        FormPleaseWait pleaseWait;
        FormCatalogo catalogoForm;
        FormCheckOut checkoutForm;
        public FormHome(FormLogin_Register f_start)
        {
            InitializeComponent();
            parent = f_start;
            comboBox1.Text = "Build Guidata";
            checkoutForm = new FormCheckOut(this);
            carrelloForm = new FormCarrello(checkoutForm);
            catalogoForm = new FormCatalogo();

            pleaseWait = new FormPleaseWait();
            
        }

        protected override void OnClosed(EventArgs e)
        {
            parent.Visible = true;
            carrelloForm.EnableCloseEvent();
            catalogoForm.EnableCloseEvent();
            checkoutForm.EnableCloseEvent();
            carrelloForm.Close();
            catalogoForm.Close();
            checkoutForm.Close();
            base.OnClosed(e);
        }


        #region toolStripMenu---------------------------------------------------------
        private void modificaProfiloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModificaProfilo mdp = new FormModificaProfilo(pt);
            mdp.Show();
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parent.Visible = true;
            this.Close();
        }
        private void cronologiaOrdiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAcquistiPassati acquistiPassati = new FormAcquistiPassati();
            acquistiPassati.Show();
        }
        #endregion

        
        #region PcPreassemblati-------------------------------------------------------
        private void FormHome_Load(object sender, EventArgs e){recuperaPreassemblati();}
        private void Home(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            listView.Items.Clear();
            listView.Visible=false ;
            this.restringiForm2();

            recuperaPreassemblati();
        }
        private void recuperaPreassemblati()
        {
            pt.SetProtocolID("home"); pt.Data = String.Empty;

            SocketTCP.GetMutex().WaitOne();
            SocketTCP.Send(pt.ToString());
            string responseData = String.Empty;
            responseData = SocketTCP.Receive();
            SocketTCP.GetMutex().ReleaseMutex();

            int dim = 3;
            PcPreassemblato[] ricevuto = new PcPreassemblato[dim];
            ricevuto = JsonConvert.DeserializeObject<PcPreassemblato[]>(responseData);
            populateItemsPcPreassemblato(ricevuto, dim);
        }
        private void populateItemsPcPreassemblato(PcPreassemblato[] pre, int index)
        {
            ListItem[] listItems = new ListItem[index];
            string[] vet = { "cpu", "schedaVideo", "memoria", "ram" };

            for (int i = 0; i < listItems.Length; i++)
            {
                Debug.Write("pre:" + pre[i]);
                listItems[i] = new ListItem(flowLayoutPanel2, this, flowLayoutPanel1, carrelloForm.getListViewC());
                listItems[i].pre = pre[i];
                listItems[i].Icon = Resources.preassemblato;
                listItems[i].IconBackground = Color.SteelBlue;
                listItems[i].NomeModello = pre[i].Nome;
                listItems[i].Prezzo = pre[i].Prezzo;
                listItems[i].setTitle();

                string message = "";
                //8 come il numero dei componenti
                for (int j = 0; j < 8; j++)
                {
                    if (Array.Exists(vet, x => x == pre[i].Componenti[j].Categoria))
                    {
                        message += pre[i].Componenti[j].Categoria + ": " + pre[i].Componenti[j].Marca + " " + pre[i].Componenti[j].Modello;

                        if (pre[i].Componenti[j].Capienza > 0)
                         message += " " + pre[i].Componenti[j].Capienza + " GB";
                        
                        message += "\n";
                    }
                }
                listItems[i].Message = message;

                //aggiunge al flow label
                if (flowLayoutPanel1.Controls.Count < 0)
                    flowLayoutPanel1.Controls.Clear(); 
                else
                    flowLayoutPanel1.Controls.Add(listItems[i]); 
            }
        }
        #endregion


        #region MyBuild--------------------------------------------------------------
        private void buttonMyBuild_Click(object sender, EventArgs e)
        {
            //pulisco le tendine
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            listView.Items.Clear();
            listView.Visible = false;
            this.restringiForm2();

            if (comboBox1.Text == "Build Guidata")
            {
                populateItemsBuildGuidata();
            }
            else
            {
                
                populateItemsBuilSolo();
            }
        }
        
        private void populateItemsBuildGuidata()
        {
            Profiles[] profiles = new Profiles[5];

            for (int i = 0; i < profiles.Length; i++)
            {
                profiles[i] = new Profiles(flowLayoutPanel1,listView,carrelloForm.getListViewC());

                switch (i)
                {
                    case 0:
                        profiles[i].Title = "Basic";
                        profiles[i].Price = "entro i 560€";
                        profiles[i].Message = "\n" + "► Socket AM4 " + "\n" +
                                             "► Scheda grafica dedicata fascia bassa" + "\n" +
                                             "► RAM massimo 8GB DDR3 " + "\n" +
                                             "► HDD fino ad 1000GB SATA" + "\n" +
                                             "► Bassi consumi, alimentatore da massimo 600W " + "\n" +
                                             "► Ideale per navigare in Internet, guardare film e ascoltare musica";
                        break;

                    case 1:
                        profiles[i].Title = "Advanced";
                        profiles[i].Price = "entro i 1200€";
                        profiles[i].Message = "\n" + "► Socket AM4" + "\n" +
                                             "► Scheda grafica di fascia media" + "\n" +
                                             "► RAM massimo 16GB DDR4 " + "\n" +
                                             "► SSD massimo 1000GB SATA" + "\n" +
                                             "► Consumi medi, massimo 750W " + "\n" +
                                             "► Consigliato per il lavoro d'ufficio e per giocare ai videogiochi casualmente";
                        break;

                    case 2:
                        profiles[i].Title = "Gamer";
                        profiles[i].Price = "entro i 1600€";
                        profiles[i].Message = "\n" + "► Processore Intel" + "\n" +
                                             "► Scheda grafica di fascia medio-alta" + "\n" +
                                             "► RAM massimo 16GB DDR4" + "\n" +
                                             "► SSD massimo 1250GB " + "\n" +
                                             "► Consumi Alti, massimo 750W " + "\n" +
                                             "► Consigliato per appassionati di videogiochi";
                        break;

                    case 3:
                        profiles[i].Title = "Pro";
                        profiles[i].Price = "entro i 3200€";
                        profiles[i].Message = "\n" + "► Socket TR4" + "\n" +
                                             "► Scheda video di fascia alta" + "\n" +
                                             "► RAM massimo 32GB DDR4 " + "\n" +
                                             "► SSD massimo 2000GB" + "\n" +
                                             "► Consumi Alti, massimo 1000W " + "\n" +
                                             "► Consigliato per lavori di modellazione 3d";
                        break;

                    case 4:
                        profiles[i].Title = "Ultra";
                        profiles[i].Price = "entro i 4800€";
                        profiles[i].Message = "\n" + "►  Intel " + "\n" +
                                             "► Scheda video di fascia alta" + "\n" +
                                             "► RAM massimo 64GB " + "\n" +
                                             "► SSD massimo 2000GB" + "\n" +
                                             "► Consumi Alti,massimo 1250W " + "\n" +
                                             "► Consigliato per lavori di modellazione 3d";
                        break;
                }

                //aggiunge al flow label
                if (flowLayoutPanel1.Controls.Count < 0)
                    flowLayoutPanel1.Controls.Clear();
                else
                    flowLayoutPanel1.Controls.Add(profiles[i]);
            }
        }

        private void populateItemsBuilSolo()
        {
            pleaseWait.Visible = true;
            if (recuperaListaDallaCache() == false)
                recuperaItemsBuildSoloDalServer();
            else
                Debug.WriteLine("lista di liste componenti recuperate dalla cache///////////////////////");
        }
        private void recuperaItemsBuildSoloDalServer()
        {
            pt.SetProtocolID("buildSolo");
            Dictionary<string, int> order = new Dictionary<string, int>{
                { "schedaMadre",0 },{ "cpu",1 },{"ram",2},{"schedaVideo",3},
                {"alimentatore",4},{"casepc",5},{"memoria",6},{"dissipatore",7},};

            SocketTCP.GetMutex().WaitOne();
                SocketTCP.Send(pt.ToString());
                List<List<Componente>> myList = new List<List<Componente>>();
                for (int i = 0; i < 8; i++)
                {
                    string nElements = SocketTCP.Receive();
                    int n = int.Parse(nElements);
                    string response = String.Empty;
                    response = SocketTCP.Receive();
                    Componente[] pezzo = new Componente[n];
                    pezzo = JsonConvert.DeserializeObject<Componente[]>(response);
                    List<Componente> singleComponent = pezzo.ToList();
                    myList.Add(singleComponent);

                    aggiungiListaInCache(singleComponent);
                }
            SocketTCP.GetMutex().ReleaseMutex();

            Debug.WriteLine(myList.Count());
            stampaComponentsSolo(myList);
        }
        private void stampaComponentsSolo(List<List<Componente>> myList)
        {
            ComponentsSolo[] componentsSolo;
            int index = 0;
            componentsSolo = new ComponentsSolo[myList.Count];

            foreach (List<Componente> subList in myList)
            {
                componentsSolo[index] = new ComponentsSolo(carrelloForm);
                int i = 0;

                componentsSolo[index].impostaCategoria(subList[0].Categoria);
                foreach (Componente item in subList)
                {
                    ListViewItem lvitem = new ListViewItem("" + item.Modello + "");
                    lvitem.SubItems.Add("" + item.Marca + "");
                    lvitem.SubItems.Add("" + item.Prezzo + "");
                    lvitem.SubItems.Add("" + item.Capienza + "");
                    lvitem.SubItems.Add("" + item.Categoria + "");

                    componentsSolo[index].addListView(lvitem);
                    i++;
                }
                Debug.WriteLine("" + subList[0].Categoria + " numero: " + i);
                index++;

                //aggiunge al flow label
                if (flowLayoutPanel1.Controls.Count < 0)
                    flowLayoutPanel1.Controls.Clear();
                else
                    flowLayoutPanel1.Controls.Add(componentsSolo[index - 1]);

            }
        }
        #endregion


        #region Cache---------------------------------------------------------------
        private void aggiungiListaInCache(List<Componente> lista)
        {
            CachingProviderBase.Instance.AddItem(lista[0].Categoria + "BuildSolo", lista);
            Debug.WriteLine("lista " + lista[0].Categoria + " inserita in cache: " + DateTime.Now + " ///////////////");
        }
        private bool recuperaListaDallaCache()
        {
            List<Componente> schedaMadreMessage = CachingProviderBase.Instance.GetItem("schedaMadreBuildSolo");
            List<Componente> cpuMessage = CachingProviderBase.Instance.GetItem("cpuBuildSolo");
            List<Componente> ramMessage = CachingProviderBase.Instance.GetItem("ramBuildSolo");
            List<Componente> schedaVideoMessage = CachingProviderBase.Instance.GetItem("schedaVideoBuildSolo");
            List<Componente> alimentatoreMessage = CachingProviderBase.Instance.GetItem("alimentatoreBuildSolo");
            List<Componente> casepcMessage = CachingProviderBase.Instance.GetItem("casepcBuildSolo");
            List<Componente> memoriaMessage = CachingProviderBase.Instance.GetItem("memoriaBuildSolo");
            List<Componente> dissipatoreMessage = CachingProviderBase.Instance.GetItem("dissipatoreBuildSolo");

            if (schedaMadreMessage == null || cpuMessage == null || ramMessage == null ||
                schedaVideoMessage == null || alimentatoreMessage == null || casepcMessage == null ||
                memoriaMessage == null || dissipatoreMessage == null)
            { return false; }

            List<List<Componente>> lista = new List<List<Componente>>();
            lista.Add(schedaMadreMessage); lista.Add(cpuMessage); lista.Add(ramMessage);
            lista.Add(schedaVideoMessage); lista.Add(alimentatoreMessage); lista.Add(casepcMessage);
            lista.Add(memoriaMessage); lista.Add(dissipatoreMessage);

            stampaComponentsSolo(lista);
            return true;
        }
        #endregion


        #region Altro----------------------------------------------------------------
        private void buttonCarrello_Click(object sender, EventArgs e) { carrelloForm.Show(); }
        private void Catalogo_Click(object sender, EventArgs e){catalogoForm.Show();}

        public void allargaForm2()
        { if (this.ClientSize.Width != 1293 && this.ClientSize.Height != 778)
            {
                this.ClientSize = new System.Drawing.Size(1238, 972);
                flowLayoutPanel2.Visible = true;
            }
        }
        public void restringiForm2()
        { if (this.ClientSize.Width != 821 && this.ClientSize.Height != 778)
            {
                this.ClientSize = new System.Drawing.Size(700, 972);
                flowLayoutPanel2.Visible = false;
            }
        }
        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {   //quando BuildSolo finisce di caricare i componenti
            //pleaseWait diventa invisibile
            if (flowLayoutPanel1.Controls.Count >= 8)
            {
                pleaseWait.Visible = false;
            }
        }

        public void svuotaBuildSolo()
        {
            if (flowLayoutPanel1.Controls.ContainsKey("ComponentsSolo"))
                flowLayoutPanel1.Controls.Clear();
        }
        public void svuotaCarrello()
        {//usato quando all'interno del carrelo sono presenti componenti eliminati dal database
            carrelloForm.svuotaCarrello();
            carrelloForm.Visible = false;
        }
        #endregion


    }
}
