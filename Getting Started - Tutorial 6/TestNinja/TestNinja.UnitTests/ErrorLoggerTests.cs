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

        //Task 3 - Reworking Test to work with new Private Implementation
        //Demonstrating testing the public interface is better, we can still have our private Implementation
        //AS long as its called within Log method
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


        //In Summary this is why we don't test protected Implementation
        //Task 1 - Making Error ID Private & not passed in OnErrorLogged()
        //[Test]
        //public void Log_ValidError_ShouldRaiseErrorLoggedEvent()
        //{
        //    //var id = Guid.Empty;
        //    //Subscribe to Event
        //    //_logger.ErrorLogged += (sender, args) => { id = args;};

        //    //Act
        //    //_logger.Log("abc");

        //    //Assert
        //    //Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        //}
    }
}
