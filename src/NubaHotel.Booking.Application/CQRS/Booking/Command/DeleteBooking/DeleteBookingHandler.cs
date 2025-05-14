using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.Booking.Command.DeleteBooking;

/// <summary>
/// Handles the deletion of bookings in the NubaHotel system.
/// </summary>
/// <remarks>
/// This class is responsible for managing the deletion of bookings by interacting
/// with the booking repository and performing the necessary operations. It uses
/// dependency injection to access required repository and mapping components.
/// </remarks>
public class DeleteBookingHandler : IDeleteBookingHandler
{
    /// <summary>
    /// Represents the repository instance for managing booking-related operations.
    /// </summary>
    /// <remarks>
    /// Provides access to the booking repository interface for performing CRUD
    /// operations on bookings. Used within the application layer to interact with
    /// the domain layer by abstracting booking-related data access functionality.
    /// It allows for operations such as retrieving, adding, updating, and deleting bookings.
    /// </remarks>
    private readonly IBookingRepository _bookingRepository;

    /// <summary>
    /// Represents the mapper instance for handling conversions between booking entities and data transfer objects.
    /// </summary>
    /// <remarks>
    /// Facilitates the transformation of booking domain entities into DTOs and vice versa, supporting operations
    /// that require data model conversions. Ensures a consistent mapping logic implementation for booking-related
    /// components across the application.
    /// </remarks>
    private readonly BookingMapper _bookingMapper;

    /// <summary>
    /// Handles the deletion of bookings in the NubaHotel system.
    /// </summary>
    /// <remarks>
    /// This class is responsible for managing the deletion of bookings by interacting
    /// with the specified booking repository and using mapping components as needed.
    /// It leverages dependency injection to receive its dependencies.
    /// </remarks>
    public DeleteBookingHandler(IBookingRepository bookingRepository, BookingMapper bookingMapper)
    {
        _bookingRepository = bookingRepository;
        _bookingMapper = bookingMapper;
    }

    /// <summary>
    /// Processes the request to delete a booking from the system.
    /// </summary>
    /// <param name="bookingId">The unique identifier of the booking to be deleted.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation of deleting a booking.</returns>
    public async Task Handle(int bookingId, CancellationToken cancellationToken)
    {
        await _bookingRepository.DeleteBookingAsync(bookingId, cancellationToken);
    }
}