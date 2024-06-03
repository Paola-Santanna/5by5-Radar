using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RadarAtivo
    {
        [JsonProperty("radar")]

        public List<Radar> radares { get; set; }

        public override string ToString() => $"radar: {radares}";
    }
}
