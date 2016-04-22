/*
Source: http://www.codewars.com/kata/517abf86da9663f1d2000003

Description:
Complete the method so that it converts dash/underscore 
delimited words into camel casing. The first word within 
the output should be capitalized only if the original 
word was capitalized.

Examples:

// returns "theStealthWarrior"
ToCamelCase("the-stealth-warrior") 

// returns "TheStealthWarrior"
ToCamelCase("The_Stealth_Warrior")
*/
using System;
using System.Text.RegularExpressions;

namespace CamelCase
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] testCamelStrings = { "the-stealth-warrior", "The_Stealth_Warrior" };
            for (int num = 0; num < testCamelStrings.Length; num++)
            {
                string camelStr = ToCamelCase(testCamelStrings[num]);

                Console.WriteLine("For {0} camel case is {1}", testCamelStrings[num], camelStr);
            }

            Console.ReadLine();
        }
        
        public static string ToCamelCase(string str)
        {

            str = Regex.Replace(str, @"[-|_]([a-zA-Z])", m => "" + m.ToString().ToUpper());
            str = Regex.Replace(str, @"[-|_]", m => "");
            return str;
        }
    }
  }
