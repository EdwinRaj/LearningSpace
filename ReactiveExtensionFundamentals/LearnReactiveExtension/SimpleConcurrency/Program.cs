using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleConcurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Thread:{0}",Thread.CurrentThread.ManagedThreadId);
            var numberStream = from number in new int[] {1, 2, 3, 4} select ProcessNumber(number);
            var observableStream = numberStream.ToObservable(NewThreadScheduler.Default);

            observableStream.Subscribe(PrintNumber, OnException, OnCompletion);

            Console.ReadLine();
        }

        private static void OnCompletion()
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("On completion Thread:{0} ", Thread.CurrentThread.ManagedThreadId);
        }

        private static void OnException(Exception obj)
        {
            Console.WriteLine("On Exception Thread:{0} ", Thread.CurrentThread.ManagedThreadId);
        }

        private static void PrintNumber(int number)
        {
            Console.WriteLine("Snooze");
            //Thread.Sleep(1000);//Just to ensure that Subscription delegates are not executed concurrently
            Console.WriteLine("On Next Thread:{0} Number:{1} ",Thread.CurrentThread.ManagedThreadId,number);
        }

        private static int ProcessNumber(int number)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Observable Thread:{0} and Number: {1}", Thread.CurrentThread.ManagedThreadId, number);
            return number;
        }
    }
}
