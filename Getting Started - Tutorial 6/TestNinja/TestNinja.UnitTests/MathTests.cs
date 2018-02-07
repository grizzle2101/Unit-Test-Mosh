using System;
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
    }
}
