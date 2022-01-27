using Newtonsoft.Json;

namespace APL.Data.Detail
{
    public class Dissipatore : IDetails
    {

        [JsonProperty("modello_dissipatore")]
        public string Modello { get; init; }
        [JsonProperty("Valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("cpusocket")]
        public string[] CpuSocket { get; init; }

        public string[] GetDetail()
        {
            return CpuSocket;
        }
    }
}
