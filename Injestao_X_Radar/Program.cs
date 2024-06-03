namespace View_Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            int opcao;

            Console.WriteLine(">>>Radar<<<".ToUpper());
            opcao = menu.MenuOptions();
            menu.ShowOption(opcao);
            Console.WriteLine("\nPrograma Encerrado\n");
        }
    }
}