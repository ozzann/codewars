/*
Source:
http://www.codewars.com/kata/55c04b4cc56a697bb0000048

Description:
Write function scramble(str1,str2) that returns true 
if a portion of str1 characters can be rearranged to 
match str2, otherwise returns false.

For example:
1) str1 is 'rkqodlw' and str2 is 'world' 
the output should return true.
2) str1 is 'cedewaraaossoqqyt' and str2 is 'codewars' 
should return true.
3) str1 is 'katas' and str2 is 'steak' 
should return false.

Only lower case letters will be used (a-z). 
No punctuation or digits will be included.
*/

using System;

namespace Scramble
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "kataes";
            string str2 = "steakk";

            bool scramble = Scramble(str1, str2); 

            if( scramble )
            {
                Console.WriteLine("It is possible to get {0} from {1}", str2, str1);
            }
            else
            {
                Console.WriteLine("It is NOT possible to get {0} from {1}", str2, str1);
            }

            Console.ReadLine();
            
        }

        public static bool Scramble(string str1, string str2)
        {
            for(int i = 0;i < str2.Length; i++)
            {
                char currentChar = str2[i];
                int currentCharPosition = str1.IndexOf(currentChar);
                if (currentCharPosition >= 0)
                {
                    str1 = str1.Substring(0, currentCharPosition)
                        + str1.Substring(currentCharPosition + 1,str1.Length - currentCharPosition - 1);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
