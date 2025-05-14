using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.Booking.Query.GetBookingById;

/// <summary>
/// Represents a query class to retrieve booking details by its identifier.
/// </summary>
/// <remarks>
/// This class is part of the CQRS pattern implementation of the booking system.
/// It handles the logic necessary to retrieve booking information based on an identifier.
/// </remarks>
public class GetBookingByIdHandler : IGetBookingByIdHandler
{
    /// <summary>
    /// Represents the repository instance used to interact with booking-related data.
    /// </summary>
    /// <remarks>
    /// The repository provides methods for CRUD operations on bookings, such as retrieving,
    /// adding, updating, or deleting booking records. It acts as a data access layer, abstracting
    /// storage-specific logic.
    /// </remarks>
    private readonly IBookingRepository _bookingRepository;
    
    private readonly BookingMapper _bookingMapper;

    /// <summary>
    /// Constructs a new instance of the <see cref="GetBookingById"/> class.
    /// </summary>
    /// <param name="bookingRepository">The repository instance used to interact with booking-related data.</param>
    /// <param name="bookingMapper">The mapper instance used to map booking entities to DTOs.</param>
    public GetBookingByIdHandler(IBookingRepository bookingRepository, BookingMapper bookingMapper)
    {
        _bookingRepository = bookingRepository;
        _bookingMapper = bookingMapper;   
    }
    
    /// <summary>
    /// Handles the logic to retrieve booking details by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the booking to retrieve.</param>   
    /// <param name="cancellationToken">A token to cancel the operation if required.</param>
    /// <returns>A <see cref="BookingDto"/> containing booking details.</returns>  
    public async Task<BookingDto> Handle(int id, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(id, cancellationToken);
        var bookingDto = _bookingMapper.MapToBookingDto(booking);
        return bookingDto;
    }
}