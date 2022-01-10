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
            Protocol pt = new Protocol();
            string JsonDetail = JsonConvert.SerializeObject(detail);
            string JsonComponente = JsonConvert.SerializeObject(comp);
            pt.SetProtocolID("inserimento");pt.Data = JsonComponente;
            SocketTCP.GetMutex().WaitOne();
            //invio il componente
            SocketTCP.send(pt);
            string okmsg = await SocketTCP.receive();
            //invio il detail
            SocketTCP.sendSingleMsg(JsonDetail+"\n");
            okmsg = await SocketTCP.receive();
            SocketTCP.GetMutex().ReleaseMutex();
            return okmsg;
        }
    }
}
