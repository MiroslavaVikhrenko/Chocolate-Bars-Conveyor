using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor
{
    public class Packer : IPart
    {
        public Guid Id { get; set; }
        public bool IsBroken { get; set; }
        public Packer()
        {
            Id = Guid.NewGuid();
            IsBroken = false;
        }
        public override string ToString()
        {
            return $"Packer {Id}";
        }
        public void ReportError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Alert! {ToString()} is broken!");
            Console.ResetColor();
        }
    }
}
