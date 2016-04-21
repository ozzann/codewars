/*

Source: http://www.codewars.com/kata/52685f7382004e774f0001f7

Description:
Write a function, which takes a non-negative integer (seconds) 
as input and returns the time in a human-readable format (HH:MM:SS)

HH = hours, padded to 2 digits, range: 00 - 99
MM = minutes, padded to 2 digits, range: 00 - 59
SS = seconds, padded to 2 digits, range: 00 - 59
The maximum time never exceeds 359999 (99:59:59)

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeFormat
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        
        public static string GetReadableTime(int seconds)
        {
            string timeStr = "";

            int knownTime = 0;
            for (int i = 2; i >= 0; i--)
            {
                int timeInSeconds = (int)Math.Pow(60, i);

                int part = (int)Math.Truncate((double) ( seconds - knownTime ) / timeInSeconds);
                string partStr = part.ToString();
                if( part < 10 )
                {
                    partStr = "0" + partStr;
                }

                timeStr += partStr + ":";

                knownTime += timeInSeconds * part;
            }

            timeStr = timeStr.Substring(0, timeStr.Length - 1);

            return timeStr;
        }
    }
}
