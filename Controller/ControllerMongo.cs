using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ControllerMongo
    {
        /*
         * Essa classe vai controlar as operações no banco de dados do Mongo:
         * 
         */

        private ServiceMongo _serviceMongo;
        public ControllerMongo() 
        {
            _serviceMongo = new ServiceMongo();
        }

        public void Insert()
        {
            _serviceMongo.Insert();
        }

        public void GenerateCSV()
        {
            _serviceMongo.ConvertToCSV();
        }

        public void GenerateJSON()
        {
            _serviceMongo.ConvertToJSON();
        }

        public void GenerateXML()
        {
            _serviceMongo.ConvertToXML();
        }
    }
}
