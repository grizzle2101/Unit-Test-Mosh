//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    //Task 1 - Create MathTests Class
    [TestFixture]
    public class MathTests
    {
        //Task 2 - Create Test for Add Function
        [Test]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            //Arrange
            var math = new TestNinja.Fundamentals.Math();

            //Act
            var result = math.Add(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        //Tutorial 7 - Task 3 - Create Tests for Max Function
        [Test]
        public void Max_FirstArgumentIsGreater_ReturnFirstArgument()
        {
            //Arrange
            var math = new Math();

            //Act
            var result = math.Max(2, 1);

            //Assert
            Assert.That(result, Is.EqualTo(2));
            
        }
        [Test]
        public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
        {
            //Arrange
            var math = new Math();

            //Act
            var result = math.Max(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(2));

        }
        [Test]
        public void Max_ArguementsAreEqual_ReturnsSameArgument()
        {
            //Arrange
            var math = new Math();

            //Act
            var result = math.Max(2, 2);

            //Assert
            Assert.That(result, Is.EqualTo(2));
        }
    }
}
