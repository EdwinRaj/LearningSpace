using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Citi.CodeTest.Server
{
	public interface IStockProvider : IObservable<IStockItem>
	{
		IEnumerable<string> StockSymbols { get; }
		IObservable<IStockItem> Subscribe(string symbol);
	}
}