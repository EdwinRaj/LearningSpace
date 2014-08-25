using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntrinsicTypeTests
{
  [TestClass]
  public class Rounding
  {
    [TestMethod]
    public void RoundingContext()
    {
      var score = 4.5;
      if (Math.Round(score) == 5)
      {
        // You win!
      }
      else
      {
        // You lose!!
      }
    }

    [TestMethod]
    //[ExpectedException(typeof(Exception))]
    public void RoundingFrom5()
    {
      var x = Math.Round(3.5);
      //Assert.AreEqual(3,y);
      //Assert.AreEqual(4, x);
      var y = Math.Round(4.5);
      //Assert.AreEqual(4, y);
      //Assert.AreEqual(5,y);
      var z = Math.Round(3.25, 1);
      //Assert.AreEqual(3.2, z);
      //Assert.AreEqual( 3.3,z);
    }

    [TestMethod]
    public void RoundingFrom5WithMidpoint()
    {
      var x = Math.Round(3.5, MidpointRounding.AwayFromZero);
      //Assert.AreEqual(4, x);
      var y = Math.Round(4.5, MidpointRounding.AwayFromZero);
      //Assert.AreEqual(5, y);
      var z = Math.Round(3.25, 1, MidpointRounding.AwayFromZero);
      //Assert.AreEqual(3.3, z);
      var z2 = Math.Round(-3.25, 1, MidpointRounding.AwayFromZero);
      //Assert.AreEqual(-3.3, z2);
    }
    [TestMethod]
    //[ExpectedException(typeof(Exception))]
    public void Round4_5()
    {
      var x = Math.Round(4.5);
      //Assert.AreEqual(x, 4);
      //Assert.AreEqual(x, 5);
    }

    [TestMethod]
    //[ExpectedException(typeof(Exception))]
    public void RoundMinus4_5()
    {
      var x = Math.Round(-4.5);
      //Assert.AreEqual(x, -4);
      //Assert.AreEqual(x, -5);
    }

    [TestMethod]
    //[ExpectedException(typeof(Exception))]
    public void Round3_5()
    {
      var x = Math.Round(3.5);
      //Assert.AreEqual(x, 3);
      //Assert.AreEqual(x, 4);
    }

    [TestMethod]
    //[ExpectedException(typeof(Exception))]
    public void RoundMinus3_5()
    {
      var x = Math.Round(-3.5);
      //Assert.AreEqual(x, -3);
      //Assert.AreEqual(x, -4);
    }
  }
}
