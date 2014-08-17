using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFFundamentals
{
    [Export(typeof(ICalculator))]
    internal class Add:ICalculator
    {
        public int GetNumber(int x, int y)
        {
            return x + y;
        }
    }
}
