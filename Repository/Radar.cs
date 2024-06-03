using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Repository
{
    public class Radar
    {
        public Radar() { }

        /*
            "concessionaria": "AUTOPISTA FERNÃO DIAS",
            "ano_do_pnv_snv": "2007",
            "tipo_de_radar": "Controlador",
            "rodovia": "BR-381",
            "uf": "MG",
            "km_m": "483,700",
            "municipio": "Betim",
            "tipo_pista": "Principal",
            "sentido": "Crescente",
            "situacao": "Ativo",
            "data_da_inativacao": [],
            "latitude": "-19,959486",
            "longitude": "-44,085386",
            "velocidade_leve": "80"
         */

        [JsonProperty("concessionaria")]
        public string concessionaria { get; set; }
        
        [JsonProperty("ano_do_pnv_snv")]
        public int ano_do_pnv_snv { get; set; }

        [JsonProperty("tipo_de_radar")]
        public string tipo_de_radar { get; set; }

        [JsonProperty("rodovia")]
        public string rodovia { get; set; }

        [JsonProperty("uf")]
        public string uf { get; set; }

        [JsonProperty("km_m")]
        public string km_m { get; set; }

        [JsonProperty("municipio")]
        public string municipio { get; set; }

        [JsonProperty("tipo_pista")]
        public string tipo_pista { get; set; }

        [JsonProperty("sentido")]
        public string sentido { get; set; }

        [JsonProperty("situacao")]
        public string situacao { get; set; }

        [JsonProperty("data_da_inativacao")]
        public DateOnly[] data_da_inativacao { get; set; }

        [JsonProperty("latitude")]
        public string latitude { get; set; }

        [JsonProperty("longitude")]
        public string longitude { get; set; }

        [JsonProperty("velocidade_leve")]
        public int velocidade_leve { get; set; }

        public override string ToString()
        {
            string texto1 = $"concessionaria: {this.concessionaria}, ano_do_pnv_snv: {this.ano_do_pnv_snv}, tipo_de_radar: {this.tipo_de_radar}, rodovia: {this.rodovia}, uf: {this.uf}, ";
            string texto2 = $"km_m: {this.km_m}, municipio: {this.municipio}, tipo de pista: {this.tipo_pista}, sentido: {this.sentido}, situacao: {this.situacao}, ";
            string texto3 = $"data_da_inativação: {this.data_da_inativacao}, latitude: {this.latitude}, longitude: {this.longitude}, velocidade leve: {this.velocidade_leve}";

            return texto1 + texto2 + texto3;
        }
    }
}
