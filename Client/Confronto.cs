using Client.Connection;
using Client.Data;
using EllipticCurve.Utils;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Confronto : Form
    {
        Protocol pt = new Protocol();

        string categoriaOriginale;
        string[] modelli;
        string[] prezzi;
        string[] capienze;
        public Confronto( string[] modelli, string[] prezzi,string[] capienze,string categoria)
        {
            InitializeComponent();
            pt.SetProtocolID("confronto");pt.Token = "";
            this.modelli = modelli;
            this.prezzi = prezzi;
            this.capienze = capienze;
            this.categoriaOriginale = categoria;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void Confronto_Load(object sender, EventArgs e1)
        {
            SocketTCP sckt = new SocketTCP();
            for (int i = 0; i < modelli.Length; i++) {
                pt.Data += modelli[i]+"!";
            }
            string ok = await sckt.send(pt);

            ComponentFactory factory = new ConcreteConstructorFabric();
            IFactory componenteF = factory.GetComponent(categoriaOriginale);
            Type categoria = componenteF.GetType();
            Type genericListType = typeof(List<>).MakeGenericType(categoria);
            IList MyList = (IList)Activator.CreateInstance(genericListType);

            for (int i = 0; i < modelli.Length; i++)
            {
                string single = await sckt.sendSingleMsg("ok");
                string response = await sckt.receive();
                IFactory a = (IFactory)JsonConvert.DeserializeObject(response, categoria);
                MyList.Add(a);

                //string[] b = a.getDetail();
                //Console.WriteLine("modello: " + a.getModello() + " Valutazione: " + a.getValutazione() + " Detail: " + b[0]);

                

            }
            ConfrontaParametri(MyList, categoriaOriginale, capienze);


            //Console.WriteLine(a.GetType());




        }

        private void ConfrontaParametri(IList componenti,string categoria,string[] capienze)
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
                    sc.label7Invisible(); sc.label8Invisible();
                     sc.panel8Invisible(); 
                    sc.labelMod1Det5Invisible(); sc.labelMod1Det6Invisible();
                     sc.labelMod2Det5Invisible(); sc.labelMod2Det6Invisible();
                     sc.labelMod3Det5Invisible(); sc.labelMod3Det6Invisible();

                    MostraSchedaVideo(componenti, sc);
                    break;
                case "schedaMadre":
                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                    sc.label7Invisible(); sc.label8Invisible();
                    sc.panel8Invisible();
                    sc.labelMod1Det5Invisible(); sc.labelMod1Det6Invisible();
                    sc.labelMod2Det5Invisible(); sc.labelMod2Det6Invisible();
                    sc.labelMod3Det5Invisible(); sc.labelMod3Det6Invisible();

                    MostraSchedaMadre(componenti, sc);
                    break;
                case "ram":

                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                     sc.label7Invisible(); sc.label8Invisible();
                      sc.panel8Invisible();
                     sc.labelMod1Det5Invisible(); sc.labelMod1Det6Invisible();
                     sc.labelMod2Det5Invisible(); sc.labelMod2Det6Invisible();
                    sc.labelMod3Det5Invisible(); sc.labelMod3Det6Invisible();

                    MostraRam(componenti, sc);
                    break;
                //Alimentatore,dissipatore,memoria,casePc
                case "alimentatore":
                    
                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                    sc.label5Invisible(); sc.label6Invisible(); sc.label7Invisible(); sc.label8Invisible();
                    sc.panel6Invisible(); sc.panel7Invisible(); sc.panel8Invisible();
                    sc.labelMod1Det3Invisible(); sc.labelMod1Det4Invisible(); sc.labelMod1Det5Invisible(); sc.labelMod1Det6Invisible();
                    sc.labelMod2Det3Invisible(); sc.labelMod2Det4Invisible(); sc.labelMod2Det5Invisible(); sc.labelMod2Det6Invisible();
                    sc.labelMod3Det3Invisible(); sc.labelMod3Det4Invisible(); sc.labelMod3Det5Invisible(); sc.labelMod3Det6Invisible();

                    MostraAlimentatore(componenti, sc);

                    break;
                case "dissipatore":
                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                    sc.label5Invisible(); sc.label6Invisible(); sc.label7Invisible(); sc.label8Invisible();
                    sc.panel6Invisible(); sc.panel7Invisible(); sc.panel8Invisible();
                    sc.labelMod1Det3Invisible(); sc.labelMod1Det4Invisible(); sc.labelMod1Det5Invisible(); sc.labelMod1Det6Invisible();
                    sc.labelMod2Det3Invisible(); sc.labelMod2Det4Invisible(); sc.labelMod2Det5Invisible(); sc.labelMod2Det6Invisible();
                    sc.labelMod3Det3Invisible(); sc.labelMod3Det4Invisible(); sc.labelMod3Det5Invisible(); sc.labelMod3Det6Invisible();

                    MostraDissipatore(componenti, sc);

                   
                    break;
                case "memoria":
                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                     sc.label6Invisible(); sc.label7Invisible(); sc.label8Invisible();
                     sc.panel7Invisible(); sc.panel8Invisible();
                     sc.labelMod1Det4Invisible(); sc.labelMod1Det5Invisible(); sc.labelMod1Det6Invisible();
                     sc.labelMod2Det4Invisible(); sc.labelMod2Det5Invisible(); sc.labelMod2Det6Invisible();
                     sc.labelMod3Det4Invisible(); sc.labelMod3Det5Invisible(); sc.labelMod3Det6Invisible();

                    MostraMemoria(componenti, sc);
                    break;
                case "casepc":
                    sc.labelCategoriaName(categoria);

                    //rendo invisibile tutto ciò che non serve
                    sc.label5Invisible(); sc.label6Invisible(); sc.label7Invisible(); sc.label8Invisible();
                    sc.panel6Invisible(); sc.panel7Invisible(); sc.panel8Invisible();
                    sc.labelMod1Det3Invisible(); sc.labelMod1Det4Invisible(); sc.labelMod1Det5Invisible(); sc.labelMod1Det6Invisible();
                    sc.labelMod2Det3Invisible(); sc.labelMod2Det4Invisible(); sc.labelMod2Det5Invisible(); sc.labelMod2Det6Invisible();
                    sc.labelMod3Det3Invisible(); sc.labelMod3Det4Invisible(); sc.labelMod3Det5Invisible(); sc.labelMod3Det6Invisible();

                    MostraCasePc(componenti, sc);
                    break;
                
            }

            flowLayoutPanelConfronto.Controls.Add(sc);
        }
        public void MostraCpu(IList componenti, schedaConfronto sc)
        {

            if (componenti.Count > 0)
            {


                IFactory componente1 = (IFactory)componenti[0];



                sc.labelModello1Name(componente1.getModello());
                sc.labelValutazione1Name(Convert.ToString(componente1.getValutazione()));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                string[] a = componente1.getDetail();


                sc.label4Name("Tdp");
                sc.labelMod1Det2Name(Convert.ToString(a[0]));

                sc.label5Name("frequenza");
                sc.labelMod1Det3Name(Convert.ToString(a[1]));

                sc.label6Name("socket");
                sc.labelMod1Det4Name(Convert.ToString(a[2]));

                sc.label7Name("Core");
                sc.labelMod1Det5Name(Convert.ToString(a[3]));

                sc.label8Name("Thread");
                sc.labelMod1Det6Name(Convert.ToString(a[4]));


                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda 
                    sc.panelNascosto2VisibileOFF();



                    IFactory componente2 = (IFactory)componenti[1];

                    Console.WriteLine(componente2.getModello());
                    sc.labelModello2Name(componente2.getModello());
                    sc.labelValutazione2Name(Convert.ToString(componente2.getValutazione()));


                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //Tdp
                    string[] b = componente2.getDetail();
                    sc.labelMod2Det2Name(Convert.ToString(b[0]));

                    //frequenza
                    sc.labelMod2Det3Name(Convert.ToString(b[1]));

                    //socket
                    sc.labelMod2Det4Name(Convert.ToString(b[2]));

                    //Core
                    sc.labelMod2Det5Name(Convert.ToString(b[3]));

                    //Thread
                    sc.labelMod2Det6Name(Convert.ToString(b[4]));

                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    ColoraLabelDet2(sc, a[0], b[0]);//Tdp
                    ColoraLabelDet3(sc, a[1], b[1]);//frequenza
                                                    //socket
                    ColoraLabelDet5(sc, a[3], b[3]);//core
                    ColoraLabelDet6(sc, a[4], b[4]);//Thread



                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();


                        IFactory componente3 = (IFactory)componenti[2];
                        Console.WriteLine(componente3.getModello());
                        sc.labelModello3Name(componente3.getModello());
                        sc.labelValutazione3Name(Convert.ToString(componente3.getValutazione()));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //tdp
                        string[] c = componente3.getDetail();
                        sc.labelMod3Det2Name(Convert.ToString(c[0]));

                        //frequenza
                        sc.labelMod3Det3Name(Convert.ToString(c[1]));

                        //socket
                        sc.labelMod3Det4Name(Convert.ToString(c[2]));

                        //Core
                        sc.labelMod3Det5Name(Convert.ToString(c[3]));

                        //Thread
                        sc.labelMod3Det6Name(Convert.ToString(c[4]));

                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()), Convert.ToString(componente3.getValutazione()));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        ColoraLabelDet2(sc, a[0], b[0], c[0]);//Tdp
                        ColoraLabelDet3(sc, a[1], b[1], c[1]);//frequenza
                                                              //socket
                        ColoraLabelDet5(sc, a[3], b[3], c[3]);//core
                        ColoraLabelDet6(sc, a[4], b[4], c[4]);//Thread




                    }
                }
            }
        }
        public void MostraSchedaVideo(IList componenti, schedaConfronto sc)
        {

            if (componenti.Count > 0)
            {


                IFactory componente1 = (IFactory)componenti[0];



                sc.labelModello1Name(componente1.getModello());
                sc.labelValutazione1Name(Convert.ToString(componente1.getValutazione()));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                string[] a = componente1.getDetail();


                sc.label4Name("Tdp");
                sc.labelMod1Det2Name(Convert.ToString(a[0]));

                sc.label5Name("frequenza");
                sc.labelMod1Det3Name(Convert.ToString(a[1]));

                sc.label6Name("Vram");
                sc.labelMod1Det4Name(Convert.ToString(a[2]));

                


                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda 
                    sc.panelNascosto2VisibileOFF();



                    IFactory componente2 = (IFactory)componenti[1];

                    Console.WriteLine(componente2.getModello());
                    sc.labelModello2Name(componente2.getModello());
                    sc.labelValutazione2Name(Convert.ToString(componente2.getValutazione()));


                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //Tdp
                    string[] b = componente2.getDetail();
                    sc.labelMod2Det2Name(Convert.ToString(b[0]));

                    //frequenza
                    sc.labelMod2Det3Name(Convert.ToString(b[1]));

                    //Vram
                    sc.labelMod2Det4Name(Convert.ToString(b[2]));

                   

                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    ColoraLabelDet2(sc, a[0], b[0]);//Tdp
                    ColoraLabelDet3(sc, a[1], b[1]);//frequenza
                    ColoraLabelDet4(sc, a[2], b[2]);//Vram
                   



                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();


                        IFactory componente3 = (IFactory)componenti[2];
                        Console.WriteLine(componente3.getModello());
                        sc.labelModello3Name(componente3.getModello());
                        sc.labelValutazione3Name(Convert.ToString(componente3.getValutazione()));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //tdp
                        string[] c = componente3.getDetail();
                        sc.labelMod3Det2Name(Convert.ToString(c[0]));

                        //frequenza
                        sc.labelMod3Det3Name(Convert.ToString(c[1]));

                        //Vram
                        sc.labelMod3Det4Name(Convert.ToString(c[2]));

 
                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()), Convert.ToString(componente3.getValutazione()));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        ColoraLabelDet2(sc, a[0], b[0], c[0]);//Tdp
                        ColoraLabelDet3(sc, a[1], b[1], c[1]);//frequenza
                        ColoraLabelDet4(sc, a[2], b[2], c[2]);//Vram


                    }
                }
            }
        }
        public void MostraSchedaMadre(IList componenti, schedaConfronto sc)
        {

            if (componenti.Count > 0)
            {


                IFactory componente1 = (IFactory)componenti[0];



                sc.labelModello1Name(componente1.getModello());
                sc.labelValutazione1Name(Convert.ToString(componente1.getValutazione()));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);


                string[] a = componente1.getDetail();

                //if da togliere
                if (a == null) { a = new string[] { "aaaaaaprov1prov1prov1prov1", "prov2prov1prov1", "prov3prov1", "prov4prov1", "prova5", "prova6", "s7", "s8", "s9", "s0" }; }
                

                sc.label4Name("Cpu Socket");
                sc.labelMod1Det2Name(Convert.ToString(OttieniUnaStringa(a)));

                string[] a1 = componente1.getMoreDetail();

                //if da togliere
                if (a1 == null) { a1 = new string[] { "aaaaaaprov1prov1prov1prov1", "prov2prov1prov1", "prov3prov1", "prov4prov1", "prova5", "prova6", "s7", "s8", "s9", "s0" }; }
                

                sc.label5Name("Ram");
                sc.labelMod1Det3Name(OttieniUnaStringa(a1));


                sc.label6Name("SsdM2");

                //bool da togliere
                bool a2 = true;
                sc.labelMod1Det4Name(Convert.ToString(a2));




                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda 
                    sc.panelNascosto2VisibileOFF();



                    IFactory componente2 = (IFactory)componenti[1];

                    Console.WriteLine(componente2.getModello());
                    sc.labelModello2Name(componente2.getModello());
                    sc.labelValutazione2Name(Convert.ToString(componente2.getValutazione()));


                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //Cpu socket
                    string[] b = componente2.getDetail();

                    //if da togliere
                    if (b == null) { b = new string[] { "bbbbbprov1prov1prov1prov1", "prov2prov1prov1", "prov3prov1", "prov4prov1", "prova5", "prova6", "s7", "s8", "s9", "s0" }; }


                    //cpu
                    sc.labelMod2Det2Name(OttieniUnaStringa(b));

                    string[] b1 = componente2.getMoreDetail();

                    //if da togliere
                    if (b1 == null) { b1 = new string[] { "bbbbprov1prov1prov1prov1", "prov2prov1prov1", "prov3prov1", "prov4prov1", "prova5", "prova6", "s7", "s8", "s9", "s0" }; }


                    //RAM
                    sc.labelMod2Det3Name(OttieniUnaStringa(b1));

                    //bool da togliere
                    bool b2 = true;

                    //ssdm2
                    sc.labelMod2Det4Name(Convert.ToString(b2));



                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    //cpu socket
                    //ram
                    //ssdm2




                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();


                        IFactory componente3 = (IFactory)componenti[2];
                        Console.WriteLine(componente3.getModello());
                        sc.labelModello3Name(componente3.getModello());
                        sc.labelValutazione3Name(Convert.ToString(componente3.getValutazione()));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //Cpu socket
                        string[] c = componente3.getDetail();

                        //if da togliere
                        if (c == null) { c = new string[] { "cccccprov1prov1prov1prov1", "prov2prov1prov1", "prov3prov1", "prov4prov1", "prova5", "prova6", "s7", "s8", "s9", "s0" }; }


                        //cpu
                        sc.labelMod3Det2Name(OttieniUnaStringa(c));

                        string[] c1 = componente3.getMoreDetail();

                        //if da togliere
                        if (c1 == null) { c1 = new string[] { "cccccprov1prov1prov1prov1", "prov2prov1prov1", "prov3prov1", "prov4prov1", "prova5", "prova6", "s7", "s8", "s9", "s0" }; }


                        //RAM
                        sc.labelMod3Det3Name(OttieniUnaStringa(c1));

                        //bool da togliere
                        bool c2 = true;

                        //ssdm2
                        sc.labelMod3Det4Name(Convert.ToString(c2));

                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()), Convert.ToString(componente3.getValutazione()));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                       //cpu socket
                       //ram
                       //ssdM2


                    }
                }
            }
        }
        public void MostraRam(IList componenti, schedaConfronto sc)
        {

            if (componenti.Count > 0)
            {


                IFactory componente1 = (IFactory)componenti[0];



                sc.labelModello1Name(componente1.getModello());
                sc.labelValutazione1Name(Convert.ToString(componente1.getValutazione()));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                string[] a = componente1.getDetail();


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



                    IFactory componente2 = (IFactory)componenti[1];

                    Console.WriteLine(componente2.getModello());
                    sc.labelModello2Name(componente2.getModello());
                    sc.labelValutazione2Name(Convert.ToString(componente2.getValutazione()));


                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //frequenza
                    string[] b = componente2.getDetail();
                    sc.labelMod2Det2Name(Convert.ToString(b[0]));

                    //standard
                    sc.labelMod2Det3Name(Convert.ToString(b[1]));

                    //Capienza
                    sc.labelMod2Det4Name(capienze[1]);



                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                                                    
                    ColoraLabelDet2(sc, a[0], b[0]);//frequenza
                                                    //standard
                    ColoraLabelDet4(sc, capienze[0], capienze[1]);//Capienza




                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();


                        IFactory componente3 = (IFactory)componenti[2];
                        Console.WriteLine(componente3.getModello());
                        sc.labelModello3Name(componente3.getModello());
                        sc.labelValutazione3Name(Convert.ToString(componente3.getValutazione()));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //frequenza
                        string[] c = componente3.getDetail();
                        sc.labelMod3Det2Name(Convert.ToString(c[0]));

                        //standard
                        sc.labelMod3Det3Name(Convert.ToString(c[1]));

                        //Capienza
                        sc.labelMod3Det4Name(capienze[2]);


                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()), Convert.ToString(componente3.getValutazione()));
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


                IFactory componente1 = (IFactory)componenti[0];



                sc.labelModello1Name(componente1.getModello());
                sc.labelValutazione1Name(Convert.ToString(componente1.getValutazione()));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                sc.label4Name("Watt");
                string[] a = componente1.getDetail();
                sc.labelMod1Det2Name(Convert.ToString(a[0]));


                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda 
                    sc.panelNascosto2VisibileOFF();



                    IFactory componente2 = (IFactory)componenti[1];

                    Console.WriteLine(componente2.getModello());
                    sc.labelModello2Name(componente2.getModello());
                    sc.labelValutazione2Name(Convert.ToString(componente2.getValutazione()));


                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //watt
                    string[] b = componente2.getDetail();
                    sc.labelMod2Det2Name(Convert.ToString(b[0]));



                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    ColoraLabelDet2(sc, a[0], b[0]);//watt



                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();


                        IFactory componente3 = (IFactory)componenti[2];
                        Console.WriteLine(componente3.getModello());
                        sc.labelModello3Name(componente3.getModello());
                        sc.labelValutazione3Name(Convert.ToString(componente3.getValutazione()));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //watt
                        string[] c = componente3.getDetail();
                        sc.labelMod3Det2Name(Convert.ToString(c[0]));


                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()), Convert.ToString(componente3.getValutazione()));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        ColoraLabelDet2(sc, a[0], b[0], c[0]);//watt




                    }
                }
            }
        }
        public void MostraDissipatore(IList componenti, schedaConfronto sc)
        {

            if (componenti.Count > 0)
            {


                IFactory componente1 = (IFactory)componenti[0];



                sc.labelModello1Name(componente1.getModello());
                sc.labelValutazione1Name(Convert.ToString(componente1.getValutazione()));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                sc.label4Name("Cpu Socket");
                string[] a= componente1.getDetail();

                //if da togliere
                if (a == null) { a=new string[] { "prov1prov1prov1prov1", "prov2prov1prov1", "prov3prov1", "prov4prov1", "prova5","prova6","s7","s8" ,"s9","s0"}; }

                sc.labelMod1Det2Name(OttieniUnaStringa(a));


                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda 
                    sc.panelNascosto2VisibileOFF();



                    IFactory componente2 = (IFactory)componenti[1];

                    Console.WriteLine(componente2.getModello());
                    sc.labelModello2Name(componente2.getModello());
                    sc.labelValutazione2Name(Convert.ToString(componente2.getValutazione()));


                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //Cpu Socket
                    string[] b = componente2.getDetail();

                    //if da togliere
                    if (b == null) { b = new string[] { "prov1", "prov2", "prov3", "prov4", "prova5", "prova6", "prova7", "porva8", "prova9", "prova10" }; }
                    sc.labelMod2Det2Name(OttieniUnaStringa(b));



                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                                                            //cpu socket



                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();


                        IFactory componente3 = (IFactory)componenti[2];
                        Console.WriteLine(componente3.getModello());
                        sc.labelModello3Name(componente3.getModello());
                        sc.labelValutazione3Name(Convert.ToString(componente3.getValutazione()));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //cpu socket
                        string[] c = componente3.getDetail();

                        //if da togliere
                        if (c == null) { c = new string[] { "prov1", "prov2", "prov3", "prov4", "prova5", "prova6", "prova7", "porva8", "prova9", "prova10" }; }
                        sc.labelMod3Det2Name(OttieniUnaStringa(c));


                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()), Convert.ToString(componente3.getValutazione()));
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


                IFactory componente1 = (IFactory)componenti[0];



                sc.labelModello1Name(componente1.getModello());
                sc.labelValutazione1Name(Convert.ToString(componente1.getValutazione()));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                sc.label4Name("Tipo");
                string[] a = componente1.getDetail();
                sc.labelMod1Det2Name(Convert.ToString(a[0]));

                sc.label5Name("Capienza");
                sc.labelMod1Det3Name(capienze[0]);

                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda 
                    sc.panelNascosto2VisibileOFF();



                    IFactory componente2 = (IFactory)componenti[1];

                    Console.WriteLine(componente2.getModello());
                    sc.labelModello2Name(componente2.getModello());
                    sc.labelValutazione2Name(Convert.ToString(componente2.getValutazione()));


                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //Tipo
                    string[] b = componente2.getDetail();
                    sc.labelMod2Det2Name(Convert.ToString(b[0]));

                    string[] tipo = ConvertiInNumeri("ssdm2", "ssd", "hdd", a[0], b[0]);

                    //Capienza
                    sc.labelMod2Det3Name(capienze[1]);

                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    ColoraLabelDet2(sc, tipo[0], tipo[1]);//Tipo
                    ColoraLabelDet3(sc, capienze[0], capienze[1]);//capienza



                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();


                        IFactory componente3 = (IFactory)componenti[2];
                        Console.WriteLine(componente3.getModello());
                        sc.labelModello3Name(componente3.getModello());
                        sc.labelValutazione3Name(Convert.ToString(componente3.getValutazione()));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //Tipo
                        string[] c = componente3.getDetail();
                        sc.labelMod3Det2Name(Convert.ToString(c[0]));

                        tipo = ConvertiInNumeri("ssdm2", "ssd", "hdd", a[0], b[0], c[0]);

                        //Capienza
                        sc.labelMod3Det3Name(capienze[2]);

                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()), Convert.ToString(componente3.getValutazione()));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        ColoraLabelDet2(sc, tipo[0], tipo[1], tipo[2]);//Tipo
                        ColoraLabelDet3(sc, capienze[0], capienze[1],capienze[2]);//capienza




                    }
                }
            }
        }
        public void MostraCasePc(IList componenti, schedaConfronto sc)
        {

            if (componenti.Count > 0)
            {


                IFactory componente1 = (IFactory)componenti[0];



                sc.labelModello1Name(componente1.getModello());
                sc.labelValutazione1Name(Convert.ToString(componente1.getValutazione()));

                sc.label3Name("Prezzo");
                sc.labelMod1Det1Name(prezzi[0]);

                sc.label4Name("Tipo");
                string[] a = componente1.getDetail();
                sc.labelMod1Det2Name(Convert.ToString(a[0]));


                if (componenti.Count > 1)
                {
                    //rendo visibile la seconda 
                    sc.panelNascosto2VisibileOFF();



                    IFactory componente2 = (IFactory)componenti[1];

                    Console.WriteLine(componente2.getModello());
                    sc.labelModello2Name(componente2.getModello());
                    sc.labelValutazione2Name(Convert.ToString(componente2.getValutazione()));


                    //prezzo
                    sc.labelMod2Det1Name(prezzi[1]);

                    //Tipo
                    string[] b = componente2.getDetail();
                    sc.labelMod2Det2Name(Convert.ToString(b[0]));

                    string[] tipo = ConvertiInNumeri("ultra", "full", "mid", a[0], b[0]);



                    //colora i campi con i valori migliori
                    ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()));
                    ColoraLabelDet1Min(sc, prezzi[0], prezzi[1]);
                    ColoraLabelDet2(sc, tipo[0], tipo[1]);//Tipo



                    if (componenti.Count > 2)
                    {
                        //rendo visibile la seconda e la terza tabella
                        sc.panelNascosto2VisibileOFF();
                        sc.panelNascosto3VisibileOFF();


                        IFactory componente3 = (IFactory)componenti[2];
                        Console.WriteLine(componente3.getModello());
                        sc.labelModello3Name(componente3.getModello());
                        sc.labelValutazione3Name(Convert.ToString(componente3.getValutazione()));

                        //prezzo
                        sc.labelMod3Det1Name(prezzi[2]);

                        //Tipo
                        string[] c = componente3.getDetail();
                        sc.labelMod3Det2Name(Convert.ToString(c[0]));

                         tipo = ConvertiInNumeri("ultra", "full", "mid", a[0], b[0],c[0]);

                        //colora i campi che hanno il valore migliore
                        ColoraValutazione(sc, Convert.ToString(componente1.getValutazione()), Convert.ToString(componente2.getValutazione()), Convert.ToString(componente3.getValutazione()));
                        ColoraLabelDet1Min(sc, prezzi[0], prezzi[1], prezzi[2]);
                        ColoraLabelDet2(sc, tipo[0], tipo[1], tipo[2]);//Tipo




                    }
                }
            }
        }



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
                {
                    // Console.WriteLine("il terzo numero è il più grande");
                    return "c";

                }
                else if (a > b && a > c)
                {
                    // Console.WriteLine("il primo numero è il più grande");
                    return "a";
                }
                else if (b > a && b > c)
                {
                    // Console.WriteLine("il secondo numero è il più grande");
                    return "b";
                }
                else
                {
                    if(a==b && b == c)
                    {
                        return "default";
                    }

                    if (a == b)
                    {
                        return "ab";
                    }

                    if (b == c)
                    {
                        return "bc";
                    }

                    if (a == c)
                    {
                        
                        return "ac";

                    }
                    return "default";
                }
            }
            //----------------------MAX2-----------------------------------
            else
            {
                a = float.Parse(num[0]);
                b = float.Parse(num[1]);
                if (b > a)
                {
                    // Console.WriteLine("il secondo numero è il più grande");
                    return "b";

                }
                else if (a > b)
                {
                    //Console.WriteLine("il primo numero è il più grande");
                    return "a";
                }

                else
                {

                    return "default";
                }

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
                {
                    // Console.WriteLine("il terzo numero è il più piccolo");
                    return "c";

                }
                else if (a < b && a < c)
                {
                    // Console.WriteLine("il primo numero è il più piccolo");
                    return "a";
                }
                else if (b < a && b < c)
                {
                    // Console.WriteLine("il secondo numero è il più piccolo");
                    return "b";
                }
                else
                {
                    if (a == b && b == c)
                    {
                        return "default";
                    }

                    if (a == b)
                    {
                        return "ab";
                    }

                    if (b == c)
                    {
                        return "bc";
                    }

                    if (a == c)
                    {

                        return "ac";

                    }
                    return "default";
                }
            }
            //----------------------MIN2-----------------------------------
            else
            {
                a = float.Parse(num[0]);
                b = float.Parse(num[1]);
                if (b < a)
                {
                    //  Console.WriteLine("il secondo numero è il più piccolo");
                    return "b";

                }
                else if (a < b)
                {
                    // Console.WriteLine("il primo numero è il più piccolo");
                    return "a";
                }

                else
                {

                    return "default";
                }

            }


        }

        public string[] ConvertiInNumeri(string val1, string val2, string val3, params string[] elem)
        {
            string[] vet = new string[elem.Length];
            for (int i = 0; i < elem.Length; i++)
            {
                if (elem[i] == val1)
                {
                    vet[i] = "3";
                }
                else if (elem[i] == val2)
                {
                    vet[i] = "2";
                }
                else if (elem[i] == val3)
                {
                    vet[i] = "1";
                }
            }

            return vet;
        }

        public string OttieniUnaStringa(string[] vet)
        {
            int j = 0;
            string message="";
            for(int i = 0; i < vet.Length; i++)
            {
                j ++;
                message += vet[i] + ", ";
                if ((j % 2) == 0)
                {
                    message += "\n";
                }
                
            }
            return message;
        }


        public void ColoraValutazione(schedaConfronto sc,params string[] abc)
        {
            if (abc.Length == 2) {
                if (MaxNumber(abc[0], abc[1]) == "a")
                {
                    sc.labelValutazione1Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1]) == "b")
                {
                    sc.labelValutazione2Color(Color.Red);
                }

            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelValutazione1Color(Color.Black);
                sc.labelValutazione2Color(Color.Black);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "a")
                {
                    sc.labelValutazione1Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "b")
                {
                    sc.labelValutazione2Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "c")
                {
                    sc.labelValutazione3Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1],abc[2]) == "ab")
                {
                    sc.labelValutazione1Color(Color.Red);
                    sc.labelValutazione2Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1],abc[2]) == "bc")
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
                {
                    sc.labelMod1Det1Color(Color.Red);
                }

                if (MinNumber(abc[0], abc[1]) == "b")
                {
                    sc.labelMod2Det1Color(Color.Red);
                }
            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelMod1Det1Color(Color.Black);
                sc.labelMod2Det1Color(Color.Black);

                if (MinNumber(abc[0], abc[1], abc[2]) == "a")
                {
                    sc.labelMod1Det1Color(Color.Red);
                }

                if (MinNumber(abc[0], abc[1], abc[2]) == "b")
                {
                    sc.labelMod2Det1Color(Color.Red);
                }

                if (MinNumber(abc[0], abc[1], abc[2]) == "c")
                {
                    sc.labelMod3Det1Color(Color.Red);
                }

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
                {
                    sc.labelMod1Det2Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1]) == "b")
                {
                    sc.labelMod2Det2Color(Color.Red);
                }
            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelMod1Det2Color(Color.Black);
                sc.labelMod2Det2Color(Color.Black);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "a")
                {
                    sc.labelMod1Det2Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "b")
                {
                    sc.labelMod2Det2Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "c")
                {
                    sc.labelMod3Det2Color(Color.Red);
                }

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
                {
                    sc.labelMod1Det3Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1]) == "b")
                {
                    sc.labelMod2Det3Color(Color.Red);
                }
            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelMod1Det3Color(Color.Black);
                sc.labelMod2Det3Color(Color.Black);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "a")
                {
                    sc.labelMod1Det3Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "b")
                {
                    sc.labelMod2Det3Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "c")
                {
                    sc.labelMod3Det3Color(Color.Red);
                }

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
                {
                    sc.labelMod1Det4Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1]) == "b")
                {
                    sc.labelMod2Det4Color(Color.Red);
                }
            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelMod1Det4Color(Color.Black);
                sc.labelMod2Det4Color(Color.Black);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "a")
                {
                    sc.labelMod1Det4Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "b")
                {
                    sc.labelMod2Det4Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "c")
                {
                    sc.labelMod3Det4Color(Color.Red);
                }

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
                {
                    sc.labelMod1Det5Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1]) == "b")
                {
                    sc.labelMod2Det5Color(Color.Red);
                }
            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelMod1Det5Color(Color.Black);
                sc.labelMod2Det5Color(Color.Black);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "a")
                {
                    sc.labelMod1Det5Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "b")
                {
                    sc.labelMod2Det5Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "c")
                {
                    sc.labelMod3Det5Color(Color.Red);
                }

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
        public void ColoraLabelDet6(schedaConfronto sc, params string[] abc)
        {
            if (abc.Length == 2)
            {
                if (MaxNumber(abc[0], abc[1]) == "a")
                {
                    sc.labelMod1Det6Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1]) == "b")
                {
                    sc.labelMod2Det6Color(Color.Red);
                }
            }

            if (abc.Length == 3)
            {   //resetto i colori, mettendoli neri
                sc.labelMod1Det6Color(Color.Black);
                sc.labelMod2Det6Color(Color.Black);

                if (MaxNumber(abc[0], abc[1], abc[2]) == "a")
                {
                    sc.labelMod1Det6Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "b")
                {
                    sc.labelMod2Det6Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "c")
                {
                    sc.labelMod3Det6Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "ab")
                {
                    sc.labelMod1Det6Color(Color.Red);
                    sc.labelMod2Det6Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "bc")
                {
                    sc.labelMod2Det6Color(Color.Red);
                    sc.labelMod3Det6Color(Color.Red);
                }

                if (MaxNumber(abc[0], abc[1], abc[2]) == "ac")
                {
                    sc.labelMod1Det6Color(Color.Red);
                    sc.labelMod3Det6Color(Color.Red);
                }
            }


        }
    }
}
