using NubaHotel.BookingSystem.Application.DTOs;

namespace NubaHotel.BookingSystem.Application.CQRS.Booking.Query.GetAllBookings;

/// <summary>
/// Defines a contract for handling retrieval of all bookings in the system.
/// </summary>
/// <remarks>
/// Implementations of this interface should handle the logic necessary to fetch and map
/// booking data from the underlying data source.
/// </remarks>
public interface IGetAllBookingsHandler
{
    /// <summary>
    /// Retrieves all bookings in the system and maps them to a collection of BookingDto objects.
    /// </summary>
    /// <param name="cancellationToken">A token that can be used to signal the operation should be canceled.</param>
    /// <returns>A task representing the asynchronous operation, which upon completion contains a collection of BookingDto objects.</returns>
    Task<IEnumerable<BookingDto>> Handle(CancellationToken cancellationToken);
}