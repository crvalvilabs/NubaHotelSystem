namespace NubaHotel.BookingSystem.Infra.Persistence.Entities
{
    /// <summary>
    /// Represents a booking entity.
    /// </summary>
    /// <remarks>
    /// This class is part of the NubaHotel Booking Domain.
    /// It contains properties that define a booking.
    /// </remarks>
    public class BookingEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the booking.
        /// </summary>
        public int BookingId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the booking was made.
        /// </summary>
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the booking is scheduled to start.
        /// </summary>
        public string ? Code { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the booking is scheduled to end.
        /// </summary>
        public string ? Type { get; set; }
        
        /// <summary>
        /// Gets or sets the check-in date for the booking.
        /// </summary>
        public DateTime CheckIn { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the booking ends.
        /// </summary>
        public DateTime CheckOut { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the customer associated with the booking.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user who made the booking.
        /// </summary>
        public int UserId { get; set; }
    }
}
