using Client.Connection;
using Client.Data;
using Newtonsoft.Json;
using System;
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
        Componente componente1,componente2;
        public Confronto(Componente componente1,Componente componente2)
        {
            InitializeComponent();
            pt.SetProtocolID("confronto");pt.Token = "";
            this.componente1 = componente1;
            this.componente2 = componente2;
        }

        private async void Confronto_Load(object sender, EventArgs e1)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = this.componente1.Modello+ "!"+ this.componente2.Modello;
            string ok = await sckt.send(pt);
            string response = await sckt.receive();

            switch (componente1.Categoria)
            {
                case "schedaMadre":
                   SchedaMadre a = JsonConvert.DeserializeObject<SchedaMadre>(response);
                    Console.WriteLine(a.ToString());
                    break;
                case "cpu":
                    Cpu[] b = JsonConvert.DeserializeObject<Cpu[]>(response);
                    Console.WriteLine(b[0].Valutazione+" "+b[1].Valutazione);
                    break;
                case "schedaVideo":
                    SchedaVideo c = JsonConvert.DeserializeObject<SchedaVideo>(response);
                    Console.WriteLine(c.ToString());
                    break;
                case "casepc":
                    CasePC d = JsonConvert.DeserializeObject<CasePC>(response);
                    Console.WriteLine(d.ToString());
                    break;
                case "alimentatore":
                    Alimentatore e = JsonConvert.DeserializeObject<Alimentatore>(response);
                    Console.WriteLine(e.ToString());
                    break;
                case "dissipatore":
                    Dissipatore f = JsonConvert.DeserializeObject<Dissipatore>(response);
                    Console.WriteLine(f.ToString());
                    break;
                case "memoria":
                    Memoria g = JsonConvert.DeserializeObject<Memoria>(response);
                    Console.WriteLine(g.ToString());
                    break;
                case "ram":
                    Ram h=  JsonConvert.DeserializeObject<Ram>(response);
                    Console.WriteLine(h.ToString());
                    break;
            }

            
        }
    }
}
