namespace NubaHotel.BookingSystem.Application.CQRS.Booking.Command.CreateBooking
{
    /// <summary>
    /// Represents a command for creating a new booking in the booking system.
    /// </summary>
    /// <remarks>
    /// This command contains all the necessary details required to create a booking,
    /// such as the booking date, type, check-in and check-out dates, customer ID, and user ID.
    /// It is used in conjunction with a handler to perform the creation process.
    /// </remarks>
    public class CreateBookingCommand
    {
        /// <summary>
        /// Gets or sets the date and time when the booking was made.
        /// </summary>
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the booking is scheduled to start.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the booking is scheduled to end.
        /// </summary>
        public string? Type { get; set; }
        
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