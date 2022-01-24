using APL.Connections;
using APL.Data;
using APL.Data.Detail;
using Newtonsoft.Json;

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
                SocketTCP.Send(pt.ToString());
                //invio il detail
                SocketTCP.Send(JsonDetail+"\n");
            SocketTCP.GetMutex().ReleaseMutex();

            return "ok";
        }
    }
}
