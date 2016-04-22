/*
Source: http://www.codewars.com/kata/520b9d2ad5c005041100000f

Description:
Modify input string this way:
move the first letter of each word to the end of it, 
then add 'ay' to the end of the word.

PigIt("Pig latin is cool") should return  "igPay atinlay siay oolcay"
*/

using System;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] testStrings = { "Pig latin is cool", "This is my string" };
            for (int num = 0; num < testStrings.Length; num++)
            {
                string pigStr = PigIt(testStrings[num]);

                Console.WriteLine("For {0} Pig Latin is {1}", testStrings[num], pigStr);
            }
            
            Console.ReadLine();
        }
        
        public static string PigIt(string str)
        {

            string[] words = str.Split(' ');
            string pigStr = "";

            string specialString = "ay";

            for(int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                string newStr = currentWord.Substring(1);

                newStr += currentWord.Substring(0, 1) + specialString;

                pigStr += newStr + " ";
            }

            pigStr = pigStr.Substring(0, pigStr.Length - 1);

            return pigStr;
        }
    }
  }
