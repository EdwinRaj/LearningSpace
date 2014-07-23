using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelperTools
{
    /// <summary>
    /// This class checks if more than one caller gets into the below using block
    /// using(new SimultaneousDelegateCheck)
    /// {
    ///     //Only one caller should enter here
    /// }
    /// </summary>
    public class SimultaneousDelegateCheck:IDisposable
    {
        private int _accessCount = 0;
        public void Dispose()
        {
            Interlocked.Decrement(ref _accessCount);
        }

        public SimultaneousDelegateCheck()
        {
            if ((Interlocked.Increment(ref _accessCount)) != 1)
            {
                throw new Exception("Delegates are running concurrently");

            }
        }
    }
}
