using APL.Connections;

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
        public FormAcquistiPassati(string Token)
        {
            InitializeComponent();
            pt.Token = Token;
        }


      
       

        private async void FormAcquistiPassati_Load(object sender, EventArgs e)
        {
            pt.SetProtocolID("storico"); pt.Data = String.Empty;
            PcAssemblato[] PcAssemblati;
            string PrezzoTot;
            string[] PcPreAssemblati;
            List<Acquisto> Acquisti=new List<Acquisto>();
            SocketTCP.GetMutex().WaitOne();
            SocketTCP.send(pt);
            string response = String.Empty;
            response = await SocketTCP.receive();
            if (response.Contains("notFound"))
            {
                SocketTCP.GetMutex().ReleaseMutex();
                return;
            }
            int numeroDiAcquisti = int.Parse(response);
            SocketTCP.sendSingleMsg("ok");
            response = String.Empty;
            for (int i = 0; i < numeroDiAcquisti; i++){
                do
                {
                    // pcassemblati
                    response += await SocketTCP.receive();
                } while (!response.Contains("\n"));
                PcAssemblati = JsonConvert.DeserializeObject<PcAssemblato[]>(response);
                SocketTCP.sendSingleMsg("ok");
                response = await SocketTCP.receive();
                PcPreAssemblati = JsonConvert.DeserializeObject<string[]>(response);
                SocketTCP.sendSingleMsg("ok");
                response = await SocketTCP.receive();
                SocketTCP.sendSingleMsg("ok");
                PrezzoTot = response;
                response = await SocketTCP.receive();
                SocketTCP.sendSingleMsg("ok");
                DateTime data = DateTime.Parse(response);
                response = String.Empty;
                // se pc assemblati ha lunghezza 0 vuol dire che è vuoto
                Debug.WriteLine(PcAssemblati.Length);
                // se pc assemblati ha lunghezza 0 vuol dire che è vuoto
                Debug.WriteLine(PcPreAssemblati.Length);

               // aggiungiPcAllaListView( PrezzoTot,data, PcAssemblati, PcPreAssemblati);
                Acquisti.Add(new Acquisto(PrezzoTot, data, PcAssemblati, PcPreAssemblati));
                
                  
            }
            SocketTCP.GetMutex().ReleaseMutex();

            IOrderedEnumerable<Acquisto> AcquistiOrdinati = Acquisti.OrderByDescending(x => x.Data);
            foreach(Acquisto acq in AcquistiOrdinati)
            {
             aggiungiPcAllaListView(acq.PrezzoTot, acq.Data, acq.PcAssemblati, acq.PcPreAssemblati);
            }
           
        }

       
        private void aggiungiPcAllaListView( string PrezzoTot, DateTime data, PcAssemblato[] PcAssemblati, string[] PcPreAssemblati)
        {
            ElementoCronologia elem = new ElementoCronologia();
            elem.setPrezzoData(PrezzoTot,data);

            if (PcAssemblati.Length > 0)
            {
                foreach (PcAssemblato item in PcAssemblati)
                {
                    foreach (Componente comp in item.Componenti)
                    {
                        if (item.Componenti.Length > 0)
                        {  elem.addComponenteListView(comp);}
                    }
                }
            }

            if (PcPreAssemblati.Length > 0)
            {
                for (int i = 0; i < PcPreAssemblati.Length; i++)
                {elem.addPreassemblatoListView(PcPreAssemblati[i].ToString());}
            }

            if (flowLayoutPanel1.Controls.Count < 0)
            {
                flowLayoutPanel1.Controls.Clear();
            }
            else
                flowLayoutPanel1.Controls.Add(elem);
        }
    }
}
