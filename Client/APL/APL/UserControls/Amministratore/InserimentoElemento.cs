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

        public static string InserisciElemento(Details detail,Componente comp)
        {
            Protocol pt = new Protocol();
            string JsonDetail = JsonConvert.SerializeObject(detail);
            string JsonComponente = JsonConvert.SerializeObject(comp);
            pt.SetProtocolID("inserimento");pt.Data = JsonComponente;
            SocketTCP.GetMutex().WaitOne();
            //invio il componente
            SocketTCP.send(pt);
            //invio il detail
            SocketTCP.sendSingleMsg(JsonDetail+"\n");
            SocketTCP.GetMutex().ReleaseMutex();
            return "ok";
        }
    }
}
