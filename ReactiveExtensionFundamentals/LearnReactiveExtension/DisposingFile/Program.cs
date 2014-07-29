using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DisposingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var manualResetEvent = new ManualResetEvent(false);

            var observableSequence = Observable.Using<char, StreamReader>(
                () => new StreamReader(new FileStream("characters.txt", FileMode.Open)),
                sr => sr.ReadToEnd()
                    .ToCharArray()
                    .Select(x => x)
                    .ToObservable(ThreadPoolScheduler.Instance)
                    .Finally(()=>manualResetEvent.Set())//Invoking the finally method. This ensures that comes out of the wait synchronisation block after all the sequence are created

                );
            observableSequence.Subscribe(WriteData);
            manualResetEvent.WaitOne();
        }

        private static void WriteData(char c)
        {
            Thread.Sleep(1000);
            Console.WriteLine(c);
        }
    }
}
