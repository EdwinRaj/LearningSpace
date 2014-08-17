using System;
using System.ComponentModel.Composition;

namespace Citi.CodeTest.Server
{
    [Export(typeof(IStockItem))]
	internal class StockItem : IStockItem
	{
		internal StockItem(string name,
		                   double bid,
		                   double ask)
		{
			Name = name;
			DateTime = DateTime.Now;
			Bid = bid;
			Ask = ask;
		}

		#region IStockItem Members

		public string Name { get; private set; }
		public DateTime DateTime { get; private set; }
		public double Bid { get; private set; }
		public double Ask { get; private set; }

		#endregion
	}
}