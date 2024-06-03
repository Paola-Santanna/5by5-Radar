using Microsoft.Data.SqlClient;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryMongo
    {
        /*
         * Essa classe vai se comunicar com o banco de dados Mongo:
         * Regra de consumo de dados
         * Conexão
         * Conversão de dados
         */

        private MongoClient _client;
        private MongoCollection<BsonDocument> _collection;
        public RepositoryMongo()
        {
            string connMongo = "mongodb://localhost:27017";
            _client = new MongoClient(connMongo);
            var database = _client.GetDatabase("Radar");
            var _collection = database.GetCollection<BsonDocument>("Radares");
        }

        #region Insercao_dados_MongoDB
        public void Insert(List<DB_Models> list)
        {
            using (var session = _client.StartSession())
            {
                session.StartTransaction();

                var documento = new List<BsonDocument>();

                foreach (var radar in list)
                {
                    var document = new BsonDocument
                        {
                            { "concessionaria", radar.Concessionaria },
                            { "ano_do_pnv_snv", radar.Ano_do_pnv_snv },
                            { "tipo_de_radar", radar.Tipo_de_radar },
                            { "rodovia", radar.Rodovia },
                            { "uf", radar.Uf },
                            { "km_m", radar.Km_m },
                            { "municipio", radar.Municipio },
                            { "tipo_pista", radar.Tipo_pista },
                            { "sentido", radar.Sentido },
                            { "situacao", radar.Situacao },
                            { "data_da_inativacao", null }, //Atencao neste ponto
                            { "latitude", radar.Latitude },
                            { "longitude", radar.Longitude },
                            { "velocidade_leve", radar.Velocidade_leve }
                        };
                    _collection.Insert(document); ;
                }

                  // (session, documents);
                session.CommitTransaction();

                Console.WriteLine("Documentos inseridos com sucesso!");

            }
            #endregion
        }

        #region Extracao_dados_MongoDB
        public List<DB_Models> GetAll()
        {
            DB_Models data = new DB_Models();
            List<DB_Models> list = new List<DB_Models>();
            string srConn = @"Data Source=127.0.0.1;Initial Catalog=Radar;User Id=SA;Password=SqlServer2019!;TrustServerCertificate=True";
            
            using (SqlConnection conn = new SqlConnection(srConn))
            {
                SqlCommand cmd = new SqlCommand(DB_Models.SELECT_SQL, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Concessionaria = reader.GetString(1);
                        data.Ano_do_pnv_snv = reader.GetInt32(2);
                        data.Tipo_de_radar = reader.GetString(3);
                        data.Rodovia = reader.GetString(4);
                        data.Uf = reader.GetString(5);
                        data.Km_m = reader.GetString(6);
                        data.Municipio = reader.GetString(7);
                        data.Tipo_pista = reader.GetString(8);
                        data.Sentido = reader.GetString(9);
                        data.Situacao = reader.GetString(10);
                        data.Data_da_inativacao = null; //Aqui esta dando problema
                        data.Latitude = reader.GetString(12);
                        data.Longitude = reader.GetString(13);
                        data.Velocidade_leve = reader.GetInt32(14);

                        list.Add(data);
                    }
                }
                conn.Close();
            }
            return list;
        }
        #endregion
    }
}

