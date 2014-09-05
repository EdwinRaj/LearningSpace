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
    public class StringUniqueTests
    {
        [Test]
        public void TestUniqueStringApproach1()
        {
            var instanceStringUnique = new StringUnique();
            string currentString = "Edwin Arockiaraj";
            bool isStringUnique = instanceStringUnique.IsStringUnique(currentString);
            Console.WriteLine("Is String {0} Unique: {1}",currentString,isStringUnique);
            
            currentString = "Alwyn Jesu";
            isStringUnique = instanceStringUnique.IsStringUnique(currentString);
            Console.WriteLine("Is String {0} Unique: {1}", currentString, isStringUnique);

        }

        [Test]
        public void TestUniqueStringAdvancedApproach()
        {
            var instanceStringUnique = new StringUnique();
            string currentString = "Edwin Arockiaraj";
            bool isStringUnique = instanceStringUnique.IsStringUniqueAdvancedMethod(currentString);
            Console.WriteLine("Is String {0} Unique: {1}", currentString, isStringUnique);

            currentString = "Alwyn Jesu";
            isStringUnique = instanceStringUnique.IsStringUniqueAdvancedMethod(currentString);
            Console.WriteLine("Is String {0} Unique: {1}", currentString, isStringUnique);

            currentString = "abcdefghijklmnopqrstuvwxyz";
            isStringUnique = instanceStringUnique.IsStringUniqueAdvancedMethod(currentString);
            Console.WriteLine("Is String {0} Unique: {1}", currentString, isStringUnique);

        }
    }
}
