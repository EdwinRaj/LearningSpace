using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomImplementations;
using NUnit.Framework;

namespace ImplementationTests
{
    [TestFixture]
    public class StringReversalTest
    {
        [Test]
        public void ReverseStringTest()
        {
            string input = "Edwin Arockia Raj";

            var instanceStringReversal = new StringReversal();
            string reversedString = instanceStringReversal.Reverse(input);

        }
    }
}
