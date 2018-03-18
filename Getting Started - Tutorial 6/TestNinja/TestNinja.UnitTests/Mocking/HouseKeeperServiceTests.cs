using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class HouseKeeperServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _messageBox;
        private DateTime dateTime = new DateTime(2017, 1, 1);
        private Housekeeper housekeeper;

        private HousekeeperService _keeperService;
        private string _filename;

        [SetUp]
        public void SetUp()
        {
            //Helpers
            _filename = "filename";

            //Create Mock Objects
            _unitOfWork = new Mock<IUnitOfWork>();

            _statementGenerator = new Mock<IStatementGenerator>();
            _statementGenerator.Setup(sg => sg.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(() => _filename);

            _emailSender = new Mock<IEmailSender>();
            _messageBox = new Mock<IXtraMessageBox>();

            //Setup
            housekeeper = new Housekeeper
            {
                Email = "a",
                FullName = "b",
                Oid = 1,
                StatementEmailBody = "c"
            };


            //Setup Mocks
            _unitOfWork.Setup(r => r.Query<Housekeeper>())
                .Returns(new List<Housekeeper> { housekeeper }.AsQueryable);

            _emailSender.Setup(es => es.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            _messageBox.Setup(mb => mb.Show(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MessageBoxButtons>()));


            //Inject Dependency
            _keeperService = new HousekeeperService(
                _unitOfWork.Object,
                _statementGenerator.Object,
                _emailSender.Object,
                _messageBox.Object
                );
        }

        //My Interaction Tests
        //Scenario 1 - Confirm Save Statement Recieves Correct Details.
        [Test]
        public void SendStatementEmails_WhenCalled_ShouldGenerateStatements()
        {
            //Arrange

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            _statementGenerator.Verify(sg => sg.SaveStatement(housekeeper.Oid, housekeeper.FullName, dateTime));
        }

        //Scenario 2 - Confirm Email Sender Recieves Correct Details.
        [Test]
        public void SendStatementEmails_WhenCalled_ShouldEmailHouseKeeper()
        {
            //Arrange

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            _emailSender.Verify(es =>
            es.EmailFile(housekeeper.Email, housekeeper.StatementEmailBody, _filename, "Sandpiper Statement 2017-01 b"));
        }

        //Scenario 3 - Confirm IMessageBox Recieved Correct Details
        [Test]
        public void SendStatementEmails_WhenCalled_ShouldPromptMessageBox()
        {
            //Arrange
            _emailSender.Setup(es => es.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Throws(new Exception("Some Crazy Web Exception"));

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            _messageBox.Verify(mb => mb.Show("Some Crazy Web Exception", "Email failure: " + housekeeper.Email, MessageBoxButtons.OK));
        }

        //Tutorial 6 - Testing a Method is NOT called.
        //Verify has a parameter called Times, which allows us to verify the number of times a method is called. For us Times.Never
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsNull_ShouldNotGenerateStatment()
        {
            //Arrange
            housekeeper.Email = null;

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            _statementGenerator.Verify(sg =>
                sg.SaveStatement(housekeeper.Oid, housekeeper.FullName, dateTime), Times.Never);
        }

        //Scenario - Where Test is just whitespace
        //Congrats we found a bug, refactor to include IsNullOrEmpty
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsWhitespace_ShouldNotGenerateStatment()
        {
            //Arrange
            housekeeper.Email = " ";

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            _statementGenerator.Verify(sg =>
                sg.SaveStatement(housekeeper.Oid, housekeeper.FullName, dateTime), Times.Never);
        }
 
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsEmpty_ShouldNotGenerateStatment()
        {
            //Arrange
            housekeeper.Email = "";

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            _statementGenerator.Verify(sg =>
            sg.SaveStatement(housekeeper.Oid, housekeeper.FullName, dateTime), Times.Never);
        }

        //Tutorial 7 - Another Interaction Test
        //Scenarios for Statement Generation
        [Test]
        public void SendStatementEmails_WhenCalled_ShouldEmailStatement()
        {
            //Arrange
            _filename = "filename";

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            VerifyEmailSent();
        }

        //If we look at the Logic for Sending the Email.
        //We have 3 more scenarios, Whitespace Null & Empty
        [Test]
        public void SendStatementEmails_WhiteSpaceInFileName_ShouldNotEmailStatement()
        {
            //Arrange
            _filename = " ";

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            VerifyEmailNotSent();
        }

        [Test]
        public void SendStatementEmails_EmptyStringInFileName_ShouldNotEmailStatement()
        {
            //Arrange
            _filename = "";

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            VerifyEmailNotSent();
        }

        [Test]
        public void SendStatementEmails_NullFileName_ShouldNotEmailStatement()
        {
            //Arrange
            _filename = null;

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            VerifyEmailNotSent();
        }
        //Tutorial 9 - Testing Exceptions
        [Test]
        public void SendStatementEmails_ExceptionThrown_ShouldPromptMessage()
        {
            _emailSender.Setup(es =>
                es.EmailFile(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>())).
                Throws(new WebException());

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            _messageBox.Verify(mb =>
                mb.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK));
        }

        //Tutorial 8 - Extracting Helper Methods
        //We Have quite a bit of duplication, setting up StatementGenerator & EmailSender Mocks
        //Duplicating the same setup, but changing from Whitespace, Empty or null.
        //Why not extact this to Helper method?
        private void VerifyEmailNotSent()
        {
            _emailSender.Verify(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()), Times.Never);
        }

        private void VerifyEmailSent()
        {
            _emailSender.Verify(es => es.EmailFile(
                housekeeper.Email,
                housekeeper.StatementEmailBody,
                _filename,
                It.IsAny<string>()));
        }
    }
}
