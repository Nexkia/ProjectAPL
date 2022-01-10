using APL.Connections;
using APL.Data;
using APL.Data.Detail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.UserControls.Amministratore
{
    class InserimentoElemento
    {

        public async static Task<string> InserisciElemento(Details detail,Componente comp,SocketTCP sckt)
        {
            string JsonDetail = JsonConvert.SerializeObject(detail);
            string JsonComponente = JsonConvert.SerializeObject(comp);

            Protocol pt=new Protocol();pt.Token = "inserimento";pt.Data = JsonDetail;
            

            sckt.GetMutex().WaitOne();

            //invio il detail
            sckt.send(pt);
            string okmsg = await sckt.receive();
            //invio il componente
            sckt.sendSingleMsg(JsonComponente);
            okmsg = await sckt.receive();

            sckt.GetMutex().ReleaseMutex();

            return okmsg;
        }
    }
}
