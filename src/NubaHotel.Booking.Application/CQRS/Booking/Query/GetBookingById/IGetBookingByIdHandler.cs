using NubaHotel.BookingSystem.Application.DTOs;

namespace NubaHotel.BookingSystem.Application.CQRS.Booking.Query.GetBookingById;

/// <summary>
/// Defines the contract for handling requests to retrieve booking details by their unique identifier.
/// </summary>
/// <remarks>
/// This interface is part of the CQRS implementation within the booking system.
/// It specifies the method required to process retrieval of booking information.
/// </remarks>
public interface IGetBookingByIdHandler
{
    /// <summary>
    /// Handles the process of retrieving booking details by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the booking to retrieve.</param>   
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    /// <returns>A <see cref="BookingDto"/> containing booking details.</returns>   
    Task<BookingDto> Handle(int id, CancellationToken cancellationToken);
}