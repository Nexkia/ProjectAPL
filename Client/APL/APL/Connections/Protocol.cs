using System;
using System.Collections.Generic;

namespace APL.Connections
{
    public class Protocol
    {
        private string ProtocolID {get;set;}
        public string Data {get;set;}
        public string Limit;
        public string End;
        private readonly Dictionary<string, string> FuncDict;
        public Protocol() {
            FuncDict = new Dictionary<string, string>
        {
            { "register","0" },{ "login","1" },{"home","2"},{"getUtente","3"},
            {"modificaUtente","4"},{"profilo","5"},{"catalogo","6"},{"confronto","7"},
            {"buildSolo","8" },{"getInfoPayment","9"},{"CheckOut","10"},
            {"storico","11"},{"inserimento","12"},{"inserimento_pre","13"},
            {"cancellazione","14"},{"cancellazione_pre","15"},{"close","16"},{"recupera_statistiche","19"},
            {"compatibilita","20" }
        };
            ProtocolID = String.Empty;
            Data = String.Empty;
            Limit = " ";
            End = "\n";
        }
        public void SetProtocolID(string NameFunction)
        {
            ProtocolID = FuncDict[NameFunction];
        }
        public override string ToString()
        {
            return ProtocolID+Limit+Data+End;
        }
    }
}
