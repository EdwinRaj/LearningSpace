using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Linq.ObservableImpl;
using System.Text;
using System.Threading.Tasks;
using Chapter2;
using NUnit.Framework;

namespace Chapter2Tests
{
    [TestFixture]
    public class NumericObserverTests
    {
        [Test]
        public void TestPrimitiveObserver()
        {
            int[] array = {1, 2, 3, 4, 5};
            var myObservable = (array).ToObservable();
            var numericObserver = new NumericObserver();
            myObservable.Subscribe(numericObserver);

        }
    }
}
