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
        [Test]
        public void Log_WhenCalled_ShouldSetLastErrorProperty()
        {
            //Arrange
            var logger = new ErrorLogger();

            //Act
            logger.Log("abc");

            //Assert
            Assert.That(logger.LastError, Is.EqualTo("abc"));

        }
    }
}
