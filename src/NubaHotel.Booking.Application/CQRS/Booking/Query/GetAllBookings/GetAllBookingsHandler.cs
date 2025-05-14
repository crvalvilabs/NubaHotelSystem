using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.Booking.Query.GetAllBookings;

/// <summary>
/// Handles the operation for retrieving all bookings information from the system.
/// </summary>
/// <remarks>
/// This handler interacts with the booking repository to fetch all booking entities
/// and maps them to their corresponding DTO representations for external usage.
/// </remarks>
public class GetAllBookingsHandler : IGetAllBookingsHandler
{
    /// <summary>
    /// Represents the dependency for accessing and managing booking data within
    /// the NubaHotel system.
    /// </summary>
    /// <remarks>
    /// This field is used to interact with the data repository that handles
    /// operations related to bookings, including retrieval, addition, updates,
    /// and deletion. It provides the underlying data access necessary for
    /// handling domain-specific logic in the application layer.
    /// </remarks>
    private readonly IBookingRepository _bookingRepository;

    /// <summary>
    /// Provides the functionality to map booking domain entities to data transfer objects (DTOs)
    /// and vice versa within the NubaHotel booking system.
    /// </summary>
    /// <remarks>
    /// This field is used to convert booking entities retrieved from the domain layer
    /// into DTOs for application or external use, as well as to map incoming data to domain entities.
    /// It plays a key role in ensuring seamless communication between the domain and application layers
    /// while maintaining separation of concerns.
    /// </remarks>
    private readonly BookingMapper _bookingMapper;

    /// <summary>
    /// Handles the process of retrieving all bookings from the system and mapping them into DTOs for client consumption.
    /// </summary>
    /// <remarks>
    /// This class acts as a mediator between the booking repository and the application's consumers,
    /// ensuring that the data is properly mapped and delivered.
    /// </remarks>
    public GetAllBookingsHandler(IBookingRepository bookingRepository, BookingMapper bookingMapper)
    {
        _bookingRepository = bookingRepository;
        _bookingMapper = bookingMapper;  
    }

    /// <summary>
    /// Handles the retrieval of all bookings from the repository and maps them into booking DTOs for further processing or consumption.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of booking DTOs representing all bookings in the system.</returns>
    public async Task<IEnumerable<BookingDto>> Handle(CancellationToken cancellationToken)
    {
        var bookings = await _bookingRepository.GetAllAsync(cancellationToken);
        var bookingsDto = _bookingMapper.MapToBookingDto(bookings);
        return bookingsDto;   
    }
}