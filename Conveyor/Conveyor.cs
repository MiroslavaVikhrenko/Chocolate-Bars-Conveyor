using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor
{
    public class Conveyor
    {
        public Guid Id { get; set; } 
        public Packer Packer { get; set; }
        public Slider Slider { get; set; }
        public MovingBelt MovingBelt { get; set; }
        public Chocolate Chocolate { get; set; }
        public Foil Foil { get; set; }
        public List<ChocolateBar> ChocolateBars { get; set; }
        public Mechanic Mechanic { get; set; }
        public Supplier Supplier { get; set; }

        public Random Random { get; set; }

        public Conveyor()
        {
            Id = Guid.NewGuid();
            Packer = new Packer();
            Slider = new Slider();
            MovingBelt = new MovingBelt();
            Chocolate = new Chocolate();
            Foil = new Foil();
            ChocolateBars = new List<ChocolateBar>();
            Mechanic = new Mechanic("Erik");
            Supplier = new Supplier("Adam");
            Random = new Random();
        }

        public void Run()
        {
            Chocolate.Weight -= 1;
            Foil.Length -= 1;
            for (int i = 0; i < 10; i++)
            {
                ChocolateBars.Add(new ChocolateBar());
            }
            Console.WriteLine($"Packed 10 chocolate bars,total packed: {ChocolateBars.Count}");
        }

        public void SupplyMaterials()
        {
            Chocolate newChocolate = Supplier.SupplyChocolate();
            Foil newFoil = Supplier.SupplyFoil();

            try
            {
                if (newChocolate is not null && newFoil is not null)
                {
                    Chocolate = newChocolate;
                    Foil = newFoil;
                }
                else
                {
                    throw new Exception("Cannot supply meterials because storage is empty");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public bool CheckMaterials()
        {
            if (Chocolate.Weight > 0 && Foil.Length > 0) return false;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There is no chocolate and foil left!");
            Console.ResetColor();

            return true;
        }

        public void CheckIfConevyorWork()
        {
            bool[] bools = { false, true, true, true, true, false, true, true, false, true };
            int rnd = Random.Next(0, 9);

            if (bools[rnd] == false)
            {
                int rnd2 = Random.Next(1, 4);
                switch (rnd2)
                {
                    case 1: 
                        MovingBelt.IsBroken = true;
                        MovingBelt.ReportError();
                        Mechanic.Fix();
                        MovingBelt.IsBroken = false;
                        break;
                    case 2:
                        Slider.IsBroken = true;
                        Slider.ReportError();
                        Mechanic.Fix();
                        Slider.IsBroken = false;
                        break;
                    case 3:
                        Packer.IsBroken = true;
                        Packer.ReportError();
                        Mechanic.Fix();
                        Packer.IsBroken = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
