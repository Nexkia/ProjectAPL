using APL.Connections;
using APL.Data;
using APL.UserControls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace APL.Forms
{
    public partial class FormAcquistiPassati : Form
    {
        private Protocol pt;
        public FormAcquistiPassati()
        {
            InitializeComponent();
            pt = new Protocol();
        }

        private void FormAcquistiPassati_Load(object sender, EventArgs e)
        {
            pt.SetProtocolID("storico"); pt.Data = String.Empty;
            PcAssemblato[]? PcAssemblati;
            string PrezzoTot;
            string[]? PcPreAssemblati, PrezziPreAssemblati;
            List<Acquisto> Acquisti = new();
            /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER
            SocketTCP.Wait();
            SocketTCP.Send(pt.ToString());
            string response = SocketTCP.Receive();
            if (response.Contains("notFound"))
            {
                SocketTCP.Release();
                return;
            }
            int numeroDiAcquisti = int.Parse(response);
            for (int i = 0; i < numeroDiAcquisti; i++)
            {
                try
                {
                    response = SocketTCP.Receive();
                    PcAssemblati = JsonConvert.DeserializeObject<PcAssemblato[]>(response);
                    response = SocketTCP.Receive();
                    PcPreAssemblati = JsonConvert.DeserializeObject<string[]>(response);
                    response = SocketTCP.Receive();
                    PrezzoTot = response;
                    response = SocketTCP.Receive();
                    DateTime data = DateTime.Parse(response);
                    response = SocketTCP.Receive();
                    PrezziPreAssemblati = JsonConvert.DeserializeObject<string[]>(response);
                    if (PcAssemblati != null && PcPreAssemblati != null && PrezziPreAssemblati != null)
                    {
                        Debug.WriteLine(PcAssemblati.Length);
                        Debug.WriteLine(PcPreAssemblati.Length);
                        // aggiungiPcAllaListView( PrezzoTot,data, PcAssemblati, PcPreAssemblati);
                        Acquisti.Add(new Acquisto()
                        {
                            PrezzoTot = PrezzoTot,
                            Data = data,
                            PcAssemblati = PcAssemblati,
                            PcPreAssemblati = PcPreAssemblati,
                            PrezziPreAssemblati = PrezziPreAssemblati
                        });
                    }
                }
                catch (JsonException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            SocketTCP.Release();
            /// FINE SCAMBIO DI MESSAGGI CON IL SERVER

            IOrderedEnumerable<Acquisto> AcquistiOrdinati = Acquisti.OrderByDescending(x => x.Data);
            foreach (Acquisto acq in AcquistiOrdinati)
            {
                aggiungiPcAllaListView(acq.PrezzoTot, acq.Data, acq.PcAssemblati, acq.PcPreAssemblati, acq.PrezziPreAssemblati);
            }

        }


        private void aggiungiPcAllaListView(string PrezzoTot, DateTime data, PcAssemblato[] PcAssemblati, string[] PcPreAssemblati, string[] PrezziPreAssemblati)
        {
            ElementoCronologia elem = new ElementoCronologia();
            elem.setPrezzoData(PrezzoTot, data);

            if (PcAssemblati.Length > 0)
            {
                foreach (PcAssemblato item in PcAssemblati)
                {
                    foreach (Componente comp in item.Componenti)
                    {
                        if (item.Componenti.Length > 0)
                            elem.addComponenteListView(comp);
                    }
                }
            }

            if (PcPreAssemblati.Length > 0)
            {
                for (int i = 0; i < PcPreAssemblati.Length; i++)
                    elem.addPreassemblatoListView(PcPreAssemblati[i].ToString(), PrezziPreAssemblati[i].ToString());
            }

            if (flowLayoutPanel1.Controls.Count < 0)
                flowLayoutPanel1.Controls.Clear();
            else
                flowLayoutPanel1.Controls.Add(elem);
        }
    }
}
