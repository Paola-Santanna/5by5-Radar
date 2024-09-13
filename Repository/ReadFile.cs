using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReadFile
    {
        public ReadFile() { }

        public static List<Radar> GetData()
        {
            StreamReader r = new StreamReader("caminho do arquivo");
            string jsonString = r.ReadToEnd();

            //Processo de descerialização 
            var objetoGeral = JsonConvert.DeserializeObject<RadarAtivo>(jsonString);

            if (objetoGeral != null) return objetoGeral.radares;

            return null;
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
