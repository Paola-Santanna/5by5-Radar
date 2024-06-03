using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Service
{
    public class ServiceMongo
    {
        /*
         * Transformação dos dados do mongo nos arquivos .csv, .json e .xml
         */

        private RepositoryMongo _mongoRepo;

        public ServiceMongo() 
        {
            _mongoRepo = new RepositoryMongo();
            Insert();
        }

        public List<DB_Models> GetData()
        {
            return _mongoRepo.GetAll();
        }
        public void Insert()
        {
            _mongoRepo.Insert(_mongoRepo.GetAll());
        }
        public void ConvertToCSV()
        {
            List<DB_Models> list = _mongoRepo.GetAll();

            StringBuilder csv = new();

            foreach (var r in list)
            {
                csv.AppendLine(r.ToString());
                csv.AppendLine();
            }
            File.WriteAllText("dados_radares_Mongo.csv", csv.ToString());
            Console.WriteLine("\nArquivo gerado com sucesso!");
            Console.WriteLine($"Foi salvo na seguinte pasta desta solução: \\Injestao_X_Radar\\Injestao_X_Radar\\bin\\Debug\\net6.0");
        }
        public void ConvertToJSON()
        {
            List<DB_Models> list = _mongoRepo.GetAll();

            JsonSerializerOptions options = new JsonSerializerOptions();
            string jsonString = JsonSerializer.Serialize(list, options);
            File.WriteAllText("dados_radares_Mongo.json", jsonString);

            Console.WriteLine("\nArquivo gerado com sucesso!");
            Console.WriteLine($"Foi salvo na seguinte pasta desta solução: \\Injestao_X_Radar\\Injestao_X_Radar\\bin\\Debug\\net6.0");
        }
        public void ConvertToXML()
        {
            List<DB_Models> list = _mongoRepo.GetAll();

            XmlSerializer serializer = new(typeof(List<DB_Models>));

            using (TextWriter writer = new StreamWriter("dados_radares_SQL.xml"))
            {
                serializer.Serialize(writer, list);
            }
            Console.WriteLine("\nArquivo gerado com sucesso!");
            Console.WriteLine($"Foi salvo na seguinte pasta desta solução: \\Injestao_X_Radar\\Injestao_X_Radar\\bin\\Debug\\net6.0");
        }
    }
}
