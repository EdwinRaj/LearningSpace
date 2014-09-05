    using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntrinsicTypeTests
{
    [TestClass]
    public class DivideByZero
    {
        /// <summary>
        /// Straight forward case. Divide by zero occurs
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (DivideByZeroException))]
        public void DivideByZeroInteger()
        {
            int three = 3;
            int zero = 0;
            int result = three/zero;
            //Assert.AreEqual(0, result);
        }


        /// <summary>
        /// Exception occurs in this case as well
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (DivideByZeroException))]
        public void DivideByZeroDecimal()
        {
            Decimal three = 3;
            Decimal zero = 0;
            Decimal result = three/zero;
            //Assert.AreEqual(0, result);
        }

        /// <summary>
        /// In this case, the result gets the value of Infinity
        /// Important take away: Double and Single Never through exceptions because of mathematical calculations
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroDouble()
        {
            Double three = 3;
            Double zero = 0;
            Double result = three/zero;
            //Assert.AreEqual(0, result);
            //Assert.AreEqual(Double.PositiveInfinity , result);
        }
    }
}
