using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Connection
{
    public class Protocol
    {
        private string ProtocolID { get; set; }
        public string Token { get; set; }
        public string Data { get; set; }
        public string limit = "#453";
        public string end = "\n";
        private Dictionary<string, string> dict = new Dictionary<string, string> {

            { "register","0" },{ "login","1" },{"home","2"},{"getUtente","3"},
            {"modificaUtente","4"},{"profilo","5"},{"catalogo","6"},{"confronto","7"},
            {"buildSolo","8" }

        };
        public void SetProtocolID(string NameFunction)
        {
            this.ProtocolID = this.dict[NameFunction];
        }
        public string GetProtocolID()
        {
            return this.ProtocolID;
        }

    }
}
