using Client.Connection;
using Client.Data;
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
        Componente[] componenti;
        public Confronto(params Componente[] componenenti)
        {
            InitializeComponent();
            pt.SetProtocolID("confronto");pt.Token = "";
            this.componenti = componenenti;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void Confronto_Load(object sender, EventArgs e1)
        {
            SocketTCP sckt = new SocketTCP();
            for (int i = 0; i < componenti.Length; i++) {
                pt.Data += componenti[i].Modello+"!";
            }
            string ok = await sckt.send(pt);

            ComponentFactory factory = new ConcreteConstructorFabric();
            IFactory componenteF = factory.GetComponent(componenti[0].Categoria);
            Type categoria = componenteF.GetType();
            Type genericListType = typeof(List<>).MakeGenericType(categoria);
            IList MyList = (IList)Activator.CreateInstance(genericListType);

            for (int i = 0; i < componenti.Length; i++)
            {
                string single = await sckt.sendSingleMsg("ok");
                string response = await sckt.receive();
                var a = JsonConvert.DeserializeObject(response, categoria);
                MyList.Add(a);
            }
            //Console.WriteLine(a.GetType());

            //switch ()
            //{
            //    case "schedaMadre":
            //       SchedaMadre a = JsonConvert.DeserializeObject<SchedaMadre>(response);
            //        Console.WriteLine(a.ToString());
            //        break;
            //    case "cpu":
            //        Cpu[] b = JsonConvert.DeserializeObject<Cpu[]>(response);
            //        Console.WriteLine(b[0].Valutazione+" "+b[1].Valutazione);
            //        break;
            //    case "schedaVideo":
            //        SchedaVideo c = JsonConvert.DeserializeObject<SchedaVideo>(response);
            //        Console.WriteLine(c.ToString());
            //        break;
            //    case "casepc":
            //        CasePC d = JsonConvert.DeserializeObject<CasePC>(response);
            //        Console.WriteLine(d.ToString());
            //        break;
            //    case "alimentatore":
            //        Alimentatore e = JsonConvert.DeserializeObject<Alimentatore>(response);
            //        Console.WriteLine(e.ToString());
            //        break;
            //    case "dissipatore":
            //        Dissipatore f = JsonConvert.DeserializeObject<Dissipatore>(response);
            //        Console.WriteLine(f.ToString());
            //        break;
            //    case "memoria":
            //        Memoria g = JsonConvert.DeserializeObject<Memoria>(response);
            //        Console.WriteLine(g.ToString());
            //        break;
            //    case "ram":
            //        Ram h=  JsonConvert.DeserializeObject<Ram>(response);
            //        Console.WriteLine(h.ToString());
            //        break;
            //}


        }
    }
}
