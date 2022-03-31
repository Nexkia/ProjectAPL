using APL.Connections;
using APL.Data;
using APL.Data.Detail;
using Newtonsoft.Json;

namespace APL.UserControls.Amministratore
{
    class InserimentoElemento
    {

        public static void InserisciElemento(IDetails detail, Componente comp)
        {
            Protocol pt = new Protocol();
            string JsonDetail = JsonConvert.SerializeObject(detail);
            string JsonComponente = JsonConvert.SerializeObject(comp);
            pt.SetProtocolID("inserimento"); pt.Data = JsonComponente;
            /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER
            
            //invio il componente
            SocketTCP.Send(pt.ToString());
            //invio il detail
            SocketTCP.Send(JsonDetail + "\n");
            
            /// FINE SCAMBIO DI MESSAGGI CON IL SERVER
        }
    }
}
