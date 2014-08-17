using System;
using System.ComponentModel.Composition;

namespace Citi.CodeTest.Server
{
	public interface IStockItem
	{
		string Name { get; }
		DateTime DateTime { get; }
		double Bid { get; }
		double Ask { get; }
	}
}