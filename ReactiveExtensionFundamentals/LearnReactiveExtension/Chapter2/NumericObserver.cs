using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    public class NumericObserver:IObserver<int>
    {
        public void OnNext(int value)
        {
            Console.WriteLine(value);
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error.ToString());
        }

        public void OnCompleted()
        {
            Console.WriteLine("I am Done!");
        }
    }
}
