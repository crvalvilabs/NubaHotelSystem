using NubaHotel.BookingSystem.Infra.Persistence.Entities;
using NubaHotel.BookingSystem.Domain.Entities;

namespace NubaHotel.BookingSystem.Infra.Persistence.Mappers
{
    /// <summary>
    /// Provides methods for mapping booking data between domain entities and persistence layer entities.
    /// </summary>
    public class BookingMapper
    {
        /// <summary>
        /// Maps a <see cref="BookingEntity"/> to a <see cref="Booking"/> domain entity.
        /// </summary>
        /// <param name="entity">The <see cref="BookingEntity"/> instance to be mapped.</param>
        /// <returns>A <see cref="Booking"/> instance representing the mapped domain model.</returns>
        public Booking MapToBooking(BookingEntity entity)
        {
            var booking = new Booking
            {
                BookingId = entity.BookingId,
                BookingDate = entity.BookingDate,
                Code = entity.Code,
                Type = entity.Type,
                CustomerId = entity.CustomerId,
                UserId = entity.UserId
            };
            return booking;
        }

        /// <summary>
        /// Maps a <see cref="Booking"/> domain entity to a <see cref="BookingEntity"/> persistence layer entity.
        /// </summary>
        /// <param name="booking">The <see cref="Booking"/> instance to be mapped.</param>
        /// <returns>A <see cref="BookingEntity"/> instance representing the mapped persistence entity.</returns>
        public BookingEntity MapToBookingEntity(Booking booking)
        {
            var bookingEntity = new BookingEntity
            {
                BookingId = booking.BookingId,
                BookingDate = booking.BookingDate,
                Code = booking.Code,
                Type = booking.Type,
                CustomerId = booking.CustomerId,
                UserId = booking.UserId
            };
            return bookingEntity;
        }
    }
}