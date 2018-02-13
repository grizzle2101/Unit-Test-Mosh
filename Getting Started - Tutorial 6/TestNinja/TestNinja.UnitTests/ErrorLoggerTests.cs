using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger _logger;

        //Adding Setup Method
        [SetUp]
        public void SetUp()
        {
            _logger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_ShouldSetLastErrorProperty()
        {
            //Arrange
            //_logger = new ErrorLogger();

            //Act
            _logger.Log("abc");

            //Assert
            Assert.That(_logger.LastError, Is.EqualTo("abc"));

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            //Arrange
            //_logger = new ErrorLogger();


            //Assert
            Assert.That(() => _logger.Log(error), Throws.ArgumentNullException);

            //Testing Custom Exceptions
            //Assert.That(() => _logger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>());

        }

        //Testing a Method that Raises an Event
        [Test]
        public void Log_ValidError_ShouldRaiseErrorLoggedEvent()
        {
            var id = Guid.Empty;
            //Subscribe to Event
            _logger.ErrorLogged += (sender, args) => { id = args;};

            //Act
            _logger.Log("abc");

            //Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
