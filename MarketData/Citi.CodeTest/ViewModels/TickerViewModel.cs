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
        //[Import]
        private IStockProviderService Service { get; set; }

        [ImportingConstructor]
        public TickerViewModel(IStockProviderService stockProviderService)
        {
            this.Service = stockProviderService;
        }

        private StockItemDto _stockItem;

        public StockItemDto StockItem
        {
            get { return _stockItem; }
            set
            {
                _stockItem = value;
                OnPropertyChanged("StockItem");
            }
        }

        public void Initialise(string symbol)
        {
            Service.GetTicks(symbol)
                .SubscribeOn(SynchronizationContext.Current)
                .Subscribe(OnNextItem);

        }

        private void OnNextItem(StockItemDto stockItemDto)
        {
            this.StockItem = stockItemDto;
        }
    }
}
