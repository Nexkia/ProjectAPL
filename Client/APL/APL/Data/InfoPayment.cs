using Newtonsoft.Json;


namespace APL.Data
{
    class InfoPayment
    {
        [JsonProperty("email")]
        public string? Email { get;  set; }

        [JsonProperty("indirizzoFatturazione")]
        public string? IndirizzoFatturazione { get;  set; }

        [JsonProperty("creditCard")]
        public CreditCard? CreditCard { get;  set; }
      
}
}
