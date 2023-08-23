using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics
{
    public class MathBase
    {
        public enum OperationsEnum
        {
            add,
            sub,
            mul,
            div,
            fact
        }

        //TODO:: (Optional) define and implement more operations
        protected string[] Operations = { "+", "-", "*", "/", "!" };

        /// <summary>
        /// Splits input equation into operators and numbers
        ///  1 + 2 - 3 -> values: 1,2,3     operators: +,-
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal List<string> Tokenize(string input)
        {
            var ops = input
                .Where(x => IsOperator(x.ToString()))
                .Select(c => c.ToString())
                .ToList();

            var list = new List<string>(input.Split(Operations, StringSplitOptions.RemoveEmptyEntries));

            return Enumerable.Range(0, list.Count)
            .SelectMany(i => list.Skip(i).Take(1).Concat(ops.Skip(i).Take(1)))
            .ToList();
        }

        // Priority for STACK calculator
        internal int GetPriority(string op)
        {
            switch (GetOperationEnum(op))
            {
                case OperationsEnum.add:
                case OperationsEnum.sub:
                    return 1;
                case OperationsEnum.mul:
                case OperationsEnum.div:
                    return 2;
                case OperationsEnum.fact:
                    return 3;
                default:
                    return 0;
            }
        }
        // Some methods you can use to refactor
        internal static OperationsEnum GetOperationEnum(string op)
        {
            switch (op)
            {
                case "+":
                    return OperationsEnum.add;
                case "-":
                    return OperationsEnum.sub;
                case "*":
                    return OperationsEnum.mul;
                case "/":
                    return OperationsEnum.div;
                case "!":
                    return OperationsEnum.fact;
                default:
                    throw new ArgumentException($"Operation '{op}' is not yet implemented");
            }
        }


        //used in CalculateStack, Tokenize, and now CHeckInput
        internal bool IsOperator(string token)
        {
            return Operations.Any(x => x == token);
        }

        internal static double Add(double a, double b)
        {
            return a + b;
        }

        internal static double Sub(double a, double b)
        {
            return a - b;
        }

        internal static double Mul(double a, double b)
        {
            return a * b;
        }

        internal static double Div(double a, double b)
        {
            if (b == 0)
                throw new ArgumentException("Cannot divide by zero");

            return a / b;
        }

        internal static int FactLoop(int a)
        {
            int result = 1;
            while (a > 1)
            {
                result *= a;
                a--;
            }

            return result;
        }

        internal static int FactRecursion(int a)
        {
            if (a < 2)
            {
                return 1;
            }
            else
            {
                return a * FactRecursion(a - 1);
            }
        }

    }
}
