using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _controller;
        private Mock<IEmployeeStorage> _mock;
        //private Mock<IEmployeeRepository> _mock;

        [SetUp]
        public void SetUp()
        {
            //_mock = new Mock<IEmployeeRepository>();
            _mock = new Mock<IEmployeeStorage>();
            _controller = new EmployeeController(_mock.Object);
        }

        //Mosh Way
        //Scenario 1 - Correct Data is Passed
        [Test]
        public void DeleteEmployee_WhenCalled_ShouldDeleteEmployeeFromDb()
        {
            //Arrange
            var storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

            //Act
            var result = controller.DeleteEmployee(1);

            //Assert
            storage.Verify(s => s.DeleteEmployee(1));
        }

        //Scenario 2 - Returns Correct Value to Client.
        [Test]
        public void DeleteEmployee_WhenCalled_ShouldReturnRedirect()
        {
            //Arrange
            var storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

            //Act
            var result = controller.DeleteEmployee(1);

            //Assert
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }

        ////Scenario 1 - Confirm Correct Redirect
        //[Test]
        //public void DeleteEmployee_GivenValidId_RecieveRedirect()
        //{
        //    //Arrange

        //    //Act
        //    var result = _controller.DeleteEmployee(1);

        //    //Assert
        //    Assert.That(result, Is.TypeOf<RedirectResult>());
        //}

        ////Scenario 2 - Confirm Employee Deleted
        //[Test]
        //public void DeleteEmployee_GivenValidId_EmployeeDeleted()
        //{
        //    //Arrange

        //    //Act
        //    _controller.DeleteEmployee(1);

        //    //Assert
        //    _mock.Verify(m => m.DeleteEmployee());
        //}

        ////Scenario 4 - Ensure Same Data being Passed
        //[Test]
        //public void DeleteEmployee_GivenValidId_EmployeeDataPassed()
        //{
        //    //Arrange
        //    int i = 3;

        //    //Act
        //    _controller.DeleteEmployee(i);

        //    //Assert
        //    _mock.Verify(m => m.DeleteEmployee(i));
        //}
    }
}
