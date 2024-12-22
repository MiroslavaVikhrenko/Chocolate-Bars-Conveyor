namespace Conveyor
{
    internal class Program
    {
        /*
         Конвейер с деталями – смоделировать работу конвейера производства деталей. Реализовать классы – «Конвейер», «Погрузчик».
         Реализовать интерфейс – «Механик» и реализующий его класс - «MexanixHandler». 

         Реализовать события:
         1) В конвейере закончились материалы – погрузчик загружает новую партию;
         2) Конвейер сломался (с некоторой долей вероятности) – механик чинит конвейер.
         */
        static void Main(string[] args)
        {
            Conveyor conveyor = new Conveyor();
            try
            {
                Console.WriteLine("How many chocolate bars is your target?");
                int target = Convert.ToInt32(Console.ReadLine());
                while (conveyor.ChocolateBars.Count < target)
                {                   
                    if (conveyor.CheckMaterials())
                    {
                        if (conveyor.Supplier.FoilStorage.Count == 0 || conveyor.Supplier.ChocolateStorage.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Supplier's Storage is empty!!");
                            Console.ResetColor();
                            break;
                        }
                        conveyor.SupplyMaterials();
                    }
                    conveyor.Run();
                    conveyor.CheckIfConevyorWork();

                    if (conveyor.ChocolateBars.Count >= target)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"GOAL ACHIEVED! {conveyor.ChocolateBars.Count} chocolate bars packed");
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
            Console.ReadKey();
        }
    }
}
