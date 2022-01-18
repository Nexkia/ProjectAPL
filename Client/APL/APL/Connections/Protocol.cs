﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Connections
{
    public class Protocol
    {
        private string? ProtocolID {get;set;}
        public string? Token {get;set;}
        public string? Data {get;set;}
        public string Limit = " ";
        public string End = "\n";
        private Dictionary<string, string> FuncDict = new Dictionary<string, string>
        {
            { "register","0" },{ "login","1" },{"home","2"},{"getUtente","3"},
            {"modificaUtente","4"},{"profilo","5"},{"catalogo","6"},{"confronto","7"},
            {"buildSolo","8" },{"close","9"},{"getInfoPayment","10"},{"CheckOut","11"},
            {"storico","12"},{"inserimento","13"},{"cancellazione","14"},
            {"inserimento_pre","15"},{"cancellazione_pre","16"},{"recupera_statistiche","19"},
            {"compatibilita","20" }
        };
        public void SetProtocolID(string NameFunction)
        {
            this.ProtocolID = this.FuncDict[NameFunction];
        }
        public string GetProtocolID()
        {
            if (this.ProtocolID == null)
                return String.Empty;
            return ProtocolID;
        }
    }
}
