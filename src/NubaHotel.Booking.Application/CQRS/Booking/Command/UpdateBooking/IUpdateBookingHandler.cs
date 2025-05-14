using NubaHotel.BookingSystem.Application.CQRS.Booking.Command.CreateBooking;

namespace NubaHotel.BookingSystem.Application.CQRS.Booking.Command.UpdateBooking;

/// <summary>
/// Defines the contract for handling update operations for existing bookings in the booking system.
/// </summary>
/// <remarks>
/// Implementations of this interface are responsible for processing updates to bookings by
/// receiving the booking identifier and updated booking details encapsulated in the <see cref="CreateBookingCommand"/>.
/// The update operation should also consider managing concurrency and ensuring data consistency.
/// </remarks>
public interface IUpdateBookingHandler
{
    /// <summary>
    /// Handles the update operation for an existing booking in the booking system.
    /// </summary>
    /// <param name="id">The unique identifier of the booking to be updated.</param>
    /// <param name="command">The <see cref="CreateBookingCommand"/> containing the updated booking details.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete, enabling cancellation of the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task Handle(int id, UpdateBookingCommand command, CancellationToken cancellationToken);
}