﻿using APL.Connections;
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
            SocketTCP.Wait();
            //invio il componente
            SocketTCP.Send(pt.ToString());
            //invio il detail
            SocketTCP.Send(JsonDetail+"\n");
            SocketTCP.Release();
            return "ok";
        }
    }
}
