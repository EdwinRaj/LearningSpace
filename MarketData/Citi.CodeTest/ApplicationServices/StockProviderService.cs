using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Citi.CodeTest.Annotations;
using Citi.CodeTest.Model;
using Citi.CodeTest.Server;
using Citi.CodeTest.Utilities;

namespace Citi.CodeTest.ApplicationServices
{
    [Export(typeof(IStockProviderService))]
    public class StockProviderService:IStockProviderService
    {
        //[Import] 
        //private IStockProvider _stockProvider;

        public StockProviderService()
        {
            //Compose();
        }

        private void Compose()
        {
            var compositionBatch = new CompositionBatch();
            compositionBatch.AddPart(this);
            CompositionHelper.Container.Compose(compositionBatch);
        }

        public IEnumerable<String> GetStockSymbols()
        {
            //return _stockProvider.StockSymbols.ToList();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Transforming the Stream to local Dto
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public IObservable<StockItemDto> GetTicks(string symbol)
        {
            //return _stockProvider.Subscribe(symbol)
            //    .ObserveOn(ThreadPoolScheduler.Instance)
            //    .Select(x => new StockItemDto
            //                 {
            //                     AskPrice = x.Ask,
            //                     BidPrice = x.Bid,
            //                     DateTime = x.DateTime,
            //                     Symbol = x.Name
            //                 });
            throw new NotImplementedException();
        }

    }
}
