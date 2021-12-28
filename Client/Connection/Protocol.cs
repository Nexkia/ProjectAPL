using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Connection
{
    public class Protocol
    {
        public string ProtocolID { get; set; }
        public string Token { get; set; }
        public string Data { get; set; }
        public string limit = " ";
        public string end = "\n";
    }
}
