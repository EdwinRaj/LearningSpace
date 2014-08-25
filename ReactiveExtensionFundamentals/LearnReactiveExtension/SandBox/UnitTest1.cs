using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox
{
    [TestClass]
    public class MyReativeExtensionTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var numberSequence = from number in Enumerable.Range(1, 10)
                select ProcessNumber(number);

            IObservable<int> observableSequence = numberSequence.ToObservable();
            IDisposable disposable = observableSequence.ObserveOn(NewThreadScheduler.Default)
                .SubscribeOn(ThreadPoolScheduler.Instance)
                .Subscribe(OnNextSequence, OnException, OnCompletion);

            observableSequence.ObserveOn(NewThreadScheduler.Default)
                .Subscribe(ProcessEvens);
        }

        private void ProcessEvens(int i)
        {
            if(i/10 %2 == 0)
                Console.WriteLine("Thread:[{0}] Even number processing-{1}",Thread.CurrentThread.ManagedThreadId,i);
        }

        private void OnCompletion()
        {
            Console.WriteLine("OnCompletion: ThreadId-[{0}] and number: {1}", Thread.CurrentThread.ManagedThreadId);
        }

        private void OnException(Exception obj)
        {
            Console.WriteLine("OnException: ThreadId-[{0}] and Exception: {1}", Thread.CurrentThread.ManagedThreadId, obj.ToString());
        }

        private void OnNextSequence(int obj)
        {
            Console.WriteLine("OnNextSequence: ThreadId-[{0}] and number: {1}",Thread.CurrentThread.ManagedThreadId,obj);
        }


        private int ProcessNumber(int number)
        {
            Console.WriteLine("ProcessNumber: ThreadId-[{0}] and number: {1}", Thread.CurrentThread.ManagedThreadId, number*10);
            return number*10;
        }
    }
}
