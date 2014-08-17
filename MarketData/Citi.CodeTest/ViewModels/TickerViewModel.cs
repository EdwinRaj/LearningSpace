using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using Citi.CodeTest.ApplicationServices;
using Citi.CodeTest.Common;
using Citi.CodeTest.Model;
using Citi.CodeTest.Utilities;

namespace Citi.CodeTest.ViewModels
{
    public interface ITickerViewModel
    {
        StockItemDto StockItem { get; set; }
        void Initialise(string symbol);
    }

    [Export(typeof(ITickerViewModel))]
    public class TickerViewModel:BaseViewModel, ITickerViewModel
    {
        [Import]
        private IStockProviderService Service { get; set; }

        public TickerViewModel()
        {
            //Compose();
        }

        private void Compose()
        {
            var compositionBatch = new CompositionBatch();
            compositionBatch.AddPart(this);
            CompositionHelper.Container.Compose(compositionBatch);
        }


        private StockItemDto _stockItem;

        public StockItemDto StockItem
        {
            get { return _stockItem; }
            set
            {
                _stockItem = value;
                OnPropertyChanged("StockItemDto");
            }
        }

        public void Initialise(string symbol)
        {
            //StockItemDto dto = Service.GetTicks(symbol)
            //    .SubscribeOn(SynchronizationContext.Current)
            //    .First();

            //StockItem = dto;
        }
    }
}
