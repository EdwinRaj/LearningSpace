﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEFFundamentals;

namespace Component
{
    [Export(typeof(ICalculator))]
    [ExportMetadata("Operation", "Sub")]
    public class Subtract:ICalculator
    {
        public int GetNumber(int x, int y)
        {
            return x - y;
        }
    }
}
