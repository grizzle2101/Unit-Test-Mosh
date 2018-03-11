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
            var result = new List<Housekeeper>
            {
                new Housekeeper
                {
                    Email = "a",
                    FullName = "b",
                    Oid = 1,
                    StatementEmailBody = "c"
                }
            };

            _unitOfWork.Setup(r => r.Query<Housekeeper>())
                .Returns(result.AsQueryable);

            //Inject Dependency
            _keeperService = new HousekeeperService(
                _unitOfWork.Object,
                _statementGenerator.Object,
                _emailSender.Object,
                _messageBox.Object
                );
        }

        [Test]
        public void SendStatementEmails_WhenCalled_ShouldGenerateStatements()
        {
            //Arrange


            //Act
            _keeperService.SendStatementEmails(new DateTime(2017, 1, 1));

            //Assert
            _statementGenerator.Verify(sg => sg.SaveStatement(1, "b", (new DateTime(2017, 1, 1))));
        }
    }
}
