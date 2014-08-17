using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Citi.CodeTest.Model
{
    public class TraderBlotterDto
    {
        public DateTime OrderTime { get; set; }
        public string Symbol { get; set; }
        public string Direction { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
    }
}
