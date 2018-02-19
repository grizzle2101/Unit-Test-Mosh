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
        [Test]
        public void CalculateDemeritPoints_SpeedOver300_ShouldRaiseException()
        {
            //Arrange
            //Act

            //Assert
            Assert.That(() => _calculator.CalculateDemeritPoints(350), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        //Normal Tests
        [Test]
        [TestCase(50, 0)]
        [TestCase(65, 0)]
        [TestCase(85, 4)]
        public void CalculateDemeritPoints_WhenCalled_ShouldReturnPointOverEvery5(int speed, int expected)
        {
            //Arrange
            //Act
            var result = _calculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
