/*
Source: http://www.codewars.com/kata/5226eb40316b56c8d500030f

Description:
Write a function that, given a depth (n), returns 
a single-dimensional array representing Pascal's Triangle 
to the n-th level.

For example:
PascalsTriangle(4) == new List<int> {1,1,1,1,2,1,1,3,3,1}
*/

using System;
using System.Collections.Generic;

namespace PascalsTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int level = 1;
            List<int> pascalsTriangleList = PascalsTriangle(level);

            Console.WriteLine(String.Join(" ", pascalsTriangleList.ToArray()));

            Console.ReadLine();
        }
        
        public static List<int> PascalsTriangle(int n)
        {
            int[][] pascalsTriangle = new int[n][];

            for(int j = 0;j < n; j++)
            {
                for(int i = 0;i < n; i++)
                {
                    if( j == 0 )
                    {
                        pascalsTriangle[i] = new int[i + 1];
                        pascalsTriangle[i][0] = 1;
                    }
                    else if( i == j )
                    {
                        pascalsTriangle[i][j] = 1;
                    }
                    else if( i > j )
                    {
                        pascalsTriangle[i][j] = pascalsTriangle[i - 1][j] + pascalsTriangle[i - 1][j - 1];
                    }
                }
            }

            List<int> pascalsTriangleList = new List<int>();
            for(int k = 0;k < n; k++)
            {
                int[] curr = pascalsTriangle[k];
                for(int currPos = 0;currPos < curr.Length; currPos++)
                {
                    pascalsTriangleList.Add(curr[currPos]);
                }
            }

            return pascalsTriangleList;
        }
    }
}
