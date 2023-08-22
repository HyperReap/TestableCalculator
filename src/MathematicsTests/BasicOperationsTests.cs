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

        //TODO:: (1) add more tests for different operations

    }
}