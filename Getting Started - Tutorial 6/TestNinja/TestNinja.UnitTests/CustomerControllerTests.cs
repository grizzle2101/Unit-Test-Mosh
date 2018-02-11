using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    //Section 3 - Tutorial 4 - Testing Return Types
    [TestFixture]
    class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IDIsZero_ShouldReturnNotFound()
        {
            //Arrange
            var controller = new CustomerController();

            //Act
            var result = controller.GetCustomer(0);


            //Specific Assertion - MUST be of type NotFound
            Assert.That(result, Is.TypeOf<NotFound>());

            //General Assertion
            //Can be NotFound or any of its derivatives.
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IDIsNotZero_ShouldReturnOk()
        {
            //Arrange
            var controller = new CustomerController();

            //Act
            var result = controller.GetCustomer(1);

            //Assert
            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
