using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor
{
    public interface IPart
    {
        public bool IsBroken { get; }

        void ReportError();
    }
}
