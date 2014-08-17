using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Citi.CodeTest.Model
{
    public class StockItemDto
    {
        public string Symbol { get; set; }
        public double BidPrice { get; set; }
        public double AskPrice { get; set; }
        public DateTime DateTime { get; set; }
    }
}
