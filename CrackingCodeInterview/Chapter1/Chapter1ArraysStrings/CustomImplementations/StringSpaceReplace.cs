using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomImplementations
{
    public class StringSpaceReplace
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString">input string comes with spaces that can fit all the replacement string</param>
        /// <param name="replacementString"></param>
        public string ReplaceSpace(string inputString, string replacementString)
        {
            int emptySpaceCount = 0;

            char[] inputStringAsArray = inputString.ToCharArray();
            int contentLength = inputString.TrimEnd().Length;

            char[] spaceReplacementString = replacementString.ToCharArray();
            

            emptySpaceCount = GetSpaceCount(contentLength, inputStringAsArray);

            int additionalSpaceCount = (replacementString.Length - 1)*emptySpaceCount;//additional space that is needed to insert the empty string

            int totalStringLength = additionalSpaceCount + contentLength;

            inputStringAsArray[totalStringLength] = '\0';

            int contentLengthIndex = contentLength - 1;
            for (int index = totalStringLength - 1; index > 0; index--)
            {
                if (inputStringAsArray[contentLengthIndex] == ' ')
                {
                    int spaceReplacementIndex = replacementString.Length - 1;
                    while (spaceReplacementIndex >= 0)
                    {
                        inputStringAsArray[index] = spaceReplacementString[spaceReplacementIndex];
                        spaceReplacementIndex--;

                        if (spaceReplacementIndex >= 0)
                            index--;
                    }
                }
                else
                {
                    inputStringAsArray[index] = inputStringAsArray[contentLengthIndex];
                }
                contentLengthIndex--;
            }
            return new String(inputStringAsArray);
        }

        private static int GetSpaceCount(int stringContentLength, char[] inputStringAsArray)
        {
            int emptySpaceCount = 0;
            for (int i = 0; i < stringContentLength; i++)
            {
                if (inputStringAsArray[i] == ' ')
                    emptySpaceCount++;
            }
            return emptySpaceCount;
        }
    }
}
