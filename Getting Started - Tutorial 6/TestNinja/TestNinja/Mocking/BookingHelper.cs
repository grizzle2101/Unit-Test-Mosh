using System;
using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    //Section 7 - Booking Helper Excercise
    //Task 3 - Refactor
    public static class BookingHelper
    {
        public static string OverlappingBookingsExist(Booking booking, IBookingRepository repository)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;

            var bookings = repository.GetActiveBookings(booking.Id);

            //We Found a Bug here with Test Case 3.
            //Doing this manually would have taken a very long time to deploy Application
            //Test the various dates, then do the same after bugfix.
            
            //After Googleing Date Overlap Alghoritm, got a better way with less code!
            //Tests all still green so big win!
            //bool overlap = tStartA < tEndB
                           //** tStartB < tEndA;
            var overlappingBooking =
                bookings.FirstOrDefault(
                    b =>
                        booking.ArrivalDate < b.DepartureDate &&
                        b.ArrivalDate < booking.DepartureDate);

            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }

    //Refactor One
    //Task 1 & 2 - Extract to Interface
    public interface IUnitOfWork
    {
        IQueryable<T> Query<T>();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }

    public class Booking
    {
        public string Status { get; set; }
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Reference { get; set; }
    }
}