using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntrinsicTypeTests
{
  [TestClass]
  public class TopOfTheType
  {
    [TestMethod]
    //[ExpectedException(typeof(Exception), AllowDerivedTypes=true)]
    public void TopOfInteger()
    {
      int top = int.MaxValue;
      int next = top + 1;
      //Assert.IsTrue(next < top);
      //Assert.IsTrue(next == top);
      //Assert.IsTrue(next > top);
      //Assert.IsTrue(next < 0);
      //Assert.IsTrue(next == 0);
      //Assert.IsTrue(next > 0);
      //Assert.IsTrue(next == int.MinValue);
    }

    [TestMethod]
    //[ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
    public void TopOfDouble()
    {
      double top = double.MaxValue;
      double next = top + 1;
      //Assert.IsTrue(next < top);
      //Assert.IsTrue(next == top);
      //Assert.IsTrue(next > top);
      //Assert.IsTrue(next < 0);
      //Assert.IsTrue(next == 0);
      //Assert.IsTrue(next > 0);
    }

    [TestMethod]
    //[ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
    public void TopOfDouble2()
    {
      Single top = Single.MaxValue;
      Single next = top + 1E32F;
      //Assert.IsTrue(next < top);
      //Assert.IsTrue(next == top);
      //Assert.IsTrue(next == Single.PositiveInfinity);
      //Assert.IsTrue(next > top);
      //Assert.IsTrue(next < 0);
      //Assert.IsTrue(next == 0);
      //Assert.IsTrue(next > 0);
    }

    [TestMethod]
    [ExpectedException(typeof(OverflowException), AllowDerivedTypes = true)]
    public void TopOfDecimal()
    {
      decimal top = decimal.MaxValue;
      decimal next = top + 1;
      //Assert.IsTrue(next < top);
      //Assert.IsTrue(next == top);
      //Assert.IsTrue(next > top);
      //Assert.IsTrue(next < 0);
      //Assert.IsTrue(next == 0);
      //Assert.IsTrue(next > 0);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
    public void TopOfIntegerChecked()
    {
      int top = int.MaxValue;
      int next;
      checked
      { next = top + 1; }
      next = checked(top + 1);
      //Assert.IsTrue(next < top);
    }

    [TestMethod]
    //[ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
    public void TopOfIntegerCheckedCall()
    {
      int top = int.MaxValue;
      int next;
      checked
      { next = CalcNumber(top); }
      //Assert.IsTrue(next == int.MinValue);
    }

    private int CalcNumber(int input)
    { return input + 1; }

    [TestMethod]
    [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
    public void TopOfIntegerCheckedZeroDivide()
    {
      int val = 42;
      int zero = 0;
      checked
      { val = val / zero; }
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
    public void TopOfIntegerCheckedZeroZeroDivide()
    {
      int val;
      int zero = 0;
      checked
      { val = zero / zero; }
    }
  }

}
