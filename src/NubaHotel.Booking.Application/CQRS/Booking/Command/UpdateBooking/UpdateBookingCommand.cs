namespace NubaHotel.BookingSystem.Application.CQRS.Booking.Command.UpdateBooking
{
    /// <summary>
    /// Represents a command to update an existing booking within the application.
    /// </summary>
    /// <remarks>
    /// This command is used as part of the CQRS (Command Query Responsibility Segregation) pattern
    /// to encapsulate the data necessary for updating an existing booking.
    /// It is primarily consumed by handlers responsible for processing the command and updating the booking in the system.
    /// </remarks>
    public class UpdateBookingCommand
    {
        /// <summary>
        /// Gets or sets the check-in date for the booking.
        /// </summary>
        public DateTime CheckIn { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the booking ends.
        /// </summary>
        public DateTime CheckOut { get; set; }
    }
}