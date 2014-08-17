using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Citi.CodeTest.Model;

namespace Citi.CodeTest.ApplicationServices
{
    public interface IStockProviderService
    {
        IEnumerable<String> GetStockSymbols();
        IObservable<StockItemDto> GetTicks(string symbol);
    }
}
