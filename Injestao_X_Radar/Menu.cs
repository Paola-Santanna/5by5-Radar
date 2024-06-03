using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View_Main
{
    public class Menu
    {
        public Menu() { }

        #region Opcoes
        public int MenuOptions()
        {
            Console.WriteLine("\n>>>Menu<<<".ToUpper());
            Console.WriteLine("1 -> Listar todos os radares");
            Console.WriteLine("2 -> Gerar o arquivo .csv a partir do SQL Server");
            Console.WriteLine("3 -> Gerar o arquivo .csv a partir do Mongo");
            Console.WriteLine("4 -> Gerar o arquivo .json a partir do SQL Server");
            Console.WriteLine("5 -> Gerar o arquivo .json a partir do Mongo");
            Console.WriteLine("6 -> Gerar o arquivo .xml a partir do SQL Server");
            Console.WriteLine("7 -> Gerar o arquivo .xml a partir do Mongo");
            Console.WriteLine("\n0 -> SAIR\n");
            Console.Write("Opcao escolhida: ");
            int opcao = int.Parse(Console.ReadLine());

            Console.Clear();
            return opcao;
        }
        #endregion

        #region Saida das Opcoes
        public void ShowOption(int option)
        {
            ControllerSQL controllerSQL = new();
            ControllerMongo controllerMongo = new();

            do
            {
                switch (option)
                {
                    case 0:
                        break;

                    case 1:
                        Console.WriteLine("\nListar todos os radares\n".ToUpper());
                        controllerSQL.ShowAll();
                        option = Continuar();
                        break;

                    case 2:
                        Console.WriteLine("\nGerar o arquivo .csv a partir do SQL Server\n".ToUpper());
                        controllerSQL.GenerateCSV();
                        option = Continuar();
                        break;

                    case 3:
                        Console.WriteLine("\nGerar o arquivo .csv a partir do Mongo\n".ToUpper());
                        controllerMongo.GenerateCSV();
                        option = Continuar();
                        break;

                    case 4:
                        Console.WriteLine("\nGerar o arquivo .json a partir do SQL Server\n".ToUpper());
                        controllerSQL.GenerateJSON();
                        option = Continuar();
                        break;

                    case 5:
                        Console.WriteLine("\nGerar o arquivo .json a partir do Mongo\n".ToUpper());
                        controllerMongo.GenerateJSON();
                        option = Continuar();
                        break;

                    case 6:
                        Console.WriteLine("\nGerar o arquivo .xml a partir do SQL Server\n".ToUpper());
                        controllerSQL.GenerateXML();
                        option = Continuar();
                        break;

                    case 7:
                        Console.WriteLine("\nGerar o arquivo .xml a partir do Mongo\n".ToUpper());
                        controllerMongo.GenerateXML();
                        option = Continuar();
                        break;

                    default:
                        Console.WriteLine("\nOpcao invalida!\n");
                        option = Continuar();
                        break;
                }
            } while (option != 0);
        }
        #endregion

        #region Metodo Continuar
        public int Continuar()
        {
            Console.WriteLine("\n\nPressione ENTER para continuar...");
            Console.ReadKey();
            Console.Clear();

            return MenuOptions();
        }
        #endregion
    }
}