using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter1;
using NUnit.Framework;

namespace Chapter1Tests
{
    [TestFixture]
    public class SimpleRxDemoTest
    {
        [Test]
        public void BasicDemoTest()
        {
            new BasicRx().NonRxDemo();
        }

        [Test]
        public void RxDemoTest()
        {
            new BasicRx().RxDemo();
        }

        [Test]
        public void ExplicitObserverDemoTest()
        {
            new BasicRx().ExplicitObserverDemo();
        }
    }
}
