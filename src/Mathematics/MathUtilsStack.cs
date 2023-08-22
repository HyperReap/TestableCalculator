using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

namespace Mathematics
{
    //TODO:: (Optional) If you want you can try implementing Mathematics for multiple numbers in row,
    //just change Maths in MainWindows.xaml.cs and ti will use this class instead
    // you can try to implement it in the same manner as MathUtilsSimple
    public class MathUtilsStack : MathBase
    {
        private Stack<double> values;
        private Stack<string> operators;

        /// <summary>
        /// Parses tokens and calculates them according to priority of operations
        /// </summary>
        /// <param name="tokens">list of string tokens -> numbers, operators</param>
        /// <returns>Result of operation</returns>
        internal double CalculateStack(List<string> tokens)
        {
            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double value))
                {
                    values.Push(value);
                }
                else if (IsOperator(token))
                {
                    while (operators.Count > 0 && GetPriority(operators.Peek()) >= GetPriority(token))
                    {
                        ExecuteSingleOperation();
                    }
                    operators.Push(token);
                }
            }

            while (operators.Count > 0)
            {
                ExecuteSingleOperation();
            }


            return values.Peek();
        }

        /// <summary>
        /// Evaluates incoming equation using STACK
        /// </summary>
        /// <param name="input">incoming equation as string</param>
        /// <returns>result of evaluation or error message</returns>
        public string Evaluate(string input)
        {
            values = new Stack<double>();
            operators = new Stack<string>();

            double result = 0;

            var errorMsg = CheckInputSyntax(input);
            if (string.IsNullOrEmpty(errorMsg))
                return errorMsg;

            var tokens = Tokenize(input);
            result = CalculateStack(tokens);

            return result.ToString();
        }

        private void ExecuteSingleOperation()
        {

        }

        internal string CheckInputSyntax(string input)
        {
            return "";
        }
    }
}