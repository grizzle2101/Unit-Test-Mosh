using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    //Tutorial 12 - Mock Abuse
    //Task 1 - Create Test Setup
    //Task 2 - Create Product & Pass Gold Customer
    //Task 3 - Veryify Listprice = 70
    //Task 4 - Refactor like you Abuse Mocks
    //Task 5 - Write Tests like you Abuse Mocks.
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetPrice_ForGoldCustomer_ShouldApplyDiscount()
        {
            //Arrange
            var product = new Product{ListPrice = 100};

            //Act
            var result = product.GetPrice(new Customer() { IsGold = true });

            //Assert
            Assert.That(result, Is.EqualTo(70));
        }

        //Task 5 - Write Tests like you Abuse Mocks
        [Test]
        public void GetPrice_ForGoldCustomer_ShouldApplyDiscount2()
        {
            //Arrange
            var customer = new Mock<ICustomer>();
            customer.Setup(c => c.IsGold).Returns(true);
            var product = new Product();

            //Act
            var result = product.GetPrice(customer.Object);

            //Assert
            Assert.That(result, Is.EqualTo(70));
        }
    }

}
