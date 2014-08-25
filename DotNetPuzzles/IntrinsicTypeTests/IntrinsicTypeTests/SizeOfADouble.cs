using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntrinsicTypeTests
{
    [TestClass]
    public class SizeOfADouble
    {
// from http://www.wolframalpha.com
private Single ageOfUniverseInSec = 4.3E17F;
private Double atomsInUniverse = 1E80;
private Single obsUniverseDiamInMeters = 8.8E26F; //Obs is observable
private Double obsUniverseVolumeInM3 = 4E80;      //M3 is cubic meters
private Single numStarsInObsUniverse = 3E23F;
private Single humansOnEarthNow = 7E9F;
private Single humansEverOnEarth = 1E12F;
private Single cellsInHumanBody = 10E14F;

[TestMethod]
//[ExpectedException(typeof(Exception))]
public void BigNumberExploration()
{
    Double totPopOnEachStar = numStarsInObsUniverse * humansEverOnEarth;
    Double totalHumanCellsIfPopOnEveryStar = numStarsInObsUniverse * humansEverOnEarth 
                                                        * cellsInHumanBody;
    Double massiveBurps = numStarsInObsUniverse * humansEverOnEarth
                           * cellsInHumanBody * ageOfUniverseInSec * 1000;
    Double totalAtomsInUniverseInEveryMeter = atomsInUniverse * obsUniverseVolumeInM3;
    Double bigNumber = atomsInUniverse * 1E100;
    Double evenBiggerNumber = atomsInUniverse * 1E200;
    Double reallyBigNumber = atomsInUniverse * 1E300;
}



[TestMethod]
//[ExpectedException(typeof(Exception))]
public void BigNumberExploration2()
{
    Double bigNumber = atomsInUniverse * 1E100;
    Double evenBiggerNumber = atomsInUniverse * 1E200;
    Double reallyBigNumber = atomsInUniverse * 1E300;
    Double recalculateOne = reallyBigNumber / reallyBigNumber;
    //Assert.AreEqual(1, Math.Round(bigNumber / bigNumber, 5));
    //Assert.AreEqual(1, Math.Round(recalculateOne, 5));
}

[TestMethod]
//[ExpectedException(typeof(Exception))]
public void FloatingDivision()
{
    Single three = 3F;
    Single zero = 0F;
    Single result = three / zero;
    //Assert.IsTrue(result == 0);
    //Assert.IsTrue(result < 0);
    //Assert.IsTrue(result > 0);
}



    }
}
