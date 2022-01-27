using Newtonsoft.Json;

namespace APL.Data.Detail
{
    public class CasePC : IDetails
    {

        [JsonProperty("modello_casepc")]
        public string Modello { get; init; }
        [JsonProperty("valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("taglia")]
        public string Taglia { get; init; }

        public string[] GetDetail()
        {
            string[] detail = new string[] {
                Taglia
            };
            return detail;
        }

    }
}
