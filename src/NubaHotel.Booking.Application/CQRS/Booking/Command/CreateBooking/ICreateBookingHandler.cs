namespace NubaHotel.BookingSystem.Application.CQRS.Booking.Command.CreateBooking
{
    /// <summary>
    /// Defines the contract for handling the creation of a booking in the booking system.
    /// </summary>
    public interface ICreateBookingHandler
    {
        /// <summary>
        /// Handles the creation of a booking in the booking system.
        /// </summary>
        /// <param name="command">The command containing the booking details such as booking date, customer ID, check-in and check-out dates, and other related information.</param>
        /// <param name="cancellationToken">A token that can be used to propagate notifications that the operation should be canceled.</param>
        /// <return>Returns a task that represents the asynchronous operation and may optionally contain a result describing the outcome of the booking creation.</return>
        Task Handle(CreateBookingCommand command, CancellationToken cancellationToken);
    }
}