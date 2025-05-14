namespace NubaHotel.BookingSystem.Application.CQRS.Booking.Command.DeleteBooking;

/// <summary>
/// Defines the contract for handling the deletion of bookings in the application.
/// </summary>
/// <remarks>
/// This interface is responsible for encapsulating the logic for deleting bookings,
/// including the handling of operation cancellation.
/// </remarks>
public interface IDeleteBookingHandler
{
    /// <summary>
    /// Handles the deletion of a booking by its unique identifier.
    /// </summary>
    /// <param name="bookingId">The unique identifier of the booking to delete.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Handle(int bookingId, CancellationToken cancellationToken);
}