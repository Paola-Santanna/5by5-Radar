using Models;
using Service;

namespace Controller
{
    public class ControllerSQL
    {
        private ServiceSQL _serviceSQL;
        public ControllerSQL() 
        {
            _serviceSQL = new ServiceSQL();
        }

        public void ShowAll()
        {
            _serviceSQL.ShowAll();
        }
        public void Insert()
        {
            _serviceSQL.Insert();
        }

        public void GenerateCSV()
        {
            _serviceSQL.ConvertToCSV();
        }

        public void GenerateJSON()
        {
            _serviceSQL.ConvertToJSON();
        }

        public void GenerateXML()
        {
            _serviceSQL.ConvertToXML();
        }
    }
}
