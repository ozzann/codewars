/*
Source: http://www.codewars.com/kata/5259510fc76e59579e0009d4

Description:
You'll get an entered term (lowercase string) and an array of 
known words (also lowercase strings). Your task is to find out, 
which word from the dictionary is most similar to the entered one. 
The similarity is described by the minimum number of letters you 
have to add, remove or replace in order to get from the entered word 
to one of the dictionary. The lower the number of required changes, 
the higher the similarity between each two words.

Examples:
var fruits = new Kata(new List<string> { "cherry", "pineapple", "melon", "strawberry", "raspberry" });
// must return "strawberry"
fruits.FindMostSimilar("strawbery"); 
// must return "cherry"
fruits.FindMostSimilar("berry"); 

languages = new Dictionary(new List<string> { "javascript", "java", "ruby", "php", "python", "coffeescript" });
// must return "java"
languages.FindMostSimilar("heaven"); 
// must return "javascript" (same words are obviously the most similar ones)
languages.FindMostSimilar("javascript"); 
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyMatching
{
    class Program
    {
        static void Main(string[] args)
        {

            Kata kata = new Kata(new List<string> { "javascript", "java", "ruby", "php", "python", "coffeescript" });
            string term = "heaven";
            string mostSimilar = kata.FindMostSimilar(term);

            Console.WriteLine("{0} is the most similar for {1}", mostSimilar, term);

            Console.ReadLine();
        }
    }

    public class Kata
    {

        private IEnumerable<string> words;

        public Kata(IEnumerable<string> words)
        {
            this.words = words;
        }

        public string FindMostSimilar(string term)
        {
            string mostSimilar = "";
            int minDistance = words.Max(w => w.Length);

            foreach(var word in words)
            {
                int currDistance = GetLevenshteinDistance(word, term);
                if( currDistance < minDistance)
                {
                    minDistance = currDistance;
                    mostSimilar = word;
                }
            }

            return mostSimilar;
        }

        public static int GetLevenshteinDistance(string pattern, string word)
        {
            int[,] LevenshteinMatrix = new int[pattern.Length + 1, word.Length + 1];

            for (int i = 0; i < pattern.Length + 1; i++)
            {
                for (int j = 0; j < word.Length + 1; j++)
                {
                    if (Math.Min(i, j) == 0)
                    {
                        LevenshteinMatrix[i, j] = Math.Max(i, j);
                    }
                    else
                    {
                        LevenshteinMatrix[i, j] = word[j - 1] == pattern[i - 1] ?
                            LevenshteinMatrix[i - 1, j - 1] :
                            LevenshteinMatrix[i - 1, j - 1] + 1;
                        LevenshteinMatrix[i, j] = Math.Min(
                            LevenshteinMatrix[i, j],
                            Math.Min(
                                LevenshteinMatrix[i, j - 1] + 1,
                                LevenshteinMatrix[i - 1, j] + 1
                            )
                        );
                    }
                }
            }

            int distance = LevenshteinMatrix[pattern.Length, word.Length];
            return distance;
        }
    }
}
