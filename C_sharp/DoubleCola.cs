/*
Source: http://www.codewars.com/kata/551dd1f424b7a4cdae0001f0

Description:
Sheldon, Leonard, Penny, Rajesh and Howard are in the queue 
for a "Double Cola" drink vending machine; there are no other people in the queue. 
The first one in the queue (Sheldon) buys a can, drinks it and doubles! 
The resulting two Sheldons go to the end of the queue. 
Then the next in the queue (Leonard) buys a can, drinks it and 
gets to the end of the queue as two Leonards, and so on.

For example, Penny drinks the third can of cola and the queue 
will look like this:
Rajesh, Howard, Sheldon, Sheldon, Leonard, Leonard, Penny, Penny

Write a program that will return the name of a man who will 
drink the n-th cola.
The input data consist of an array which contains five names, 
and single integer n.

Examples:

Return the single line — the name of the person who drinks the n-th can of cola. 

 string[] names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
 int n = 1;
 Line.WhoIsNext(names, n) --> "Sheldon"

 int n = 6;
 Line.WhoIsNext(names, n) --> "Sheldon"

 int n = 52;
 Line.WhoIsNext(names, n) --> "Penny"

 int n = 7230702951;
 Line.WhoIsNext(names, n) --> "Leonard"

*/

using System;

namespace DoubleCola
{
    class Program
    {
        static void Main(string[] args)
        {
        	string[] names = new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };

            long[] testNumbers = { 1, 6, 52, 7230702951 };
            for(int num = 0; num < testNumbers.Length; num++)
            {
                string nextPerson = WhoIsNext(names, testNumbers[num]);

                Console.WriteLine("Next person who will take {0}-th cola is  {1}", 
                    testNumbers[num], nextPerson);
            }
            
            Console.ReadLine();
        }
        
        public static string WhoIsNext(string[] names, long n)
        {
            long number = names.Length;

            string[] namesCircle = new string[number + 1];
            for(long p = 0;p < number; p++)
            {
                namesCircle[p] = names[p];
            }
            namesCircle[number] = names[0];

            long doubles = 0;
            long start = 1;
            long delta = 1;
            string nextPerson = "";
            while (nextPerson == "" )
            {
                long begin = start;
                for ( int i = 0; i < number; i++)
                {
                    if ( ( delta == 1 && n == begin ) 
                        || ( n >= begin && n < begin + delta - 1 ) )
                    {
                        return namesCircle[i];
                    }
                    else if( n == begin + delta - 1)
                    {
                        return namesCircle[i + 1];
                    }
                    begin += delta;
                }
                start += number * (long)Math.Pow(2, doubles);
                doubles++;
                delta = (long)Math.Pow(2, doubles);
                
            }

            return nextPerson;
        }
    }
  }
