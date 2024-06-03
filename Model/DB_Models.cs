namespace Models
{
    public class DB_Models
    {
        //Essa camada representa os dados e a logica de negócios -> Ela sera utilizada por todas as camadas deste projeto
        //O models esta presente em todas as camadas -> DEFINE O MODELO DE DADOS

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

        public string Concessionaria { get; set; }
        public int Ano_do_pnv_snv { get; set; }
        public string Tipo_de_radar { get; set; }
        public string Rodovia { get; set; }
        public string Uf { get; set; }
        public string Km_m { get; set; }
        public string Municipio { get; set; }
        public string Tipo_pista { get; set; }
        public string Sentido { get; set; }
        public string Situacao { get; set; }
        public DateOnly[] Data_da_inativacao { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Velocidade_leve { get; set; }
        public DB_Models() { }


         public static readonly string INSERT_SQL = "INSERT INTO RADARES (concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_pista, sentido, situacao, data_da_inativacao, latitude, longitude, velocidade_leve) VALUES (@concessionaria, @ano_do_pnv_snv, @tipo_de_radar, @rodovia, @uf, @km_m, @municipio, @tipo_pista, @sentido, @situacao, @data_da_inativacao, @latitude, @longitude, @velocidade_leve)";
        public static readonly string SELECT_SQL = "SELECT concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_pista, sentido, situacao, data_da_inativacao, latitude, longitude, velocidade_leve FROM RADARES";

        public static readonly string INSERT_Mongo = "INSERTMANY *** (Name, Color, Year)";
        
        public override string ToString()
        {
            string texto1 = $"Concessionaria: {Concessionaria} \nAno_do_pnv_snv: {Ano_do_pnv_snv} \nTipo de radar: {Tipo_de_radar} \nRodovia: {Rodovia} \nUF: {Uf}";
            string texto2 = $"\nKm_m: {Km_m} \nMunicipio: {Municipio} \nTipo de pista: {Tipo_pista} \nSentido: {Sentido} \nSituação: {Situacao}";
            string texto3 = $"\nData da inativação: {Data_da_inativacao}\nLatitude: {Latitude} \nLongitude: {Longitude} \nVelocidade leve: {Velocidade_leve}";

            return texto1+texto2+texto3;
        }
    }
}
