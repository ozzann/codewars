/*

"Roman Numerals Decoder"

Create a function that takes a Roman numeral as its argument 
and returns its value as a numeric decimal integer. 
You don't need to validate the form of the Roman numeral.

Modern Roman numerals are written by expressing each decimal digit 
of the number to be encoded separately, starting with the leftmost digit 
and skipping any 0s. So 1990 is rendered "MCMXC" (1000 = M, 900 = CM, 90 = XC) 
and 2008 is rendered "MMVIII" (2000 = MM, 8 = VIII). 
The Roman numeral for 1666, "MDCLXVI", uses each letter in descending order.

Example:
DecodeRoman("XXI") -- should return 21

Source: http://www.codewars.com/kata/51b6249c4612257ac0000005
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args) { 
            string [] testRomanNumerals = { "MCMXC", "XXI", "MDCLXVI", "II", "I", "V" };

            for (int i = 0;i < testRomanNumerals.Length;i++)
            {
                string romanNumeral = testRomanNumerals[i];
                int decodedRoman = DecodeRoman(romanNumeral);

                Console.WriteLine("{0} is equal to {1}", romanNumeral, decodedRoman);
            }

            Console.ReadLine();

        }

        public static int DecodeRoman(string roman)
        {

            Dictionary<string, int> romanNumerals =
                new Dictionary<string, int>();

            romanNumerals.Add("I", 1);
            romanNumerals.Add("V", 5);
            romanNumerals.Add("X", 10);
            romanNumerals.Add("L", 50);
            romanNumerals.Add("C", 100);
            romanNumerals.Add("D", 500);
            romanNumerals.Add("M", 1000);

            int number = 0;
            for( int i = roman.Length - 1;i >= 0;i-- )
            {
                int romanNumeral;
                romanNumerals.TryGetValue(roman.Substring(i, 1), out romanNumeral);
                if( i == roman.Length - 1 )
                {
                    number += romanNumeral;
                }
                else
                {
                    int nextRomanNumeral;
                    romanNumerals.TryGetValue(roman.Substring(i + 1, 1), out nextRomanNumeral);
                    if( nextRomanNumeral > romanNumeral )
                    {
                        number -= romanNumeral;
                    }
                    else
                    {
                        number += romanNumeral;
                    }
                }
            }

            return number;
        }
    }
}
