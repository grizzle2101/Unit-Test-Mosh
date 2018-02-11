//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        //[Ignore("Becuase i Wanted to...")]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            //Act
            var result = _math.Add(1, 2);

            //Assert
            //Bad Assertion - Unreliable Test
            //Assert.That(_math, Is.Not.Null);

            //Correct Assertion - Reliable Test
            Assert.That(result, Is.EqualTo(3));
        }

        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ShoulReturnGreaterArgument(int a, int b, int expectedResult)
        {
            //Act
            var result = _math.Max(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            
        }

        //Section 3 - Tutorial 3 - Testing Arrays
        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ShouldReturnOddNumbersUpToLimit()
        {
            //Act
            var result = _math.GetOddNumbers(5);

            //Assert
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5}));
        }

        [Test]
        public void GetOddNumbers_LimitIsLessThanZero_ShouldReturnEmptyArray()
        {
            //Act
            var result = _math.GetOddNumbers(-5);

            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetOddNumbers_LimitIsZero_ShouldReturnEmptyArray()
        {
            //Act
            var result = _math.GetOddNumbers(0);

            //Assert
            Assert.That(result, Is.Empty);
        }
    }
}
