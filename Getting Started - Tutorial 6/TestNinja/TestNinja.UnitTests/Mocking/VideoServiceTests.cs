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
    //Tutorial 8 - Creating Mock Objecsts using Mock Frameworks
    //Task 1 - Add NuGet package MOQ
    //Task 2 - Delete FakeFileReader
    //Task 3 - Create MOQ Object
    //Task 4 - Use MOQ Object
    //Task 5 - Cleanup with Setup

    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Moq.Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //Arrange
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            //Act
            var result = _videoService.ReadVideoTitle();

            //Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
