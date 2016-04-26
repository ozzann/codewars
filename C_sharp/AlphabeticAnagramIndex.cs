/*
Description:
Find the position of the given permutation in the 
sorted list of the permutations of the original string.

Examples:
ABAB = 2
AAAB = 1
BAAA = 4
QUESTION = 24572
BOOKKEEPER = 10743
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AlphabeticAnagramsIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "FXMNRCVCNNUGUAT";
            long position = ListPosition(word);
            Console.WriteLine("{0} is on {1} position", word, position);

            Console.ReadLine();
        }

        public static long ListPosition(string word)
        {
            char[] letters = word.ToCharArray();
            Array.Sort(letters);
            string sortedWord = String.Join("", letters);

            int i = 0;
            while ( i < word.Length 
                && sortedWord[i] == word[i])
            {
                i++;
            }
            int startPos = i;
            int endPos = word.Length - 1;

            long position = 1;
            if( endPos <= startPos)
            {
                return position;
            }
            sortedWord = sortedWord.Substring(startPos, endPos - startPos + 1);
            word = word.Substring(startPos, endPos - startPos + 1);

            for (int j = 0; j <= endPos - startPos; j++)
            {
                char currLetter = word[j];

                string sortedWithoutDublicates = RemoveDublicates(sortedWord);
                int k = 0;
                while( k < sortedWithoutDublicates.Length 
                    && sortedWithoutDublicates[k] != currLetter)
                {
                    int index = sortedWord.IndexOf(sortedWithoutDublicates[k]);
                    string currStortedWordPart = sortedWord.Substring(0, index)
                        + sortedWord.Substring(index + 1);
                    long currPermNumber = PermutationsNumber(currStortedWordPart);

                    position += currPermNumber;

                    k++;
                }

                int currLetterIndex = sortedWord.IndexOf(currLetter);
                sortedWord = sortedWord.Substring(0, currLetterIndex) + 
                    sortedWord.Substring(currLetterIndex + 1);
            }

            return position;
        }

        public static long Factorial(int n)
        {
            return n == 0 ? 1 : Factorial(n - 1) * n;
        }

        public static string RemoveDublicates(string s)
        {

            Dictionary<char, int> frequencies = GetFrequencies(s);
            string newStr = String.Join("", frequencies.Keys);

            return newStr;
        }

        public static long PermutationsNumber(string word)
        {
            char[] letters = word.ToCharArray();
            Array.Sort(letters);

            long denominator = 1;
            Dictionary<char, int> frequencies = GetFrequencies(word);
            foreach( var letter in frequencies.Keys )
            {
                int frequence;
                frequencies.TryGetValue(letter, out frequence);
                denominator *= Factorial(frequence);
            }

            long permutationsNumber = Factorial(word.Length) / denominator;

            return permutationsNumber;
        }

        public static Dictionary<char, int> GetFrequencies(string word)
        {
            char[] letters = word.ToCharArray();
            Array.Sort(letters);

            Dictionary<char, int> frequencies = new Dictionary<char, int> { };

            int i = 0;
            while (i < letters.Length)
            {
                char currLetter = letters[i];
                int currLetterFrequence;
                if( !frequencies.TryGetValue(currLetter, out currLetterFrequence) )
                {
                    string tmpStr = word;
                    tmpStr = Regex.Replace(word, @"" + currLetter + @"", m => "");

                    int counter = word.Length - tmpStr.Length;
                    frequencies.Add(currLetter, counter);
                }
                i++;
            }

            return frequencies;
        }


    }
}
