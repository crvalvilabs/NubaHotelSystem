using NubaHotel.BookingSystem.Application.CQRS.Booking.Command.CreateBooking;
using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.Booking.Command.UpdateBooking;

/// <summary>
/// Handles the update booking command in the booking system.
/// </summary>
/// <remarks>
/// Responsible for mapping the received creation booking command data to a Booking entity and updating the
/// booking details in the repository. Uses dependency injection to access repository and mapper components.
/// </remarks>
public class UpdateBookingHandler : IUpdateBookingHandler
{
    /// <summary>
    /// Provides access to the booking repository for performing booking-related operations
    /// such as retrieving, updating, and managing bookings in the application.
    /// </summary>
    /// <remarks>
    /// The repository operates as an abstraction layer for persisting and querying
    /// booking data. It is injected via dependency injection and used within the
    /// handler to maintain separation of concerns.
    /// </remarks>
    private readonly IBookingRepository _bookingRepository;

    /// <summary>
    /// Facilitates the conversion between various booking-related data formats by
    /// providing mapping functionalities essential for translating command or DTO data
    /// into domain entities and vice versa.
    /// </summary>
    /// <remarks>
    /// This mapper ensures that the data used in booking-related operations
    /// is properly transformed, maintaining consistency and integrity within the application.
    /// It is injected into the handler to streamline the mapping process.
    /// </remarks>
    private readonly BookingMapper _bookingMapper;

    /// <summary>
    /// Handles the process of updating an existing booking in the system.
    /// </summary>
    /// <remarks>
    /// This handler takes input data encapsulated in the update booking command, maps it to a Booking entity,
    /// and updates the corresponding record in the data repository. It leverages the booking repository
    /// for persistence and uses the booking mapper for transforming command data to domain entities.
    /// </remarks>
    public UpdateBookingHandler(IBookingRepository bookingRepository, BookingMapper bookingMapper)
    {
        _bookingRepository = bookingRepository;
        _bookingMapper = bookingMapper;
    }

    /// <summary>
    /// Processes the update of a booking by mapping the command data to a domain entity and persisting the changes.
    /// </summary>
    /// <param name="id">The unique identifier of the booking to be updated.</param>
    /// <param name="command">The command containing the updated booking details.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task Handle(int id, UpdateBookingCommand command, CancellationToken cancellationToken)
    {
        var booking = _bookingMapper.MapToBooking(command);
        await _bookingRepository.UpdateBookingAsync(id, booking, cancellationToken);
    }
}