using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundForegroundThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application\tThread: {0}", Thread.CurrentThread.ManagedThreadId);
            // make a sequence of numbers
            var numbers = from number in new int[] { 1, 2, 3 } select PrintThreadDetails(number);

            //var observableNumbers = numbers.ToObservable(ThreadPoolScheduler.Instance); //Both observer and subscriber Runs on background thread
            //var observableNumbers = numbers.ToObservable(NewThreadScheduler.Default);//Both observer and subscriber on foreground thread

            //Observe on background thread and subscribe on foreground thread
            var observableNumbers = numbers.ToObservable()
                .ObserveOn(NewThreadScheduler.Default)
                .SubscribeOn(ThreadPoolScheduler.Instance);

            var observers = observableNumbers.Subscribe(Output, Oops, ImDone);//Example for OnNext,OnError and OnComplete Delegates
            Console.WriteLine("Bye!");
            Console.ReadKey();


        }

        private static int PrintThreadDetails(int number)
        {
            Console.WriteLine("Observation Sequence runs on Thread:{0} which is IsBackground:{1}",Thread.CurrentThread.ManagedThreadId,Thread.CurrentThread.IsBackground);
            return number;
        }

        static void Output(int number)
        {
            Console.WriteLine("Value: {0}\tThread: {1}\tBackground {2}", number,
                Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
        }
        // process error by writing message and thread id
        static void Oops(Exception exception)
        {
            Console.WriteLine("Message: {0}\tThread: {1}",
                exception.Message, Thread.CurrentThread.ManagedThreadId);
        }
        // processes completion by writing thread id 
        static void ImDone()
        {
            Console.WriteLine("I'm done on thread {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
