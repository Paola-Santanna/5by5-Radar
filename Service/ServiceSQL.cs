using Models;
using Repository;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Service
{
    public class ServiceSQL
    {
        /*
         * Ira transformar os dados do SQl em .csv, .json e .xml
         */

        private RepositorySQL _sqlRepo;
        public ServiceSQL()
        {
            _sqlRepo = new RepositorySQL();
        }

        public List<Radar> Extract()
        {
            List<Radar> listRadar = new();
            listRadar = _sqlRepo.ExtractData();
            return listRadar;
        }

        public void ShowAll()
        {
            List<DB_Models> list = new();
            list = _sqlRepo.dadosConvertidos(Extract());

            foreach (var r in list)
            {
                Console.WriteLine(r.ToString());
                Console.WriteLine();
            }
        }
        public bool Insert()
        {
            _sqlRepo.Insert(_sqlRepo.dadosConvertidos(Extract()));

            return true;
        }

        public void ConvertToCSV()
        {
            List<DB_Models> radaresConv = new();
            radaresConv = _sqlRepo.dadosConvertidos(Extract());

            StringBuilder csv = new();

            foreach (var r in radaresConv)
            {
                csv.AppendLine(r.ToString());
                csv.AppendLine();
            }
            File.WriteAllText("dados_radares_SQL.csv", csv.ToString());
            Console.WriteLine("\nArquivo gerado com sucesso!");
            Console.WriteLine($"Foi salvo na seguinte pasta desta solução: \\Injestao_X_Radar\\Injestao_X_Radar\\bin\\Debug\\net6.0");

        }

        public void ConvertToJSON()
        {
            List<DB_Models> radaresConv = new();
            radaresConv = _sqlRepo.dadosConvertidos(Extract());

            JsonSerializerOptions options = new JsonSerializerOptions();
            string jsonString = JsonSerializer.Serialize(radaresConv, options);
            File.WriteAllText("dados_radares_SQL.json", jsonString);

            Console.WriteLine("\nArquivo gerado com sucesso!");
            Console.WriteLine($"Foi salvo na seguinte pasta desta solução: \\Injestao_X_Radar\\Injestao_X_Radar\\bin\\Debug\\net6.0");

        }

        public void ConvertToXML()
        {
            List<DB_Models> radaresConv = new();
            radaresConv = _sqlRepo.dadosConvertidos(Extract());

            XmlSerializer serializer = new(typeof(List<DB_Models>));

            using (TextWriter writer = new StreamWriter("dados_radares_SQL.xml"))
            {
                serializer.Serialize(writer, radaresConv);
            }
            Console.WriteLine("\nArquivo gerado com sucesso!");
            Console.WriteLine($"Foi salvo na seguinte pasta desta solução: \\Injestao_X_Radar\\Injestao_X_Radar\\bin\\Debug\\net6.0");

        }
            
    }
}
