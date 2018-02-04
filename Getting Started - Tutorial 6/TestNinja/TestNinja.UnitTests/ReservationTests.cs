using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    //Step 2 - Rename Class & Methods
    [TestClass]
    public class ReservationTests
    {
        //Step 3 - Define the Scenarios
        //Step 4 - Writing the Test
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            Assert.IsTrue(result);
        }

        //Step 6 - Complete the Other Scenarios:
        [TestMethod]
        public void CanBeCancelledBy_MadeByUser_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            var user = new User { IsAdmin = false };

            //Act
            reservation.MadeBy = user;
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_IsNormalUser_ReturnsFalse()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false});

            //Assert
            Assert.IsFalse(result);

        }
    }
}
