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
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _videoRepository;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Moq.Mock<IFileReader>();
            _videoRepository = new Moq.Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);
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

        //Section 6 - Tutorial 3 - Testing VideoService
        //How Many Scenarios do we need for this?
        //Empty List - Empty String
        //[{1}, {2}, {3}] = "1,2,3" 

        [Test]
        public void GetUnprocessedVideosAsCsv_NoVideosInRepository_ShouldReturnEmptyString()
        {
            //Arrange
            _videoRepository.Setup(r => r.GetVideos()).Returns(new List<Video>());

            //Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            //Assert
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_ManyVideosInRepository_ShouldReturnStringOfIds()
        {
            //Arrange
            List<Video> videoList = new List<Video>();
            videoList.Add(new Video(){Id = 1});
            videoList.Add(new Video() { Id = 5});
            videoList.Add(new Video() { Id = 9});

            _videoRepository.Setup(v => v.GetVideos()).Returns(videoList);

            //Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            //Assert
            Assert.That(result.Equals("1,5,9"));
        }
    }
}
