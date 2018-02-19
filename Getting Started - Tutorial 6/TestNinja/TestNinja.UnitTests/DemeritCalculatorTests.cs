using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    //Section 4 - Tutorial 3 - DermitCalculator
    //Task 1 - Setup Test
    //Task 2 - Detail Test Cases
    //-Over the Speed Limit
    //-Under the Speed Limit
    //-Same as SpeedLimit
    //Exception Handling - Speed of over 300

    //Task 3 - Implement Test Cases
    //Test 4 - Refactor if Neccessary

    //Task 1 - Setup Test
    [TestFixture]
    public class DemeritCalculatorTests
    {
        private DemeritPointsCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new DemeritPointsCalculator();
        }

        //Exception Handling
        //Mosh - Scenario with a Negative Value
        //Mosh - Paramerize for Multiple Tests
        //Mosh - Make more generic
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedisOutOfRange_ShouldThrowArgumentOutOfRangeException(int value)
        {
            //Arrange
            //Act

            //Assert
            Assert.That(() => _calculator.CalculateDemeritPoints(value), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        ////Scenario with speed over 300
        ////Don't need this Test anymore.
        //[Test]
        //public void CalculateDemeritPoints_SpeedOver300_ShouldRaiseException()
        //{
        //    //Arrange
        //    //Act

        //    //Assert
        //    Assert.That(() => _calculator.CalculateDemeritPoints(301), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        //}

        //Normal Tests
        //Mosh - Make Method name more Generic
        //Mosh - 3 Tests Cases (0, 64, 65, 66, 70, 75)
        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemitPoints(int speed, int expected)
        {
            //Arrange
            //Act
            var result = _calculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
