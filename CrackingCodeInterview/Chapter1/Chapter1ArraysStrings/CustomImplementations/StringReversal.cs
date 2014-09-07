using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomImplementations
{
    public class StringReversal
    {
        public string Reverse(string input)
        {
            int stringLength = input.Length;
            char[] inputAsCharArray = input.ToCharArray();
            int startIndex = 0, endIndex = stringLength - 1;

            while (startIndex < endIndex)
            {
                char temp = inputAsCharArray[endIndex];
                inputAsCharArray[endIndex] = inputAsCharArray[startIndex];
                inputAsCharArray[startIndex] = temp;
                startIndex++;
                endIndex --;
            }

            return new string(inputAsCharArray);

        }
    }
}
