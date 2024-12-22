using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor
{
    public class Mechanic : IMechanic
    {
        public string Name { get; set; }
        public List<Chocolate> ChocolateStorage { get; set; }
        public List<Foil> FoilStorage { get; set; }

        public Mechanic(string name)
        {
            Name = name;
        }

        public void Fix()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Mechanic {Name} fixed the conveyor");
            Console.ResetColor();
        }
    }
}
