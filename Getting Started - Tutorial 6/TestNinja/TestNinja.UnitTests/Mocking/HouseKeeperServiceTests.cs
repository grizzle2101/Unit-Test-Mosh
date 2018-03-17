using System;
using System.Collections.Generic;
using System.Linq;
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

        [SetUp]
        public void SetUp()
        {
            //Create Mock Objects
            _unitOfWork = new Mock<IUnitOfWork>();
            _statementGenerator = new Mock<IStatementGenerator>();
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

            _statementGenerator.Setup(sg => sg.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns("filename");

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

        //Interaction Tests
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
            es.EmailFile(housekeeper.Email, housekeeper.StatementEmailBody, "filename", "Sandpiper Statement 2017-01 b"));
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

        //Mosh Additional Scenarios
        //Where a HouseKeep Has NOEmail, method should not be triggered
        //Verify has a parameter called Times, which allows us to verify the number of times a method is called. For us Times.Never
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsNull_ShouldNotSendEmail()
        {
            //Arrange
            housekeeper.Email = null;

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            _emailSender.Verify(es => es.EmailFile(housekeeper.Email, housekeeper.StatementEmailBody, "filename", "Sandpiper Statement 2017-01 b"), Times.Never);
        }

        //Scenario - Where Test is just whitespace
        //Congrats we found a bug, refactor to include IsNullOrEmpty
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsWhitespace_ShouldNotSendEmail()
        {
            //Arrange
            housekeeper.Email = " ";

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            _emailSender.Verify(es => es.EmailFile(housekeeper.Email, housekeeper.StatementEmailBody, "filename", "Sandpiper Statement 2017-01 b"), Times.Never);
        }

        //Scenario - Email is Empty
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsEmpty_ShouldNotSendEmail()
        {
            //Arrange
            housekeeper.Email = "";

            //Act
            _keeperService.SendStatementEmails(dateTime);

            //Assert
            _emailSender.Verify(es => es.EmailFile(housekeeper.Email, housekeeper.StatementEmailBody, "filename", "Sandpiper Statement 2017-01 b"), Times.Never);
        }
    }
}
