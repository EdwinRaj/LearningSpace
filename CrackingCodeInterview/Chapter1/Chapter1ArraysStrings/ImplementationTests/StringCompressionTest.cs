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
    public class StringCompressionTest
    {
        [Test]
        public void BetterCompressionTest()
        {
            var compression = new StringCompression();
            string badCompression = compression.BetterCompression("Arockiaraj");

            Console.WriteLine(badCompression);
        }
    }
}
