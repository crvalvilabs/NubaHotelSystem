using NubaHotel.BookingSystem.Application.CQRS.Booking.Command.CreateBooking;
using NubaHotel.BookingSystem.Application.CQRS.Booking.Command.UpdateBooking;
using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Domain.Entities;

namespace NubaHotel.BookingSystem.Application.Mappers;

/// <summary>
/// Provides mapping functionalities between Booking domain entities and BookingDto data transfer objects.
/// </summary>
public class BookingMapper
{
    /// <summary>
    /// Maps a Booking domain entity to a BookingDto data transfer object.
    /// </summary>
    /// <param name="booking">The Booking domain entity containing booking details to be mapped.</param>
    /// <returns>A BookingDto object populated with data from the provided Booking domain entity.</returns>
    public BookingDto MapToBookingDto(Booking booking)
    {
        var bookingDto = new BookingDto
        {
            BookingId = booking.BookingId,
            BookingDate = booking.BookingDate,
            Code = booking.Code,
            Type = booking.Type,
            CustomerId = booking.CustomerId,
            UserId = booking.UserId
        };
        return bookingDto;
    }

    /// <summary>
    /// Maps a dynamic booking command to a Booking domain entity.
    /// </summary>
    /// <param name="dynamicBooking">The dynamic booking command to map.
    /// It can be of the type CreateBookingCommand or UpdateBookingCommand.</param>
    /// <returns>A Booking domain entity populated with data from the dynamic booking command.</returns>
    /// <exception cref="ArgumentException">Thrown when the type of dynamicBooking is not supported.</exception>
    /// <remarks>
    /// Patter matching is used to map the dynamic booking command to the appropriate Booking domain entity.
    /// </remarks>
    public Booking MapToBooking(dynamic dynamicBooking)
    {
        return dynamicBooking switch
        {
            CreateBookingCommand cmd => new Booking
            {
                BookingDate = cmd.BookingDate,
                Code = cmd.Code,
                Type = cmd.Type,
                CheckIn = cmd.CheckIn,
                CheckOut = cmd.CheckOut,
                CustomerId = cmd.CustomerId,
                UserId = cmd.UserId
            },
        
            UpdateBookingCommand cmd => new Booking
            {
                CheckIn = cmd.CheckIn,
                CheckOut = cmd.CheckOut
            },
        
            _ => throw new ArgumentException($"Tipo no soportado: {dynamicBooking?.GetType()?.Name ?? "null"}")
        };
    }

    /// <summary>
    /// Maps a Booking domain entity to a BookingDto object.
    /// </summary>
    /// <param name="bookings">The Booking domain entity to map from.</param> 
    /// <returns>A BookingDto object populated with data from the Booking domain entity.</returns>
    public IEnumerable<BookingDto> MapToBookingDto(IEnumerable<Booking> bookings)
    {
        var bookingsList = bookings.Select(x => new BookingDto
        {
            BookingId = x.BookingId,
            BookingDate = x.BookingDate,
            Code = x.Code,
            Type = x.Type,
            CustomerId = x.CustomerId,
            UserId = x.UserId
        });
        return bookingsList;
    }
}