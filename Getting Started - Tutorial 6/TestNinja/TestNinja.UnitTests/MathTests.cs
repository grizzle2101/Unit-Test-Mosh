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

        //Tutorial 8 - Setup & TearDown
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            //Act
            var result = _math.Add(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnFirstArgument()
        {
            //Act
            var result = _math.Max(2, 1);

            //Assert
            Assert.That(result, Is.EqualTo(2));
            
        }
        [Test]
        public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
        {
            //Act
            var result = _math.Max(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(2));

        }
        [Test]
        public void Max_ArguementsAreEqual_ReturnsSameArgument()
        {
            //Act
            var result = _math.Max(2, 2);

            //Assert
            Assert.That(result, Is.EqualTo(2));
        }
    }
}
