using Newtonsoft.Json;
using System;

namespace APL.Data.Detail
{
    public class Alimentatore : IDetails
    {

        [JsonProperty("modello_alimentatore")]
        public string Modello { get; init; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("watt")]
        public int Watt { get; init; }
        public string[] GetDetail()
        {
            string[] detail = new string[] {
                Convert.ToString(Watt)
            };
            return detail;
        }
    }
}
