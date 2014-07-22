using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.PlatformServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    public class BasicRx
    {
        public void NonRxDemo()
        {
            
            var query = from number in Enumerable.Range(1, 5)
                select number;

            foreach (var i in query)
            {
                Console.WriteLine(i);
            }
        }

        public void RxDemo()
        {
            Console.WriteLine("Main Thread Id-{0}", Thread.CurrentThread.ManagedThreadId);

            var query = from number in Enumerable.Range(1, 5)
                        select number;
            var observable = query.ToObservable(NewThreadScheduler.Default);
            observable.Subscribe(PrintNumber, IamDone);
            Console.ReadLine();
        }

        public void ExplicitObserverDemo()
        {
            var query = from number in Enumerable.Range(1, 5)
                        select number;
            IObservable<int> observable = query.ToObservable();
            var observer = Observer.Create<int>(PrintNumber,IamDone);
            observable.Subscribe(observer);

        }

        private static void PrintNumber(int obj)
        {
            Console.WriteLine("obj:{0}, Thread Id-{1}",obj,Thread.CurrentThread.ManagedThreadId);
        }

        private static void IamDone()
        {
            Console.WriteLine("I am done");
        }
    }
}
