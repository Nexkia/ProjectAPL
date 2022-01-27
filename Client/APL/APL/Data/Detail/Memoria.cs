using Newtonsoft.Json;

namespace APL.Data.Detail
{
    public class Memoria : IDetails
    {

        [JsonProperty("modello_memoria")]
        public string Modello { get; init; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("tipo")]
        public string Tipo { get; init; }

        public string[] GetDetail()
        {
            string[] detail = new string[] {
                Tipo
            };
            return detail;
        }
    }
}
