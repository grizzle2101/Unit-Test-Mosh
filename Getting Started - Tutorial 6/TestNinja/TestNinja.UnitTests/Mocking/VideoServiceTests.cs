using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    //Task 3 - Create Unit Test Class
    [TestFixture]
    public class VideoServiceTests
    {
        //Scenario - Attempting to Desearialize Empthy Video Object
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //Arrange
            var service = new VideoService();

            //Act
            //Passing Fake File Reader
            var result = service.ReadVideoTitle(new FakeFileReader());

            //Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
