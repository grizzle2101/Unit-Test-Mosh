using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    //Task 1 - Extract External Resource Calls.
    public class BookingRepository
    {
        public IQueryable<Booking> GetActiveBookings(int? excludedBookingID = null)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => b.Status != "Cancelled");

            if (excludedBookingID.HasValue)
                bookings = bookings.Where(b => b.Id != excludedBookingID.Value);
            return bookings;
        }
    }

    //Task 2 - Program to Interface
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBookings(int id);
    }
}