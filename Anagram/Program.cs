using System;
using System.Linq;

namespace Anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bISAnagram = IsAnagram("orchestra", "carthorse");
            Console.WriteLine(bISAnagram);
        }

        static bool IsAnagram(string sWord1, string sWord2)
        {
            char[] cWord1;
            char[] cWord2;

            cWord1 = sWord1.ToLower().ToCharArray();
            cWord2 = sWord2.ToLower().ToCharArray();

            Array.Sort(cWord1);
            Array.Sort(cWord2);

            return cWord1.SequenceEqual(cWord2);

            //Or we can convert char array back to string and do the comparision again
            //sWord1 = new string(cWord1);
            //sWord2 = new string(cWord2);

            //return (sWord1 == sWord2);
            


        }
    }
}
