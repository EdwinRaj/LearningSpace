﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SubscribeObserveOnThreadPool
{
    class Program
    {
        static void Main()
        {
            // write out thread application is running on
            Console.WriteLine("Application\tThread: {0}", Thread.CurrentThread.ManagedThreadId);
            // make a sequence of numbers
            var numbers = from number in new int[] { 1, 2, 3, 4, 5 } select Slow(number);
            // turn it into an observable sequence of numbers that is processed asynchronously
            var observableNumbers = numbers.ToObservable()
                .SubscribeOn(ThreadPoolScheduler.Instance)
                .ObserveOn(ThreadPoolScheduler.Instance);
                //.SubscribeOn(NewThreadScheduler.Default)
                //.ObserveOn(NewThreadScheduler.Default);


            // subscribe and run callbacks
            var disposable = observableNumbers.Subscribe(Output, Oops, ImDone);
            Console.WriteLine("Done");
            Console.ReadKey();
            Console.WriteLine("Disposable called");
            disposable.Dispose();
            Console.ReadKey();


        }

        // method used to simulate work requiring time
        static int Slow(int number)
        {
            Console.WriteLine("snooooooze on\t number:{0} \tThread: {1}", number, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            return number;
        }

        // methods to use as delegate for processing observableNumbers
        // and keeping track of thread they were run on


        // processes value by writing it along with thread id
        static void Output(int number)
        {
            Console.WriteLine("Value: {0}\tThread: {1}", number,
                              Thread.CurrentThread.ManagedThreadId);
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
