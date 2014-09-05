using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomImplementations
{
    /// <summary>
    /// This class tests if the input string has got unique characters
    /// </summary>
    public class StringUnique
    {
        public bool IsStringUnique(string inputString)
        {
            //Assume string is ASCII. If string length is greater than 256, it cant be unique then
            if (inputString.Length > 256)
                return false;

            var characterArray = new bool[255];
            char[] inputStringAsArray = inputString.ToCharArray();

            foreach (char currentCharacter in inputStringAsArray)
            {
                int charAsInt = currentCharacter;//Note. here an implicit conversion of char to int happens

                if (characterArray[charAsInt])
                {
                    return false;
                }
                characterArray[charAsInt] = true;
            }

            return true;
        }

        /// <summary>
        /// checks the unique string using advanced bit wise operation method
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public bool IsStringUniqueAdvancedMethod(string inputString)
        {
            //Assume string consist only of lowercharacters
            inputString = inputString.ToLower();

            //since string with lower characters cannot be greater than 26
            if (inputString.Length > 26)
                return false;

            char[] inputAsCharArray = inputString.ToCharArray();


            int checker = 0;//bit that holds position of each character

            foreach (char currentChar in inputAsCharArray)
            {
                int valueAsInt = currentChar - 'a';//Reducing the count to max of 26

                int shiftedByChar = (1 << valueAsInt);

                if ((checker & shiftedByChar) > 0)
                    return false;
             
                checker = checker | shiftedByChar;
            }
            return true;
        }
    }
}
