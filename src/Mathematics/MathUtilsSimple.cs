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

        //TODO:: (4) implement checkInputSyntax
        internal string CheckInputSyntax(string input)
        {
            return "";
        }

        //TODO:: (3) use methods from MathBase  
        //TODO:: (5) Add operation for factorial
        //TODO:: (Optional) Refactor 
        private double ExecuteSingleOperation(double a, double b, string op)
        {
            double result = 0;

            if (op == "+")
                result = Add(b, a); 
            if (op == "-")
                result = a - b;
            if (op == "/")
                result = a / b;
            if (op == "*")
                result = a * b;

            return result;
        }


    }
}