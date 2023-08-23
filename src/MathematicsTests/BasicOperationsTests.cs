using FluentAssertions;
using Mathematics;
using NUnit.Framework;
using System;

namespace MathematicsTests
{
    [TestFixture]
    public class BasicOperationsTests
    {
        //TODO::CHECK Mathematics.csproj

        [TestCase]
        public void AddTest_UltraMegaSuper_ExpectSuccess()
        {
            int expected = 9;
            var result = MathUtilsSimple.Add(2, 7);

            Assert.True(true);
        }

        [TestCase]
        public void AddTest_TwoPlusSeven_ExpectSuccess()
        {
            int expected = 9;
            var result = MathUtilsSimple.Add(2, 7);

            Assert.AreEqual(expected, result);
        }

        [TestCase(1, 1, 2)]
        public void ParametrizedAddTest_ExpectSuccess(int a, int b, int expected)
        {
            var result = MathUtilsSimple.Add(a, b);
            Assert.That(result, Is.EqualTo(expected)); //fluent assertion
        }


        [TestCase(1, 1, 0)]
        public void ParametrizedSubTest_ExpectSuccess(int a, int b, int expected)
        {
            var result = MathUtilsSimple.Sub(a, b);
            Assert.That(result, Is.EqualTo(expected)); 
        }


        [TestCase(1, 1, 1)]
        public void ParametrizedMulTest_ExpectSuccess(int a, int b, int expected)
        {
            var result = MathUtilsSimple.Mul(a, b);
            Assert.That(result, Is.EqualTo(expected)); 
        }



        [TestCase(1, 1, 1)]
        public void ParametrizedDivTest_ExpectSuccess(int a, int b, int expected)
        {
            var result = MathUtilsSimple.Div(a, b);
            Assert.That(result, Is.EqualTo(expected)); 
        }


        [TestCase(1, 0)]
        public void ParametrizedDivTest_ExpectException(int a, int b)
        {
            Assert.Throws<ArgumentException>(()=>MathUtilsSimple.Div(a, b));
        }

        [TestCase(3, 6)]
        [TestCase(0, 1)]
        public void ParametrizedFactRecursionTest_ExpectSuccess(int a, int expected)
        {
            var result = MathUtilsSimple.FactRecursion(a);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(3, 6)]
        [TestCase(0, 1)]
        public void ParametrizedFactLoopTest_ExpectSuccess(int a, int expected)
        {
            var result = MathUtilsSimple.FactLoop(a);
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}