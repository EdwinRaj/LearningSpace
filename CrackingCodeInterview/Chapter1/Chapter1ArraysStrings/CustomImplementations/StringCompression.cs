using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomImplementations
{
    public class StringCompression
    {
        public string BetterCompression(string inputString)
        {
            var localDictionary = new Dictionary<char, int>();
            char[] inputAsArray = inputString.ToLower().ToCharArray();
            foreach (char currentCharacter in inputAsArray)
            {
                if(!localDictionary.ContainsKey(currentCharacter))
                    localDictionary.Add(currentCharacter,0);

                localDictionary[currentCharacter]++;
            }

            var builder = new StringBuilder();
            foreach (var currentKey in localDictionary.Keys)
            {
                builder.Append(currentKey);
                builder.Append(localDictionary[currentKey]);
            }

            return builder.ToString();
        }
    }
}
