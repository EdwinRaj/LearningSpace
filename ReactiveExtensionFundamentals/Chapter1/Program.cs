using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[{0}] Thread",Thread.CurrentThread.ManagedThreadId);

            var query = from number in Enumerable.Range(1, 5)
                        select number;

            //var observable = query.ToObservable(NewThreadScheduler.Default.)

        }
    }
}
