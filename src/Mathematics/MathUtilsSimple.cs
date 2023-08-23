using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Mathematics
{
    public class MathUtilsSimple : MathBase
    {
        // WorkShop start Here

        /// <summary>
        /// Evaluates incoming equation
        /// Meant to be used with single operation
        /// </summary>
        /// <param name="input">incoming equation as string</param>
        /// <returns>result of evaluation or error message</returns>
        public string Evaluate(string input)
        {
            double a = 0;
            double b = 0;

            var errorMsg = CheckInputSyntax(input);
            if (!string.IsNullOrEmpty(errorMsg))
                return errorMsg;

            var tokens = Tokenize(input);
            if (tokens.Count > 3)
            {
                return "Too many tokens, you may perform only single operation.";
            }

            double.TryParse(tokens[0], out a);
            if(tokens.Count == 3)
                double.TryParse(tokens[2], out b);

            double result = ExecuteSingleOperation(a, b, tokens[1]);

            return result.ToString();
        }

        internal string CheckInputSyntax(string input)
        {
            if (input.Length < 2)
                return "Not complete equation to calculate anything";
            
            if (input.Last().Equals("!"))
                return "";

            var lastSeen = 'a';
            foreach (char c in input)
            {
                if (IsOperator(c.ToString()) && IsOperator(lastSeen.ToString()))
                {
                    return "Error: Two or more operators after each other";
                }
                lastSeen = c;
            }

            return "";
        }

        //TODO:: (Optional) Refactor 
        private double ExecuteSingleOperation(double a, double b, string op)
        {
            double result = 0;

            if (op == "+")
                result = Add(b, a); 
            if (op == "-")
                result = Sub(a,b);
            if (op == "/")
                result = Div(a,b);
            if (op == "*")
                result = Mul(a,b);
            if (op == "!")
            {
                int num = Convert.ToInt32(a);
                result = FactLoop(num);
            }

            return result;
        }


    }
}