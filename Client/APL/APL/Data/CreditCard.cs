using Newtonsoft.Json;


namespace APL.Data
{
    class CreditCard
    {

        [JsonProperty("number")]
        public long  Number { get;  init; }
        [JsonProperty("month")]
        public int Month { get; init; }
        [JsonProperty("year")]
        public int Year{ get; init; }
        [JsonProperty("cvv")]
        public int CVV { get; init; }


    }

 
}
