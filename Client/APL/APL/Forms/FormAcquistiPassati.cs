﻿using APL.Connections;

using APL.UserControls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using APL.Data;

namespace APL.Forms
{
    public partial class FormAcquistiPassati : Form
    {
        Protocol pt = new Protocol();
        SocketTCP sckt;
        public FormAcquistiPassati(string Token, SocketTCP sckt)
        {
            InitializeComponent();
            this.sckt = sckt;
            pt.Token = Token;
        }


      
       

        private async void FormAcquistiPassati_Load(object sender, EventArgs e)
            {
                pt.SetProtocolID("storico"); pt.Data = String.Empty;
                PcAssemblato[] PcAssemblati;
                string Prezzo;
                string[] PcPreAssemblati;
                sckt.GetMutex().WaitOne();
                sckt.send(pt);
                string response = String.Empty;
                response = await sckt.receive();
                int numeroDiAcquisti = int.Parse(response);
                sckt.sendSingleMsg("ok");
                response = String.Empty;
                
                for (int i = 0; i < numeroDiAcquisti; i++) {
                   
                    do
                    {
                        // pcassemblati
                        response += await sckt.receive();
                    } while (!response.Contains("\n"));
                    
                    PcAssemblati = JsonConvert.DeserializeObject<PcAssemblato[]>(response);
                    sckt.sendSingleMsg("ok");
                    response = await sckt.receive();
                   
                    PcPreAssemblati = JsonConvert.DeserializeObject<string[]>(response);
                    sckt.sendSingleMsg("ok");
                    response = await sckt.receive();
                    sckt.sendSingleMsg("ok");
                    Prezzo = response;
                    response = String.Empty;
                    // se pc assemblati ha lunghezza 1 vuol dire che è vuoto
                    Debug.WriteLine("lunghezza PcAssemblati: "+PcAssemblati.Length);
                    // se pc assemblati ha lunghezza 0 vuol dire che è vuoto
                    Debug.WriteLine("lunghezza PcPreAssemblati: " + PcPreAssemblati.Length);

                    aggiungiPcAllaListView(PcAssemblati,  PcPreAssemblati,Prezzo);
                }
                sckt.GetMutex().ReleaseMutex();

            }

        private void aggiungiPcAllaListView(PcAssemblato[] PcAssemblati, string[] PcPreAssemblati,string PrezzoTot)
        {
            ElementoCronologia elem = new ElementoCronologia();

            elem.setPrezzo(PrezzoTot);
            Debug.WriteLine(PcAssemblati);

            if (PcAssemblati.Length > 0)
            {
                foreach(PcAssemblato item in PcAssemblati)
                {
                  

                    foreach(Componente comp in item.Componenti)
                    {
                        if (item.Componenti.Length > 0)
                        {

                            elem.addComponenteListView(comp);
                        }
                       
                    }
                }
            }

            if (PcPreAssemblati.Length > 0)
            {

                for (int i = 0; i < PcPreAssemblati.Length; i++)
                {
                    elem.addPreassemblatoListView(PcPreAssemblati[i].ToString());
                   

                }
            }

            
            //aggiunge al flow label
            if (flowLayoutPanel1.Controls.Count < 0)
            {

                flowLayoutPanel1.Controls.Clear();
            }
            else
                flowLayoutPanel1.Controls.Add(elem);


        }

       
    }
}
