using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    //Test Scenarios:
    //Passes the Correct Details
    //Successfull File Download
    //Failed File Download

    [TestFixture]
    public class InstallHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;
        //private ClientCustomer _customer;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
            //_customer = new ClientCustomer(){Name = "Bob", Installer = "Agent Ransack", Location = "c:/Test"};
        }

        //Mosh Design
        //Only 2 Tests needed.
        //Fails & throws Exception
        //Completes Successfully
        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            //Arrange
            _fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            //Act
            var result = _installerHelper.DownloadInstaller("cusomter", "installer");

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadSucceeds_ReturnsTrue()
        {
            //Arrange

            //Act
            var result = _installerHelper.DownloadInstaller("cusomter", "installer");

            //Assert
            Assert.That(result, Is.True);
        }

        ////My Design
        ////Scenario 1 - Testing Correct Details are passed.
        //[Test]
        //public void DownloadInstaller_GivenCorrectDetails_PassesDetailToMock()
        //{
        //    //Arrange
        //    _fileDownloader.Setup(m => m.GetFile(new ClientCustomer())).Returns(true);

        //    //Act
        //    _customer.Name = "Conor";
        //    _installerHelper.DownloadInstaller(_customer);

        //    //Assert
        //    _fileDownloader.Verify(i => i.GetFile(_customer));
        //}

        ////Scenario 2 - Correct Details are Passed.
        //[Test]
        //public void DownloadInstaller_GivenCorrectDetails_ReturnsTrue()
        //{
        //    //Arrange
        //    _fileDownloader.Setup(m => m.GetFile(new ClientCustomer())).Returns(true);

        //    //Act
        //    var result = _installerHelper.DownloadInstaller(_customer);

        //    //Assert
        //    Assert.That(result, Is.EqualTo(false));

        //}

        ////Scenario 3 - Incorrect Details are Passed.
        //[Test]
        //public void DownloadInstaller_GivenIncorrectDetails_ReturnsFalse()
        //{
        //    //Arrange
        //    _fileDownloader.Setup(m => m.GetFile(new ClientCustomer())).Returns(false);


        //    //Act
        //    var result = _installerHelper.DownloadInstaller(_customer);

        //    //Assert
        //    Assert.That(result, Is.EqualTo(false));
        //}
    }
}
