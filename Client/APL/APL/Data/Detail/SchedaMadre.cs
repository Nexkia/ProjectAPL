using Newtonsoft.Json;

namespace APL.Data.Detail
{
    public class SchedaMadre : IDetails
    {

        [JsonProperty("modello_schedaMadre")]
        public string Modello { get; init; }
        [JsonProperty("valutazione")]
        public int Valutazione { get; init; }
        [JsonProperty("cpusocket")]
        public string CpuSocket { get; init; }
        [JsonProperty("ram")]
        public string Ram { get; init; }
        [JsonProperty("chipset")]
        public string Chipset { get; init; }

        public string[] GetDetail()
        {
            string[] detail = new string[] {
                CpuSocket,
                Ram,
                Chipset,
            };
            return detail;
        }
    }
}
