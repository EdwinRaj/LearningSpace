using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    public class FxRates
    {
        public string CurrencyPair { get; set; }
        public decimal BidPrice { get; set; }
        public decimal AskPrice { get; set; }

        public override string ToString()
        {
            return string.Format("CurrencyPair: {0}, BidPrice: {1}, AskPrice: {2}", CurrencyPair, BidPrice, AskPrice);
        }
    }

    public class FxRateObservable : IObservable<FxRates>
    {
        public IDisposable Subscribe(IObserver<FxRates> observer)
        {
            var rates = new List<FxRates>()
            {
                new FxRates() {CurrencyPair = "USD/GBP", BidPrice = 2.01m, AskPrice = 2.00m},
                new FxRates() {CurrencyPair = "USD/Eur", BidPrice = 1.3m, AskPrice = 1.31m},
                new FxRates() {CurrencyPair = "GBP/Eur", BidPrice = .8m, AskPrice = .81m}
            };

            //why the below code doesnt work
            //rates.Select(val => observer.OnNext(val));

            foreach (FxRates currencyPair in rates)
            {
                observer.OnNext(currencyPair);
            }
            observer.OnCompleted();

            return Disposable.Empty;
        }
    }
}
