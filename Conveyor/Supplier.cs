using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor
{
    public class Supplier
    {
        public string Name { get; set; }
        public List<Chocolate> ChocolateStorage { get; set; }
        public List<Foil> FoilStorage { get; set; }

        public Supplier(string name)
        {
            Name = name;
            ChocolateStorage = new List<Chocolate>()
            {
                new Chocolate(), new Chocolate(), new Chocolate(), new Chocolate(), new Chocolate()
            };
            FoilStorage = new List<Foil>()
            {
                new Foil(), new Foil(), new Foil(), new Foil(), new Foil()
            };
        }

        public Chocolate SupplyChocolate()
        {
                Chocolate chocolate = ChocolateStorage.Last();
                ChocolateStorage.RemoveAt(ChocolateStorage.Count - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Supplier {Name} supplied 10 kg of chocolate.");
                Console.ResetColor();
                return chocolate;
            
        }

        public Foil SupplyFoil()
        {
                Foil foil = FoilStorage.Last();
                FoilStorage.RemoveAt(FoilStorage.Count - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Supplier {Name} supplied 10 m of foil.");
                Console.ResetColor();
                return foil;
        }
    }
}
