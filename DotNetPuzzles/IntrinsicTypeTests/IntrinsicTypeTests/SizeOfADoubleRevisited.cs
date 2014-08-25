using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntrinsicTypeTests
{
    [TestClass]
    public class SizeOfADoubleRevisited
    {
  
       //[TestMethod]
       ////[ExpectedException(typeof(Exception))]
       //public void EnormousNumberTest()
       // {
       //     double reallyBigNumber = 10E300 * 10E200;
       //     //Assert.IsTrue(reallyBigNumber > 1);
       //     //Assert.IsTrue(reallyBigNumber < 1);
       //     //Assert.IsTrue(reallyBigNumber < 0);
       // }

       [TestMethod]
       // [ExpectedException(typeof(OverflowException))]
       public void TinyNumberTest()
       {
           double reallyBigNumber = 10E-300 * 10E-200;
           //Assert.IsTrue(reallyBigNumber > 1);
           //Assert.IsTrue(reallyBigNumber < 1);
           //Assert.IsTrue(reallyBigNumber < 0);
           //Assert.IsTrue(reallyBigNumber == 0);
       }
    
    }
}
