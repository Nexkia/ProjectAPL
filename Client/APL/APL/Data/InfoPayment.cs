using Newtonsoft.Json;


namespace APL.Data
{
    class InfoPayment
    {
        [JsonProperty("email")]
        public string Email { get; init; }

        [JsonProperty("indirizzoFatturazione")]
        public string IndirizzoFatturazione { get; init; }

        [JsonProperty("creditCard")]
        public CreditCard CreditCard { get; init; }

    }
}
