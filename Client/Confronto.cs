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

        string categoria;
        string[] modelli, prezzi;
        public Confronto( string[] modelli, string[] prezzi,string categoria)
        {
            InitializeComponent();
            pt.SetProtocolID("confronto");pt.Token = "";
            this.modelli = modelli;
            this.prezzi = prezzi;
            this.categoria = categoria;
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
            IFactory componenteF = factory.GetComponent(this.categoria);
            Type categoria = componenteF.GetType();
            Type genericListType = typeof(List<>).MakeGenericType(categoria);
            IList MyList = (IList)Activator.CreateInstance(genericListType);

            for (int i = 0; i < modelli.Length; i++)
            {
                string single = await sckt.sendSingleMsg("ok");
                string response = await sckt.receive();
                IFactory a = (IFactory)JsonConvert.DeserializeObject(response, categoria);
                MyList.Add(a);

               
            }
            //Console.WriteLine(a.GetType());

           


        }
    }
}
