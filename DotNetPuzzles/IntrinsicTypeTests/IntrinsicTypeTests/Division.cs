using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntrinsicTypeTests
{
  [TestClass]
  public class Division
  {
      [TestMethod]
    public void test()
    {
      var discount = CalucateDiscount(30, 20, 30);
      Assert.AreEqual(0,discount);
    }

    public int CalucateDiscount(int maxDiscountPercent, int markupPercent, int niceFactor)
    {
      int discount = maxDiscountPercent * (markupPercent / niceFactor);//dividing integer by integer results in integer. 
      //since markupPercent < niceFactor, the expression inside bracket leads to zero.
      return discount;
    }

    [TestMethod]
    //[ExpectedException (typeof(Exception), AllowDerivedTypes=true)]
    public void DivisionTest()
    {
      int maxDiscountPercent = 30;
      int markupPercent = 20;
      int niceFactor = 30;
      int discount = maxDiscountPercent * (markupPercent / niceFactor);//Again, since markupPercent < niceFactor, the expression inside bracket leads to zero.
      Assert.IsTrue(0 == discount);
      //Assert.IsTrue(10 == discount);
      //Assert.IsTrue(20 == discount);
      //Assert.IsTrue(30 == discount);
    }

    [TestMethod]
    //[ExpectedException (typeof(Exception), AllowDerivedTypes=true)]
    public void DivisionTest2()
    {
      byte maxDiscountPercent = 30;
      int markupPercent = 50;
      int niceFactor = 30;
      int discount = maxDiscountPercent * (markupPercent / niceFactor);//here markupPercent > nicefactor. Division results in 1 and result is 30
      //Assert.IsTrue(0 == discount);
      //Assert.IsTrue(10 == discount);
      //Assert.IsTrue(20 == discount);
      Assert.IsTrue(30 == discount);
    }

    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void DivisionTest3()
    {
      int x = 9; int y = 10; int z = 100;
      if (x == 0 || y == 0) { throw new InvalidOperationException(); }
      decimal interim = x / y;
      decimal result = z / interim;//intermim is zero resulting in DivideByZero Exception
    }

    [TestMethod]
    //[ExpectedException (typeof(Exception), AllowDerivedTypes=true)]
    public void DivisionTestDecimal()
    {
      int maxDiscountPercent = 30;
      decimal markupPercent = 20;
      int niceFactor = 30;
      decimal discount = maxDiscountPercent * (markupPercent / niceFactor);//division of decimal by integer,results in decimal.
      //Assert.IsTrue(0 == discount);
      //Assert.IsTrue(10 == discount);
      //Assert.IsFalse(20 == discount);
      Assert.IsTrue(20 == Math.Round(discount));
      //Assert.IsTrue(30 == discount);
    }

    [TestMethod]
    //[ExpectedException (typeof(Exception), AllowDerivedTypes=true)]
    public void DivisionTestDouble()
    {
      int maxDiscountPercent = 30;
      double markupPercent = 20;
      int niceFactor = 30;
      double discount = maxDiscountPercent * (markupPercent / niceFactor);//division of double by integer results in double
      //Assert.IsTrue(0 == discount);
      //Assert.IsTrue(10 == discount);
      Assert.IsTrue(20 == discount);
      //Assert.IsTrue(30 == discount);
    }

  }
}
