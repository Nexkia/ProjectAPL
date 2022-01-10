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

        public async static Task<string> InserisciElemento(Details detail,Componente comp)
        {
            string JsonDetail = JsonConvert.SerializeObject(detail);
            string JsonComponente = JsonConvert.SerializeObject(comp);

            Protocol pt=new Protocol();pt.Token = "inserimento";pt.Data = JsonDetail;
            

            SocketTCP.GetMutex().WaitOne();

            //invio il detail
            SocketTCP.send(pt);
            string okmsg = await SocketTCP.receive();
            //invio il componente
            SocketTCP.sendSingleMsg(JsonComponente);
            okmsg = await SocketTCP.receive();

            SocketTCP.GetMutex().ReleaseMutex();

            return okmsg;
        }
    }
}
