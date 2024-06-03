using Microsoft.Data.SqlClient;
using Models;

namespace Repository
{
    public class RepositorySQL
    {
        DB_Models sqlModels = new();
        /*
         * "Estoque"
         * 
         * Essa classe ira ler e gravar os dados no SQL Server
         */
        string srConn = @"Data Source=127.0.0.1;Initial Catalog=Radar;User Id=SA;Password=SqlServer2019!;TrustServerCertificate=True";
        SqlConnection conn;
        public RepositorySQL() 
        {
            conn = new SqlConnection(srConn);
            conn.Open();
        }

        #region Extracao_dados_"dados_dos_radares.json"
        public List<Radar> ExtractData()
        {
            List<Radar> listaRadares= ReadFile.GetData();

            return listaRadares;
        }
        #endregion

        public List<DB_Models> dadosConvertidos(List<Radar> list)
        {
            List<DB_Models> dadosConvertidos= new List<DB_Models>();
            DB_Models dadoConvertido= new DB_Models();

            foreach (Radar radar in list)
            {
                dadoConvertido.Concessionaria = radar.concessionaria;
                dadoConvertido.Ano_do_pnv_snv = radar.ano_do_pnv_snv;
                dadoConvertido.Tipo_de_radar = radar.tipo_de_radar;
                dadoConvertido.Rodovia = radar.rodovia;
                dadoConvertido.Uf = radar.uf;
                dadoConvertido.Km_m = radar.km_m;
                dadoConvertido.Municipio = radar.municipio;
                dadoConvertido.Tipo_pista = radar.tipo_pista;
                dadoConvertido.Sentido = radar.sentido;
                dadoConvertido.Situacao = radar.situacao;
                dadoConvertido.Data_da_inativacao = radar.data_da_inativacao;
                dadoConvertido.Latitude =  radar.latitude;
                dadoConvertido.Longitude = radar.longitude;
                dadoConvertido.Velocidade_leve = radar.velocidade_leve;

                dadosConvertidos.Add(dadoConvertido);
            }

            return dadosConvertidos;
        }

        #region Insercao_dados_SQL_Server
        public void Insert(List<DB_Models> list)
        {
            SqlCommand cmd = new SqlCommand(DB_Models.INSERT_SQL,conn);

            foreach (var l in list)
            {
                cmd.Parameters.Add(new SqlParameter("@concessionaria", l.Concessionaria));
                cmd.Parameters.Add(new SqlParameter("@ano_do_pnv_snv", l.Ano_do_pnv_snv));
                cmd.Parameters.Add(new SqlParameter("@tipo_de_radar", l.Tipo_de_radar));
                cmd.Parameters.Add(new SqlParameter("@rodovia", l.Rodovia));
                cmd.Parameters.Add(new SqlParameter("@uf", l.Uf));
                cmd.Parameters.Add(new SqlParameter("@km_m", l.Km_m));
                cmd.Parameters.Add(new SqlParameter("@municipio", l.Municipio));
                cmd.Parameters.Add(new SqlParameter("@sentido", l.Sentido));
                cmd.Parameters.Add(new SqlParameter("@situacao", l.Situacao));
                cmd.Parameters.Add(new SqlParameter("@data_da_inativacao", l.Data_da_inativacao));
                cmd.Parameters.Add(new SqlParameter("@latitude", l.Latitude));
                cmd.Parameters.Add(new SqlParameter("@longitude", l.Longitude));
                cmd.Parameters.Add(new SqlParameter("@velocidade_leve", l.Velocidade_leve));

                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
        #endregion
    }
}