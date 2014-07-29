using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Linq.ObservableImpl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chapter2;
using NUnit.Framework;

namespace Chapter2Tests
{
    [TestFixture]
    public class RxCodeSnipptesTests
    {
        [Test]
        public void TestPrimitiveObserverRunsToCompletion()
        {
            int[] array = {1, 2, 3, 4, 5};
            var myObservable = (array).ToObservable();
            var numericObserver = new NumericObserver();
            myObservable.Subscribe(numericObserver);

        }


        /// <summary>
        /// Any error that happens on the observable gets caught on exception delegate block
        /// </summary>
        [Test]
        public void TestPrimitiveObserverRunsToError()
        {
            int[] array = { 1, 2, 3, 0, 4, 5 };
            var myObservable = array
                                 //.Select(x=> 10 / x)//To Invoke on error, uncomment this line
                                .ToObservable();
            
            //Below code follows grammer OnNext/OnError/OnComplete
            //IMPORTANT: Any error that happens inside OnNext doesnt get propagated to OnError.
            myObservable.Subscribe(
                n =>
                {
                    Console.WriteLine(n);
                }
                , ex =>
                {
                    Exception localException = ex;
                    Console.WriteLine(localException.ToString());
                }
                , () => Console.WriteLine("Completed Successfully")

                );


        }

        /// <summary>
        /// My own custom observable using Observerable.Create
        /// </summary>
        [Test]
        public void CreatingMyOwnObserver()
        {
             var rates = new List<FxRates>()
            {
                new FxRates() {CurrencyPair = "USD/GBP", BidPrice = 2.01m, AskPrice = 2.00m},
                new FxRates() {CurrencyPair = "USD/Eur", BidPrice = 1.3m, AskPrice = 1.31m},
                new FxRates() {CurrencyPair = "GBP/Eur", BidPrice = .8m, AskPrice = .81m}
            };

            var observable = Observable.Create<FxRates>(observer =>
            {
                try
                {
                    foreach (var currencyPair in rates)
                    {
                        observer.OnNext(currencyPair);//On next called
                    }
                    observer.OnCompleted();////On Completed called
                }
                catch (Exception exception)
                {
                    observer.OnError(exception);//OnError called
                }
                return () => { };
            });

            observable.Subscribe(
                (currencyPair) => Console.WriteLine(currencyPair.ToString()),
                (ex) => Console.WriteLine(ex.ToString()),
                () => Console.WriteLine("Iteration of FxRates Completed")
                );
        }

        [Test]
        public void MakingUseOfExistingObservableImplementation()
        {
            var fxRateObservable = new FxRateObservable();
            fxRateObservable.Subscribe(
                 (currencyPair) => Console.WriteLine(currencyPair.ToString()),
                (ex) => Console.WriteLine(ex.ToString()),
                () => Console.WriteLine("Iteration of FxRates Completed")
                );
        }


        /// <summary>
        /// Only difference:
        /// Current thread: Queues at the end
        /// Immediate thread: Queues to the beigining
        /// </summary>
        [Test]
        public void ImmediateVsConcurrentThreadTest()
        {
            var rates = new List<FxRates>()
            {
                new FxRates() {CurrencyPair = "USD/GBP", BidPrice = 2.01m, AskPrice = 2.00m},
                new FxRates() {CurrencyPair = "USD/Eur", BidPrice = 1.3m, AskPrice = 1.31m},
                new FxRates() {CurrencyPair = "GBP/Eur", BidPrice = .8m, AskPrice = .81m}
            };

            var observable = rates.ToObservable(ImmediateScheduler.Instance);
            observable.Subscribe(
                rate => Console.WriteLine("ThreadId:{0}, IsBackground:{1}, CurrencyPair:{2}",
                    Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground, rate.CurrencyPair));
           
        }

    }
}
