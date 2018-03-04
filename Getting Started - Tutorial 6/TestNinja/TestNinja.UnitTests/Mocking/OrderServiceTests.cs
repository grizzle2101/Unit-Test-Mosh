using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Mocking;
using Moq;

namespace TestNinja.UnitTests.Mocking
{
    //Tutorial 10 - Testing the Interaction between 2 objects
    //Task 1 - Setup Test Class
    //Task 2 - Mock IStorage
    //Task 3 - Pass Mock Object to Service
    //Task 4 - Assert Same Order object given to Service, is passed to Mock Storage Object
    //Task 5 - Sanity Check PlaceOrder Method

    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_ShouldStoreOrder()
        {
            //Arrange
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);

            //Act
            var order = new Order();
            service.PlaceOrder(order);

            //Assert
            storage.Verify(s => s.Store(order));
        }
    }
}
