using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        //Scenario - Attempting to Desearialize Empthy Video Object
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //Arrange
            //Task 3 - Constructor w Optional Param 
            var service = new VideoService(new FakeFileReader());

            //Act
            var result = service.ReadVideoTitle();

            //Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
