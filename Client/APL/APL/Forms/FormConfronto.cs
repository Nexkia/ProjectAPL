using APL.Connections;
using APL.Data;
using APL.Data.Detail;
using APL.UserControls;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace APL.Forms
{
    public partial class FormConfronto : Form
    {
        private Protocol pt;
        private string categoriaOriginale;
        private string[] modelli, prezzi, capienze;
        public FormConfronto(string[] modelli, string[] prezzi, string[] capienze, string categoria)
        {
            InitializeComponent();
            pt = new Protocol();
            pt.SetProtocolID("confronto");
            this.modelli = modelli;
            this.prezzi = prezzi;
            this.capienze = capienze;
            this.categoriaOriginale = categoria;
        }

        private void Confronto_Load(object sender, EventArgs e1)
        {
            /*
             Gli oggetti da cofrontare hanno tutti la stessa categoria
             Creo una lista a partire dal tipo di componente da confrontare
             */
            ConstructorDetail factoryDetail = new();
            IDetails? componenteDetail = factoryDetail.GetDetails(categoriaOriginale);
            Type categoria = componenteDetail.GetType();
            Type categoriaTypeList = typeof(List<>).MakeGenericType(categoria);
            IList? MyList = Activator.CreateInstance(categoriaTypeList) as IList;
            // Invio un messaggi composto dai modelli da confrontare semparati da un carattere di separazione
            for (int i = 0; i < modelli.Length; i++)
            {
                pt.Data += modelli[i] + "#";
            }
            /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER
            SocketTCP.Wait();
            SocketTCP.Send(pt.ToString());

            for (int i = 0; i < modelli.Length; i++)
            {
                string response = SocketTCP.Receive();
                try
                {
                    componenteDetail = JsonConvert.DeserializeObject(response, categoria) as IDetails;
                    if (componenteDetail != null && MyList != null)
                    {
                        MyList.Add(componenteDetail);
                        Debug.WriteLine("getmodello: " + componenteDetail.Modello);
                    }
                }
                catch (JsonException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            SocketTCP.Release();
            /// FINE SCAMBIO DI MESSAGGI CON IL SERVER
            if (MyList != null)
                ConfrontaParametri(MyList, categoriaOriginale, capienze);
        }

        private void ConfrontaParametri(IList componenti, string categoria, string[] capienze)
        {
            schedaConfronto sc = new schedaConfronto();

            switch (categoria)
            {
                case "cpu":
                    sc.labelCategoriaName(categoria);
                    MostraCpu(componenti, sc);

                    break;

                case "schedaVideo":
                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                    sc.label6Invisible(); sc.label7Invisible();
                    sc.panel7Invisible();
                    sc.labelMod1Det4Invisible(); sc.labelMod1Det5Invisible();
                    sc.labelMod2Det4Invisible(); sc.labelMod2Det5Invisible();
                    sc.labelMod3Det4Invisible(); sc.labelMod3Det5Invisible();

                    MostraSchedaVideo(componenti, sc);
                    break;

                case "schedaMadre":
                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                    sc.label7Invisible();
                    sc.labelMod1Det5Invisible();
                    sc.labelMod2Det5Invisible();
                    sc.labelMod3Det5Invisible();

                    MostraSchedaMadre(componenti, sc);
                    break;

                case "ram":

                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                    sc.label7Invisible();
                    sc.labelMod1Det5Invisible();
                    sc.labelMod2Det5Invisible();
                    sc.labelMod3Det5Invisible();

                    MostraRam(componenti, sc);
                    break;

                case "alimentatore":

                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                    sc.label5Invisible(); sc.label6Invisible(); sc.label7Invisible();
                    sc.panel6Invisible(); sc.panel7Invisible();
                    sc.labelMod1Det3Invisible(); sc.labelMod1Det4Invisible(); sc.labelMod1Det5Invisible();
                    sc.labelMod2Det3Invisible(); sc.labelMod2Det4Invisible(); sc.labelMod2Det5Invisible();
                    sc.labelMod3Det3Invisible(); sc.labelMod3Det4Invisible(); sc.labelMod3Det5Invisible();

                    MostraAlimentatore(componenti, sc);
                    break;

                case "dissipatore":
                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                    sc.label5Invisible(); sc.label6Invisible(); sc.label7Invisible();
                    sc.panel6Invisible(); sc.panel7Invisible();
                    sc.labelMod1Det3Invisible(); sc.labelMod1Det4Invisible(); sc.labelMod1Det5Invisible();
                    sc.labelMod2Det3Invisible(); sc.labelMod2Det4Invisible(); sc.labelMod2Det5Invisible();
                    sc.labelMod3Det3Invisible(); sc.labelMod3Det4Invisible(); sc.labelMod3Det5Invisible();

                    MostraDissipatore(componenti, sc);
                    break;

                case "memoria":
                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                    sc.label6Invisible(); sc.label7Invisible();
                    sc.panel7Invisible();
                    sc.labelMod1Det4Invisible(); sc.labelMod1Det5Invisible();
                    sc.labelMod2Det4Invisible(); sc.labelMod2Det5Invisible();
                    sc.labelMod3Det4Invisible(); sc.labelMod3Det5Invisible();

                    MostraMemoria(componenti, sc);
                    break;

                case "casepc":
                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                    sc.label5Invisible(); sc.label6Invisible(); sc.label7Invisible();
                    sc.panel6Invisible(); sc.panel7Invisible();
                    sc.labelMod1Det3Invisible(); sc.labelMod1Det4Invisible(); sc.labelMod1Det5Invisible();
                    sc.labelMod2Det3Invisible(); sc.labelMod2Det4Invisible(); sc.labelMod2Det5Invisible();
                    sc.labelMod3Det3Invisible(); sc.labelMod3Det4Invisible(); sc.labelMod3Det5Invisible();

                    MostraCasePc(componenti, sc);
                    break;

            }

            flowLayoutPanelConfronto.Controls.Add(sc);
        }

        #region Mostra Componenti-----------------------------------------------------------------------
        public void MostraCpu(IList componenti, schedaConfronto sc)
        {
            if (componenti.Count > 0)
            {
                IDetails componente1 = (IDetails)componenti[0];

                sc.labelModello1Name(componente1.Modello);
                sc.labelValutazione1Name(Convert.ToString(componente1.Valutazione));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                string[] a = componente1.GetDetail();
                sc.label4Name("frequenza");
                sc.labelMod1Det2Name(Convert.ToString(a[0]));

                sc.label5Name("socket");
                sc.labelMod1Det3Name(Convert.ToString(a[1]));

                sc.label6Name("Core");
                sc.labelMod1Det4Name(Convert.ToString(a[2]));

                sc.label7Name("Thread");
                sc.labelMod1Det5Name(Convert.ToString(a[3]));


                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda colonna
                    sc.panelNascosto2VisibileOFF();

                    IDetails componente2 = (IDetails)componenti[1];
                    Debug.WriteLine(componente2.Modello);

                    sc.labelModello2Name(componente2.Modello);
                    sc.labelValutazione2Name(Convert.ToString(componente2.Valutazione));

                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //frequenza
                    string[] b = componente2.GetDetail();
                    sc.labelMod2Det2Name(Convert.ToString(b[0]));

                    //socket
                    sc.labelMod2Det3Name(Convert.ToString(b[1]));

                    //Core
                    sc.labelMod2Det4Name(Convert.ToString(b[2]));

                    //Thread
                    sc.labelMod2Det5Name(Convert.ToString(b[3]));

                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    ColoraLabelDet2(sc, a[0], b[0]);//frequenza
                                                    //socket
                    ColoraLabelDet4(sc, a[2], b[2]);//core
                    ColoraLabelDet5(sc, a[3], b[3]);//Thread


                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();


                        IDetails componente3 = (IDetails)componenti[2];
                        Debug.WriteLine(componente3.Modello);

                        sc.labelModello3Name(componente3.Modello);
                        sc.labelValutazione3Name(Convert.ToString(componente3.Valutazione));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //frequenza
                        string[] c = componente3.GetDetail();
                        sc.labelMod3Det2Name(Convert.ToString(c[0]));

                        //socket
                        sc.labelMod3Det3Name(Convert.ToString(c[1]));

                        //core
                        sc.labelMod3Det4Name(Convert.ToString(c[2]));

                        //Thread
                        sc.labelMod3Det5Name(Convert.ToString(c[3]));

                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione), Convert.ToString(componente3.Valutazione));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        ColoraLabelDet2(sc, a[0], b[0], c[0]);//frequenza
                                                              //socket
                        ColoraLabelDet4(sc, a[2], b[2], c[2]);//core
                        ColoraLabelDet5(sc, a[3], b[3], c[3]);//Thread
                    }
                }
            }
        }
        public void MostraSchedaVideo(IList componenti, schedaConfronto sc)
        {
            if (componenti.Count > 0)
            {
                IDetails componente1 = (IDetails)componenti[0];

                sc.labelModello1Name(componente1.Modello);
                sc.labelValutazione1Name(Convert.ToString(componente1.Valutazione));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                string[] a = componente1.GetDetail();
                sc.label4Name("Tdp");
                sc.labelMod1Det2Name(Convert.ToString(a[0]));

                sc.label5Name("Vram");
                sc.labelMod1Det3Name(Convert.ToString(a[1]));


                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda colonna
                    sc.panelNascosto2VisibileOFF();

                    IDetails componente2 = (IDetails)componenti[1];
                    Debug.WriteLine(componente2.Modello);

                    sc.labelModello2Name(componente2.Modello);
                    sc.labelValutazione2Name(Convert.ToString(componente2.Valutazione));

                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //Tdp
                    string[] b = componente2.GetDetail();
                    sc.labelMod2Det2Name(Convert.ToString(b[0]));

                    //Vram
                    sc.labelMod2Det3Name(Convert.ToString(b[1]));

                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    ColoraLabelDet2(sc, a[0], b[0]);//Tdp
                    ColoraLabelDet3(sc, a[1], b[1]);//Vram


                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();

                        IDetails componente3 = (IDetails)componenti[2];
                        Debug.WriteLine(componente3.Modello);
                        sc.labelModello3Name(componente3.Modello);
                        sc.labelValutazione3Name(Convert.ToString(componente3.Valutazione));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //tdp
                        string[] c = componente3.GetDetail();
                        sc.labelMod3Det2Name(Convert.ToString(c[0]));

                        //Vram
                        sc.labelMod3Det3Name(Convert.ToString(c[1]));

                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione), Convert.ToString(componente3.Valutazione));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        ColoraLabelDet2(sc, a[0], b[0], c[0]);//Tdp
                        ColoraLabelDet3(sc, a[1], b[1], c[1]);//Vram
                    }
                }
            }
        }
        public void MostraSchedaMadre(IList componenti, schedaConfronto sc)
        {
            if (componenti.Count > 0)
            {
                IDetails componente1 = (IDetails)componenti[0];

                sc.labelModello1Name(componente1.Modello);
                sc.labelValutazione1Name(Convert.ToString(componente1.Valutazione));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                sc.label4Name("Cpu Socket");
                string[] a = componente1.GetDetail();
                sc.labelMod1Det2Name(Convert.ToString(a[0]));

                sc.label5Name("Ram");
                sc.labelMod1Det3Name(a[1]);

                sc.label6Name("ChipSet");
                sc.labelMod1Det4Name(a[2]);


                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda colonna
                    sc.panelNascosto2VisibileOFF();

                    IDetails componente2 = (IDetails)componenti[1];
                    Debug.WriteLine(componente2.Modello);

                    sc.labelModello2Name(componente2.Modello);
                    sc.labelValutazione2Name(Convert.ToString(componente2.Valutazione));

                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //Cpu socket
                    string[] b = componente2.GetDetail();
                    sc.labelMod2Det2Name(b[0]);

                    //RAM
                    sc.labelMod2Det3Name(b[1]);

                    //ChipSet
                    sc.labelMod2Det4Name(b[2]);

                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    //cpu socket
                    //ram
                    //ChipSet


                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();

                        IDetails componente3 = (IDetails)componenti[2];
                        Debug.WriteLine(componente3.Modello);

                        sc.labelModello3Name(componente3.Modello);
                        sc.labelValutazione3Name(Convert.ToString(componente3.Valutazione));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //Cpu socket
                        string[] c = componente3.GetDetail();
                        sc.labelMod3Det2Name(c[0]);

                        //RAM
                        sc.labelMod3Det3Name(c[1]);

                        //ChipSet
                        sc.labelMod3Det4Name(c[2]);

                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione), Convert.ToString(componente3.Valutazione));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        //cpu socket
                        //ram
                        //Chipset

                    }
                }
            }
        }
        public void MostraRam(IList componenti, schedaConfronto sc)
        {
            if (componenti.Count > 0)
            {
                IDetails componente1 = (IDetails)componenti[0];

                sc.labelModello1Name(componente1.Modello);
                sc.labelValutazione1Name(Convert.ToString(componente1.Valutazione));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                string[] a = componente1.GetDetail();
                sc.label4Name("frequenza");
                sc.labelMod1Det2Name(Convert.ToString(a[0]));

                sc.label5Name("standard");
                sc.labelMod1Det3Name(Convert.ToString(a[1]));

                sc.label6Name("Capienza");
                sc.labelMod1Det4Name(capienze[0]);


                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda 
                    sc.panelNascosto2VisibileOFF();

                    IDetails componente2 = (IDetails)componenti[1];
                    Debug.WriteLine(componente2.Modello);

                    sc.labelModello2Name(componente2.Modello);
                    sc.labelValutazione2Name(Convert.ToString(componente2.Valutazione));

                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //frequenza
                    string[] b = componente2.GetDetail();
                    sc.labelMod2Det2Name(Convert.ToString(b[0]));

                    //standard
                    sc.labelMod2Det3Name(Convert.ToString(b[1]));

                    //Capienza
                    sc.labelMod2Det4Name(capienze[1]);

                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    ColoraLabelDet2(sc, a[0], b[0]);//frequenza
                                                    //standard
                    ColoraLabelDet4(sc, capienze[0], capienze[1]);//Capienza


                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();

                        IDetails componente3 = (IDetails)componenti[2];
                        Debug.WriteLine(componente3.Modello);

                        sc.labelModello3Name(componente3.Modello);
                        sc.labelValutazione3Name(Convert.ToString(componente3.Valutazione));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //frequenza
                        string[] c = componente3.GetDetail();
                        sc.labelMod3Det2Name(Convert.ToString(c[0]));

                        //standard
                        sc.labelMod3Det3Name(Convert.ToString(c[1]));

                        //Capienza
                        sc.labelMod3Det4Name(capienze[2]);

                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione), Convert.ToString(componente3.Valutazione));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        ColoraLabelDet2(sc, a[0], b[0], c[0]);//frequenza
                                                              //Standard
                        ColoraLabelDet4(sc, capienze[0], capienze[1], capienze[2]);//Capienza
                    }
                }
            }
        }
        public void MostraAlimentatore(IList componenti, schedaConfronto sc)
        {
            if (componenti.Count > 0)
            {
                IDetails componente1 = (IDetails)componenti[0];

                sc.labelModello1Name(componente1.Modello);
                sc.labelValutazione1Name(Convert.ToString(componente1.Valutazione));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                sc.label4Name("Watt");
                string[] a = componente1.GetDetail();
                sc.labelMod1Det2Name(Convert.ToString(a[0]));


                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda 
                    sc.panelNascosto2VisibileOFF();

                    IDetails componente2 = (IDetails)componenti[1];
                    Debug.WriteLine(componente2.Modello);

                    sc.labelModello2Name(componente2.Modello);
                    sc.labelValutazione2Name(Convert.ToString(componente2.Valutazione));

                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //watt
                    string[] b = componente2.GetDetail();
                    sc.labelMod2Det2Name(Convert.ToString(b[0]));

                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    ColoraLabelDet2(sc, a[0], b[0]);//watt


                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();

                        IDetails componente3 = (IDetails)componenti[2];
                        Debug.WriteLine(componente3.Modello);
                        sc.labelModello3Name(componente3.Modello);
                        sc.labelValutazione3Name(Convert.ToString(componente3.Valutazione));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //watt
                        string[] c = componente3.GetDetail();
                        sc.labelMod3Det2Name(Convert.ToString(c[0]));

                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione), Convert.ToString(componente3.Valutazione));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        ColoraLabelDet2(sc, a[0], b[0], c[0]);//watt
                    }
                }
            }
        }
        public void MostraDissipatore(IList componenti, schedaConfronto sc)
        {
            Debug.WriteLine("numero componenti: " + componenti.Count);

            if (componenti.Count > 0)
            {
                IDetails componente1 = (IDetails)componenti[0];

                sc.labelModello1Name(componente1.Modello);
                sc.labelValutazione1Name(Convert.ToString(componente1.Valutazione));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                sc.label4Name("Cpu Socket");
                string[] a = componente1.GetDetail();
                sc.labelMod1Det2Name(ConvertInUnaSolaStringa(a));


                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda 
                    sc.panelNascosto2VisibileOFF();

                    IDetails componente2 = (IDetails)componenti[1];
                    Debug.WriteLine(componente2.Modello);

                    sc.labelModello2Name(componente2.Modello);
                    sc.labelValutazione2Name(Convert.ToString(componente2.Valutazione));

                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //Cpu Socket
                    string[] b = componente2.GetDetail();
                    sc.labelMod2Det2Name(ConvertInUnaSolaStringa(b));

                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    //cpu socket


                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();

                        IDetails componente3 = (IDetails)componenti[2];
                        Debug.WriteLine(componente3.Modello);

                        sc.labelModello3Name(componente3.Modello);
                        sc.labelValutazione3Name(Convert.ToString(componente3.Valutazione));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //cpu socket
                        string[] c = componente3.GetDetail();
                        sc.labelMod3Det2Name(ConvertInUnaSolaStringa(c));

                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione), Convert.ToString(componente3.Valutazione));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        //cpu socket
                    }
                }
            }
        }
        public void MostraMemoria(IList componenti, schedaConfronto sc)
        {
            if (componenti.Count > 0)
            {
                IDetails componente1 = (IDetails)componenti[0];

                sc.labelModello1Name(componente1.Modello);
                sc.labelValutazione1Name(Convert.ToString(componente1.Valutazione));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                sc.label4Name("Tipo");
                string[] a = componente1.GetDetail();
                sc.labelMod1Det2Name(Convert.ToString(a[0]));

                sc.label5Name("Capienza");
                sc.labelMod1Det3Name(capienze[0]);

                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda 
                    sc.panelNascosto2VisibileOFF();

                    IDetails componente2 = (IDetails)componenti[1];
                    Debug.WriteLine(componente2.Modello);

                    sc.labelModello2Name(componente2.Modello);
                    sc.labelValutazione2Name(Convert.ToString(componente2.Valutazione));

                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //Tipo
                    string[] b = componente2.GetDetail();
                    sc.labelMod2Det2Name(Convert.ToString(b[0]));

                    string[] tipo = ConvertiInNumeri("ssd", "hdd", "default", a[0], b[0]);

                    //Capienza
                    sc.labelMod2Det3Name(capienze[1]);

                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    ColoraLabelDet2(sc, tipo[0], tipo[1]);//Tipo
                    ColoraLabelDet3(sc, capienze[0], capienze[1]);//capienza


                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();

                        IDetails componente3 = (IDetails)componenti[2];
                        Debug.WriteLine(componente3.Modello);

                        sc.labelModello3Name(componente3.Modello);
                        sc.labelValutazione3Name(Convert.ToString(componente3.Valutazione));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //Tipo
                        string[] c = componente3.GetDetail();
                        sc.labelMod3Det2Name(Convert.ToString(c[0]));

                        tipo = ConvertiInNumeri("ssd", "hdd", "default", a[0], b[0], c[0]);

                        //Capienza
                        sc.labelMod3Det3Name(capienze[2]);

                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione), Convert.ToString(componente3.Valutazione));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        ColoraLabelDet2(sc, tipo[0], tipo[1], tipo[2]);//Tipo
                        ColoraLabelDet3(sc, capienze[0], capienze[1], capienze[2]);//capienza
                    }
                }
            }
        }
        public void MostraCasePc(IList componenti, schedaConfronto sc)
        {
            if (componenti.Count > 0)
            {
                IDetails componente1 = (IDetails)componenti[0];

                sc.labelModello1Name(componente1.Modello);
                sc.labelValutazione1Name(Convert.ToString(componente1.Valutazione));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                sc.label4Name("Tipo");
                string[] a = componente1.GetDetail();
                sc.labelMod1Det2Name(Convert.ToString(a[0]));


                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda 
                    sc.panelNascosto2VisibileOFF();

                    IDetails componente2 = (IDetails)componenti[1];
                    Debug.WriteLine(componente2.Modello);

                    sc.labelModello2Name(componente2.Modello);
                    sc.labelValutazione2Name(Convert.ToString(componente2.Valutazione));

                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //Tipo
                    string[] b = componente2.GetDetail();
                    sc.labelMod2Det2Name(Convert.ToString(b[0]));

                    string[] tipo = ConvertiInNumeri("Big-Tower", "Midi-Tower", "Micro-ATX", a[0], b[0]);

                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    ColoraLabelDet2(sc, tipo[0], tipo[1]);//Tipo


                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();


                        IDetails componente3 = (IDetails)componenti[2];
                        Debug.WriteLine(componente3.Modello);

                        sc.labelModello3Name(componente3.Modello);
                        sc.labelValutazione3Name(Convert.ToString(componente3.Valutazione));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //Tipo
                        string[] c = componente3.GetDetail();
                        sc.labelMod3Det2Name(Convert.ToString(c[0]));

                        tipo = ConvertiInNumeri("Big-Tower", "Midi-Tower", "Micro-ATX", a[0], b[0], c[0]);

                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.Valutazione), Convert.ToString(componente2.Valutazione), Convert.ToString(componente3.Valutazione));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        ColoraLabelDet2(sc, tipo[0], tipo[1], tipo[2]);//Tipo
                    }
                }
            }
        }
        #endregion


        #region Funzioni Utili-------------------------------------------------------------------------------
        public string MaxNumber(params string[] num)
        {
            float a, b, c;

            //-----------------------MAX3----------------------------------
            if (num.Length == 3)
            {
                a = float.Parse(num[0]);
                b = float.Parse(num[1]);
                c = float.Parse(num[2]);

                if (c > a && c > b)
                    return "c";
                else if (a > b && a > c)
                    return "a";
                else if (b > a && b > c)
                    return "b";
                else
                {
                    if (a == b && b == c)
                        return "default";
                    if (a == b)
                        return "ab";
                    if (b == c)
                        return "bc";
                    if (a == c)
                        return "ac";


                    return "default";
                }
            }
            //----------------------MAX2-----------------------------------
            else
            {
                a = float.Parse(num[0]); b = float.Parse(num[1]);

                if (b > a)
                    return "b";
                else if (a > b)
                    return "a";
                else
                    return "default";
            }


        }
        public string MinNumber(params string[] num)
        {
            float a, b, c;

            //-----------------------MIN3----------------------------------
            if (num.Length == 3)
            {
                a = float.Parse(num[0]);
                b = float.Parse(num[1]);
                c = float.Parse(num[2]);
                if (c < a && c < b)
                    return "c";
                else if (a < b && a < c)
                    return "a";
                else if (b < a && b < c)
                    return "b";
                else
                {
                    if (a == b && b == c)
                        return "default";
                    if (a == b)
                        return "ab";
                    if (b == c)
                        return "bc";
                    if (a == c)
                        return "ac";

                    return "default";
                }
            }
            //----------------------MIN2-----------------------------------
            else
            {
                a = float.Parse(num[0]); b = float.Parse(num[1]);
                if (b < a)
                    return "b";
                else if (a < b)
                    return "a";
                else
                    return "default";
            }
        }
        public string[] ConvertiInNumeri(string val1, string val2, string val3, params string[] elem)
        {
            string[] vet = new string[elem.Length];
            for (int i = 0; i < elem.Length; i++)
            {
                if (elem[i] == val1)
                    vet[i] = "3";
                else if (elem[i] == val2)
                    vet[i] = "2";
                else if (elem[i] == val3)
                    vet[i] = "1";
            }

            return vet;
        }
        public string ConvertInUnaSolaStringa(string[] vet)
        {
            int j = 0;
            string message = "";
            for (int i = 0; i < vet.Length; i++)
            {
                j++;
                message += vet[i] + ", ";
                if ((j % 2) == 0)
                    message += "\n";
            }

            return message;
        }
        #endregion


        #region Funzioni per Colorare le righe della Tabella----------------------------------------------
        public void ColoraValutazione(schedaConfronto sc, params string[] abc)
        {
            if (abc.Length == 2)
            {
                if (MaxNumber(abc[0], abc[1]) == "a")
                    sc.labelValutazione1Color(Color.Red);
                if (MaxNumber(abc[0], abc[1]) == "b")
                    sc.labelValutazione2Color(Color.Red);
            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelValutazione1Color(Color.Black);
                sc.labelValutazione2Color(Color.Black);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "a")
                    sc.labelValutazione1Color(Color.Red);
                if (MaxNumber(abc[0], abc[1], abc[2]) == "b")
                    sc.labelValutazione2Color(Color.Red);
                if (MaxNumber(abc[0], abc[1], abc[2]) == "c")
                    sc.labelValutazione3Color(Color.Red);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "ab")
                {
                    sc.labelValutazione1Color(Color.Red);
                    sc.labelValutazione2Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "bc")
                {
                    sc.labelValutazione2Color(Color.Red);
                    sc.labelValutazione3Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "ac")
                {
                    sc.labelValutazione1Color(Color.Red);
                    sc.labelValutazione3Color(Color.Red);
                }
            }


        }
        public void ColoraLabelDet1Min(schedaConfronto sc, params string[] abc)
        {
            if (abc.Length == 2)
            {
                if (MinNumber(abc[0], abc[1]) == "a")
                    sc.labelMod1Det1Color(Color.Red);
                if (MinNumber(abc[0], abc[1]) == "b")
                    sc.labelMod2Det1Color(Color.Red);
            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelMod1Det1Color(Color.Black);
                sc.labelMod2Det1Color(Color.Black);

                if (MinNumber(abc[0], abc[1], abc[2]) == "a")
                    sc.labelMod1Det1Color(Color.Red);
                if (MinNumber(abc[0], abc[1], abc[2]) == "b")
                    sc.labelMod2Det1Color(Color.Red);
                if (MinNumber(abc[0], abc[1], abc[2]) == "c")
                    sc.labelMod3Det1Color(Color.Red);

                if (MinNumber(abc[0], abc[1], abc[2]) == "ab")
                {
                    sc.labelMod1Det1Color(Color.Red);
                    sc.labelMod2Det1Color(Color.Red);
                }

                if (MinNumber(abc[0], abc[1], abc[2]) == "bc")
                {
                    sc.labelMod2Det1Color(Color.Red);
                    sc.labelMod3Det1Color(Color.Red);
                }

                if (MinNumber(abc[0], abc[1], abc[2]) == "ac")
                {
                    sc.labelMod1Det1Color(Color.Red);
                    sc.labelMod3Det1Color(Color.Red);
                }
            }


        }
        public void ColoraLabelDet2(schedaConfronto sc, params string[] abc)
        {
            if (abc.Length == 2)
            {
                if (MaxNumber(abc[0], abc[1]) == "a")
                    sc.labelMod1Det2Color(Color.Red);
                if (MaxNumber(abc[0], abc[1]) == "b")
                    sc.labelMod2Det2Color(Color.Red);
            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelMod1Det2Color(Color.Black);
                sc.labelMod2Det2Color(Color.Black);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "a")
                    sc.labelMod1Det2Color(Color.Red);
                if (MaxNumber(abc[0], abc[1], abc[2]) == "b")
                    sc.labelMod2Det2Color(Color.Red);
                if (MaxNumber(abc[0], abc[1], abc[2]) == "c")
                    sc.labelMod3Det2Color(Color.Red);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "ab")
                {
                    sc.labelMod1Det2Color(Color.Red);
                    sc.labelMod2Det2Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "bc")
                {
                    sc.labelMod2Det2Color(Color.Red);
                    sc.labelMod3Det2Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "ac")
                {
                    sc.labelMod1Det2Color(Color.Red);
                    sc.labelMod3Det2Color(Color.Red);
                }
            }


        }
        public void ColoraLabelDet3(schedaConfronto sc, params string[] abc)
        {
            if (abc.Length == 2)
            {
                if (MaxNumber(abc[0], abc[1]) == "a")
                    sc.labelMod1Det3Color(Color.Red);
                if (MaxNumber(abc[0], abc[1]) == "b")
                    sc.labelMod2Det3Color(Color.Red);
            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelMod1Det3Color(Color.Black);
                sc.labelMod2Det3Color(Color.Black);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "a")
                    sc.labelMod1Det3Color(Color.Red);
                if (MaxNumber(abc[0], abc[1], abc[2]) == "b")
                    sc.labelMod2Det3Color(Color.Red);
                if (MaxNumber(abc[0], abc[1], abc[2]) == "c")
                    sc.labelMod3Det3Color(Color.Red);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "ab")
                {
                    sc.labelMod1Det3Color(Color.Red);
                    sc.labelMod2Det3Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "bc")
                {
                    sc.labelMod2Det3Color(Color.Red);
                    sc.labelMod3Det3Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "ac")
                {
                    sc.labelMod1Det3Color(Color.Red);
                    sc.labelMod3Det3Color(Color.Red);
                }
            }


        }
        public void ColoraLabelDet4(schedaConfronto sc, params string[] abc)
        {
            if (abc.Length == 2)
            {
                if (MaxNumber(abc[0], abc[1]) == "a")
                    sc.labelMod1Det4Color(Color.Red);
                if (MaxNumber(abc[0], abc[1]) == "b")
                    sc.labelMod2Det4Color(Color.Red);
            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelMod1Det4Color(Color.Black);
                sc.labelMod2Det4Color(Color.Black);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "a")
                    sc.labelMod1Det4Color(Color.Red);
                if (MaxNumber(abc[0], abc[1], abc[2]) == "b")
                    sc.labelMod2Det4Color(Color.Red);
                if (MaxNumber(abc[0], abc[1], abc[2]) == "c")
                    sc.labelMod3Det4Color(Color.Red);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "ab")
                {
                    sc.labelMod1Det4Color(Color.Red);
                    sc.labelMod2Det4Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "bc")
                {
                    sc.labelMod2Det4Color(Color.Red);
                    sc.labelMod3Det4Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "ac")
                {
                    sc.labelMod1Det4Color(Color.Red);
                    sc.labelMod3Det4Color(Color.Red);
                }
            }


        }
        public void ColoraLabelDet5(schedaConfronto sc, params string[] abc)
        {
            if (abc.Length == 2)
            {
                if (MaxNumber(abc[0], abc[1]) == "a")
                    sc.labelMod1Det5Color(Color.Red);
                if (MaxNumber(abc[0], abc[1]) == "b")
                    sc.labelMod2Det5Color(Color.Red);
            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelMod1Det5Color(Color.Black);
                sc.labelMod2Det5Color(Color.Black);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "a")
                    sc.labelMod1Det5Color(Color.Red);
                if (MaxNumber(abc[0], abc[1], abc[2]) == "b")
                    sc.labelMod2Det5Color(Color.Red);
                if (MaxNumber(abc[0], abc[1], abc[2]) == "c")
                    sc.labelMod3Det5Color(Color.Red);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "ab")
                {
                    sc.labelMod1Det5Color(Color.Red);
                    sc.labelMod2Det5Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "bc")
                {
                    sc.labelMod2Det5Color(Color.Red);
                    sc.labelMod3Det5Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "ac")
                {
                    sc.labelMod1Det5Color(Color.Red);
                    sc.labelMod3Det5Color(Color.Red);
                }
            }


        }
        #endregion

    }
}
