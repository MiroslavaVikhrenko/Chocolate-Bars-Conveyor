﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor
{
    public class ChocolateBar
    {
        public Guid Id { get; set; }
        public ChocolateBar()
        {
            Id = Guid.NewGuid();
        }
    }
}
