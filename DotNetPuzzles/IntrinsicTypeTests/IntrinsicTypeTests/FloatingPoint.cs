using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntrinsicTypeTests
{
  [TestClass]
  public class FloatingPoint
  {
      [TestMethod]
      public void CalculateCompliance()
      {
          Single[] monthlyEF = {1, 1, 1};
          Single[] monthlyOut = {3, 3, 3};
          Double quarterlyCompliance = 0;
          for (int i = 0; i < 3; i++)
          {
              quarterlyCompliance += monthlyEF[i]/monthlyOut[i];
          }
          if (quarterlyCompliance < 1)
          {
              Console.WriteLine("Less than 1");
          } // Out of Compliance, adjust systems!
          else if (quarterlyCompliance > 1)
          {
              Console.WriteLine("Greater than 1");
          } // We're wasting money, adjust systems!!!
          else
          {
              Console.WriteLine("Give Bonus");
          } // Exactly on target! Give everyone a bonus }
      }

      [TestMethod]
    //[ExpectedException(typeof(Exception))]
    public void ReconstructPie()
    {
      Single one = 1;
      Single three = 3;
      Single x = one / three;
      Double result = 3 * x;
      //Assert.IsTrue(result == 1.0);
      //Assert.IsTrue(result < 1.0);
      Assert.IsTrue(result > 1.0);
      Assert.IsTrue(Math.Round(result, 7) == 1);
    }

    [TestMethod]
    //[ExpectedException(typeof(Exception))]
    public void ReconstructPie2()
    {
      Single one = 1;
      Single three = 3;
      Single x = one / three;
      Single result = 3 * x;
      Assert.IsTrue(result == 1.0);
      //Assert.IsTrue(result < 1.0);
      //Assert.IsTrue(result > 1.0);
      //Assert.IsTrue(Math.Round(result, 7) == 1);
    }

    [TestMethod]
    public void ManyPiePieces()
    {
      Double x = .1;
      Double result = 10 * x;
      Double result2 = x + x + x + x + x + x + x + x + x + x;
      //Assert.IsTrue(result == 1);
      //Assert.IsTrue(result2 != 1);
      //Assert.IsTrue(result != result2);
      Console.WriteLine("{0} - {1}", result, result2);
      Console.WriteLine("{0:R} - {1:R}", result, result2);
    }

    [TestMethod]
    public void DecimalConversions()
    {
      Single pointOne = 0.1F;
      Single result = 0;
      for (int i = 0; i < 10; i++)
      {
        result += pointOne;
      }
      //Assert.AreEqual("1.00000012", string.Format("{0:R}", result));
    }

    [TestMethod]
    //[ExpectedException(typeof(Exception))]
    public void PositiveNegativeInfinity()
    {
      Single zero = 0F;
      Single negativeZero = -0F;
      //Assert.AreEqual(zero, negativeZero);
      //Assert.IsTrue(zero > negativeZero);
      //Assert.AreEqual(Single.PositiveInfinity, 3 / zero);
      //Assert.AreEqual(Single.NegativeInfinity, 3 / negativeZero);
      //Assert.IsTrue(Single.PositiveInfinity == 3 / zero);
      //Assert.IsTrue(Single.NegativeInfinity == 3 / negativeZero);
      //Assert.IsTrue(Double.PositiveInfinity == 3 / zero);
      //Assert.IsTrue(Double.NegativeInfinity == 3 / negativeZero);
      //Assert.IsTrue(Double.PositiveInfinity == Single.PositiveInfinity);
      //Assert.AreNotEqual(3 / zero, 3 / negativeZero);
      //Assert.AreEqual(Single.NaN, zero / zero);
      //Assert.AreEqual(zero / zero, zero / negativeZero);
      //Assert.AreEqual(zero / zero, negativeZero / zero);
      //Assert.AreEqual(zero / zero, zero / negativeZero);
      //Assert.AreEqual(zero / zero, negativeZero / negativeZero);
      //Assert.AreEqual(negativeZero, -1F / 1E200 / 1E200);
      //Assert.AreEqual(negativeZero, -1F * zero);
      Console.WriteLine(Single.MaxValue);
      Console.WriteLine(Single.MinValue);
      Console.WriteLine(Single.Epsilon);
      Console.WriteLine(Double.MaxValue);
      Console.WriteLine(Double.MinValue);
      Console.WriteLine(Double.Epsilon);
      Console.WriteLine(Decimal.MaxValue);
      Console.WriteLine(Decimal.MinValue);
    }

    [TestMethod]
    //[ExpectedException(typeof(Exception))]
    public void Epsilon()
    {
      Single zero = 0F;
      Double pi = Math.PI;
      //Assert.IsTrue(Single.Epsilon > Double.Epsilon);
      //Assert.IsTrue(Single.Epsilon > zero);
      //Assert.IsTrue(zero == Single.Epsilon / 2);

    }


    [TestMethod]
    //[ExpectedException(typeof(Exception))]
    public void DecimalTests()
    {
      Decimal val = 5E-29M;
      Decimal val2 = 6E-29M;
      //Assert.IsTrue(0 == val);
      //Assert.AreEqual("0.0000000000000000000000000001", val2.ToString());

      Decimal val3 = 1.111111111111111111111111111M;
      //Assert.IsTrue(1M == 1E28M * (val3 / 1E28M));
      //Assert.AreEqual("1.0000000000000000000000000000", (1E28M * (val3 / 1E28M)).ToString());
      //Assert.IsTrue(0 == 1E28M * (val3 / 7.9E28M));
    }

    [TestMethod]
    //[ExpectedException(typeof(Exception))]
    public void PositiveNegativeInfinityAndConversions()
    {
      Single zero = 0F;
      Single negativeZero = -0F;
      Double largeDouble = 1E200;
      Double smallDouble = 1E-200;
      Double largeNegativeDouble = -1E200;
      //Assert.AreEqual(zero, Convert.ToSingle(smallDouble));
      //Assert.AreEqual(Single.NegativeInfinity, Convert.ToSingle(largeNegativeDouble));
      //Assert.AreEqual(Single.PositiveInfinity, Convert.ToSingle(largeDouble));
    }

    [TestMethod]
    //[ExpectedException(typeof(Exception))]
    public void PositiveNegativeInfinityMethods()
    {
      Single zero = 0F;
      Single negativeZero = -0F;
      //Assert.IsTrue(Single.PositiveInfinity == 3 / zero);
      //Assert.IsTrue(Single.NegativeInfinity == 3 / negativeZero);
      //Assert.IsTrue(Double.IsPositiveInfinity(Single.PositiveInfinity));
      //Assert.IsTrue(Double.PositiveInfinity == Single.PositiveInfinity);
      //Assert.IsTrue(Single.PositiveInfinity == Double.PositiveInfinity);
      //Assert.IsFalse(Double.IsPositiveInfinity(Single.NegativeInfinity));
      //Assert.IsFalse(Double.PositiveInfinity == Single.NegativeInfinity);
      //Assert.IsFalse(Double.PositiveInfinity == Double.NegativeInfinity);
      //Assert.IsTrue(-1 * Single.PositiveInfinity == Single.NegativeInfinity);
      //Assert.IsTrue(Single.PositiveInfinity / 0 == Single.PositiveInfinity);
      //Assert.IsTrue(0 / Single.PositiveInfinity == 0);
    }

    [TestMethod]
    public void FloatingPointEqualityTests()
    {
Assert.AreNotEqual(Math.Round(4.222499F, 3), Math.Round(4.222501F, 3));
Assert.AreEqual(Math.Round(4.222399F, 3), Math.Round(4.222401F, 3));

      //Assert.IsTrue(FixedPrecisionEquals (4.222499F, 4.222501F, 3));
      //Assert.IsTrue(FixedPrecisionEquals(4.222399F, 4.222401F, 3));

      //Assert.IsTrue(FuzzyEquals(0F, .00000001F, 6, 8));
      //Assert.IsTrue(FuzzyEquals(1E-10F, .00000001F, 6, 8));
      //Assert.IsTrue(FuzzyEquals(0F, .00000000000001F, 6));
      //Assert.IsTrue(FuzzyEquals(.000004222499F, .000004222501F, 6));
      //Assert.IsTrue(FuzzyEquals(4.222499F, 4.222501F, 6));
      //Assert.IsTrue(FuzzyEquals(4222499F, 4222501F, 6));

      //Assert.IsFalse(FuzzyEquals(0F, .00000001F, 6, 10));
      //Assert.IsFalse(FuzzyEquals(1E-10F, .00000001F, 6, 10));
      //Assert.IsFalse(FuzzyEquals(4.223499F, 4.222501F, 6));
      //Assert.IsFalse(FuzzyEquals(.000004223499F, .000004222501F, 6));
      //Assert.IsFalse(FuzzyEquals(4223499F, 4222501F, 6));
    }

public static bool FixedPrecisionEquals(double value1, double value2, int precision)
{
  var diff = Math.Abs(value1 - value2);
  var epsilon = Math.Pow(10, -1 * precision);
  return (diff < epsilon);
}

    public static bool FuzzyEquals(double value1, double value2, int precision, int decimalsNearZero = 14)
    {
      // About 17 decimal places in double: last 2 for precision 1  spare, thus the default
      if (value1.Equals(value2)) { return true; }
      if (Double.IsInfinity(value1) || Double.IsNaN(value1) || Double.IsInfinity(value2) || Double.IsNaN(value2))
        return value1.Equals(value2);
      double valNearZero = Math.Pow(10, -1 * decimalsNearZero);
      if (Math.Abs(value2) < valNearZero && Math.Abs(value1) < valNearZero) { return true; }
      double log1 = Math.Log10(value1);
      double log2 = Math.Log10(value2);
      if (Math.Abs(log1 - log2) > 1) return false;
      double log = Math.Ceiling(-1 * Math.Max(log1, log2));
      double logOffset = Math.Pow(10, log); // max or min here?
      var offset1 = logOffset * value1;
      var offset2 = logOffset * value2;
      double normalDiff = Math.Abs(value1 - value2) * logOffset;
      double diffLog = Math.Ceiling(-1 * (Math.Log10(normalDiff)));
      return (diffLog >= precision);
    }

    /// <summary>
    /// Modified from .NET help to show one of many invalid approaches to comparisons
    /// </summary>
    /// <returns>
    /// True if the values are nearly equal, UNLESS the values are near zero
    /// False if the values are not nearly equal or the values are near zero
    /// </returns>
    static bool IsApproximatelyEqualFromHelp(double value1, double value2, double epsilon)
    {
      // If they are equal anyway, just return True. 
      if (value1.Equals(value2))
        return true;

      // Handle NaN, Infinity. 
      if (Double.IsInfinity(value1) | Double.IsNaN(value1))
        return value1.Equals(value2);
      else if (Double.IsInfinity(value2) | Double.IsNaN(value2))
        return value1.Equals(value2);

      // Handle zero to avoid division by zero, if they're both zero, already handled
      double divisor = Math.Max(value1, value2);
      if (divisor.Equals(0))
        divisor = Math.Min(value1, value2);

      // WARNING: Does not manage zero in a meaningful way
      return Math.Abs(value1 - value2) / divisor <= epsilon;
    }

    [TestMethod]
    public void InfinityGreaterThanMax()
    {
      //Assert.IsTrue(double.PositiveInfinity > double.MaxValue);
    }

    //[TestMethod]
    //public void ZeroEqualZero()
    //{
    //  //Assert.IsTrue(double.zero > double.MaxValue);
    //}

  }
}
