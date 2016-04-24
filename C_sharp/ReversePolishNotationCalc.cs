/*
Source: http://www.codewars.com/kata/52f78966747862fc9a0009ae

Description:
Your job is to create a calculator which evaluates 
expressions in Reverse Polish notation.

For example expression 5 1 2 + 4 * + 3 - (which is 
equivalent to 5 + ((1 + 2) * 4) - 3 in normal notation) 
should evaluate to 14.

Empty expression should evaluate to 0.

Valid operations are +, -, *, /.
*/
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;

namespace ReversePolishNotationCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            string testExpr = "1 2 3.5";
            double result = evaluate(testExpr);

            Console.WriteLine("{0} equals to {1}", testExpr, result);

            Console.ReadLine();
        }
        
        public static double evaluate(String expr)
        {
            List<string> operators = new List<string>{ "+", "*", "-", "/"};

            List<string> exprList = expr.Split(new Char[] { ' ' } ).ToList();

            double result = 0.0;
            while(exprList.ToArray().Length > 1)
            {
                int i = 0;
                while( i < exprList.ToArray().Length)
                {
                    string current = exprList[i];
                    if( operators.IndexOf(current) >= 0 )
                    {
                        double operator1 = exprList[i - 2] == "x" ?
                            result : Convert.ToDouble(exprList[i - 2], CultureInfo.InvariantCulture);

                        double operator2 = exprList[i - 1] == "x" ?
                            result : Convert.ToDouble(exprList[i - 1], CultureInfo.InvariantCulture);

                        switch (current)
                        {
                            case "+":
                                result = operator1 + operator2;
                                break;
                            case "-":
                                result = operator1 - operator2;
                                break;
                            case "*":
                                result = operator1 * operator2;
                                break;
                            case "/":
                                result = operator1 / operator2;
                                break;
                        }

                        exprList[i - 2] = "x";
                        exprList.RemoveAt(i);
                        exprList.RemoveAt(i - 1);

                        i = exprList.ToArray().Length;
                    }
                    else
                    {
                        i++;
                    }
                }

                if (String.Join(" ", exprList.ToArray()) == expr && expr != "")
                {
                    return Convert.ToDouble(exprList.Last(), CultureInfo.InvariantCulture);
                }
            }

            return result;
        }
    }
}
        
        
