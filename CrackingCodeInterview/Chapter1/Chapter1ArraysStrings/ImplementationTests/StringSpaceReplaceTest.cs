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
    public class StringSpaceReplaceTest
    {
        [Test]
        public void TestStringReplacement()
        {
            var replace = new StringSpaceReplace();
            string replaceSpace = replace.ReplaceSpace("Bull Dog Tom            ","20%");

        }
    }
}
