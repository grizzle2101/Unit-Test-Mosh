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
    //Test Scenarios (Black Box Remember)
    //Test 1 - Booking with no Overlap - Should Return Empty String
    //Test 2 - Booking finishes during existing booking.
    //Test 3 - Booking Starts during Existing nooking


    [TestFixture]
    public class BookingHelperTests
    {
        private Mock<IBookingRepository> _mockRepository;
        private Booking _existingBooking;

        //Task 2 - Extract Booking to Private Field (Avoids Repetition)
        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IBookingRepository>();

            //Task 2 - Extract Booking to Setup.
            _existingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DerpartOn(2017, 1, 20),
                Reference = "a"
            };

            //Setup
            _mockRepository.Setup(r => r.GetActiveBookings(1))
                .Returns(new List<Booking>
                {
                    _existingBooking
                }.AsQueryable);
        }

        //Mosh - Version 2 Refactored
        //Scenario 1 - No Overlap in Dates
        [Test]
        public void OverlappingBookingsExist_BookingWithNoOverlap_ShouldReturnEmptyString()
        {
            //Arrange

            //Act
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = Before(_existingBooking.ArrivalDate)
            }, _mockRepository.Object);

            //Assert
            Assert.That(result, Is.Empty);
        }

        //Scenario 2 - Date Ending in middle of Existing Booking
        [Test]
        public void OverlappingBookingsExist_BookingFinishedInMiddleOfExistingBooking_ShouldReturnExistingBookingRef()
        {
            //Arrange

            //Act
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = After(_existingBooking.ArrivalDate),
                Reference = "XYZ"
            }, _mockRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        //Scenario 3 - New Booking Before Existing & After Existing
        [Test]
        public void OverlappingBookingsExist_BookingStartsBeforeExistingAndFinishesAfer_ShouldReturnExistingBookingRef()
        {
            //Arrange

            //Act
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = After(_existingBooking.DepartureDate),
                Reference = "XYZ"
            }, _mockRepository.Object);

            //Assert
            //Bug Here, got empty string instead of Booking Ref.
            //Bug Fixed, tests still pass so big win for Unit Testing!
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        //Scenario 4 - Booking Starts & Finishes in the middle of Existing Booking
        [Test]
        public void OverlappingBookingsExist_BookingStartsInMiddleOfExistingBooking_ShouldReturnExistingBookingRef()
        {
            //Arrange

            //Act
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.ArrivalDate),
                DepartureDate = Before(_existingBooking.DepartureDate),
                Reference = "XYZ"
            }, _mockRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        //Scenario 5 - Booking Starts in the middle of existing booking, but finishes after
        [Test]
        public void OverlappingBookingsExist_BookingStartsInMiddleOfExistingBookingAndFinishesAfter_ShouldReturnExistingBookingRef()
        {
            //Arrange

            //Act
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.DepartureDate),
                Reference = "XYZ"
            }, _mockRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        //Scenario 6 - Booking Starts and Finishes After Booking
        [Test]
        public void OverlappingBookingsExist_BookingStartAndFinishesAfterBooking_ShouldReturnEmptyString()
        {
            //Arrange

            //Act
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.DepartureDate),
                DepartureDate = After(_existingBooking.DepartureDate, days: 5),
                Reference = "XYZ"
            }, _mockRepository.Object);

            //Assert
            Assert.That(result, Is.Empty);
        }

        //Additional Tests - Cancelled Bookings
        //Additional Scenario 1
        [Test]
        public void OverlappingBookingsExist_BookingCancelled_ShouldReturnEmptyString()
        {
            //Arrange

            //Act
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                Status = "Cancelled",
                ArrivalDate = After(_existingBooking.DepartureDate),
                DepartureDate = After(_existingBooking.DepartureDate, days: 5),
                Reference = "XYZ"
            }, _mockRepository.Object);

            //Assert
            Assert.That(result, Is.Empty);
        }

        //Additional Scenario 2 -ExistingBookingWasCancelled
        [Test]
        public void OverlappingBookingsExist_ExistingBookingCancelled_ShouldReturnEmptyString()
        {
            //Arrange

            //Act
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                Status = "Cancelled",
                ArrivalDate = After(_existingBooking.ArrivalDate),
                DepartureDate = Before(_existingBooking.DepartureDate),
                Reference = "XYZ"
            }, _mockRepository.Object);

            //Assert
            Assert.That(result, Is.Empty);
        }


        //Task 1 - Create Test Helpers
        private DateTime ArriveOn(int year,int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DerpartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }

        //Task 3 - Method for Changing Data on the Fly
        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }


        //Made Mistake here not Knowing AsQueryable, it casts our List to Queryable so no compilation error.
        //This Test has Gotten Super Fat, so in the next tutorial we're gonna do some Refactoring.
        //[Test]
        //public void OverlappingBookingsExist_BookingWithNoOverlap_ShouldReturnEmptyStringa()
        //{
        //    //Arrange
            
        //    _mockRepository.Setup(r => r.GetActiveBookings(1))
        //        .Returns(new List<Booking>
        //        {
        //            new Booking
        //            {
        //                Id = 2,
        //                ArrivalDate = new DateTime(2017, 1, 15, 14, 0 ,0),
        //                DepartureDate = new DateTime(2017, 1, 20, 10, 0 ,0),
        //                Reference = "a"
        //            }
        //        }.AsQueryable);

        //    //Act
        //    var result = BookingHelper.OverlappingBookingsExist(new Booking
        //    {
        //        Id = 1,
        //        ArrivalDate = new DateTime(2017, 1, 10, 14, 0, 0),
        //        DepartureDate = new DateTime(2017, 1, 14, 10, 0, 0)
        //    }, _mockRepository.Object);

        //    //Assert
        //    Assert.That(result, Is.Empty);

        //}
    }
}
