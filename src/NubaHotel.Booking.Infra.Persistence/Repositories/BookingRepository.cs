using Microsoft.EntityFrameworkCore;
using NubaHotel.BookingSystem.Domain.Entities;
using NubaHotel.BookingSystem.Domain.Exceptions;
using NubaHotel.BookingSystem.Domain.Repositories;
using NubaHotel.BookingSystem.Infra.Persistence.Database;
using NubaHotel.BookingSystem.Infra.Persistence.Mappers;

namespace NubaHotel.BookingSystem.Infra.Persistence.Repositories
{
    /// <summary>
    /// Represents a repository for managing booking data in the Nuba Hotel system.
    /// Provides methods to interact with the underlying database for creating,
    /// retrieving, updating, and deleting booking records.
    /// </summary>
    public class BookingRepository : IBookingRepository
    {
        /// <summary>
        /// Represents the instance of the <see cref="NubaHotelContext"/> used within
        /// the repository for interacting with the database. This context facilitates
        /// access to database sets and provides functionality to perform CRUD operations
        /// on entities such as bookings, users, and customers.
        /// </summary>
        private readonly NubaHotelContext _nubaHotelContext;

        /// <summary>
        /// Represents the instance of the <see cref="BookingMapper"/> used for mapping
        /// data between domain entities and database entities. This facilitates the transformation
        /// of booking data between the application layer and persistence layer in the repository.
        /// </summary>
        private readonly BookingMapper _bookingMapper;

        /// <summary>
        /// Represents a repository responsible for managing booking data within
        /// the Nuba Hotel Booking System. This repository acts as an abstraction
        /// over the underlying data persistence layer, facilitating CRUD operations
        /// for booking-related entities.
        /// </summary>
        public BookingRepository(NubaHotelContext nubaHotelContext, BookingMapper bookingMapper)
        {
            _nubaHotelContext = nubaHotelContext;
            _bookingMapper = bookingMapper;
        }

        /// <summary>
        /// Asynchronously retrieves all booking records from the data persistence layer.
        /// Maps the data to a collection of domain-level booking entities.
        /// </summary>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used to propagate notification of cancellation.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation. The task's result contains
        /// a collection of domain-level booking entities.
        /// </returns>
        public async Task<IEnumerable<Booking>> GetAllAsync(CancellationToken cancellationToken)
        {
            var bookings = await _nubaHotelContext.Bookings!
                .Select(x => new Booking
                {
                    BookingId = x.BookingId,
                    BookingDate = x.BookingDate,
                    CheckIn = x.CheckIn,
                    CheckOut = x.CheckOut,
                    Code = x.Code,
                    Type = x.Type,
                    CustomerId = x.CustomerId,
                    UserId = x.UserId
                }).ToListAsync(cancellationToken);
            return bookings;
        }

        /// <summary>
        /// Asynchronously retrieves a booking entity by its unique identifier.
        /// Throws an exception if the booking entity is not found.
        /// </summary>
        /// <param name="id">The unique identifier of the booking to be retrieved.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation, containing the booking entity corresponding to the given identifier.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when no booking entity with the specified identifier is found.</exception>
        public async Task<Booking> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var bookinEntity = await _nubaHotelContext.Bookings!
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(x => x.BookingId == id, cancellationToken) 
                               ?? throw new EntityNotFoundException("Booking not found");
            var booking = _bookingMapper.MapToBooking(bookinEntity);
            return booking;
        }

        /// <summary>
        /// Asynchronously adds a new booking to the data store. The provided booking
        /// is mapped to a persistent entity before being saved, and changes are committed
        /// to the database.
        /// </summary>
        /// <param name="booking">The booking entity to be added to the system.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddBookingAsync(Booking booking, CancellationToken cancellationToken)
        {
            var bookingEntity = _bookingMapper.MapToBookingEntity(booking);
            _nubaHotelContext.Bookings!.Add(bookingEntity);
            await _nubaHotelContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Updates an existing booking in the repository with the specified details.
        /// </summary>
        /// <param name="id">The identifier of the booking to update.</param>
        /// <param name="booking">The updated booking details.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when the booking with the specified ID is not found in the repository.</exception>
        public async Task UpdateBookingAsync(int id, Booking booking, CancellationToken cancellationToken)
        {
            var bookingEntity = await _nubaHotelContext.Bookings!
                                    .FirstOrDefaultAsync(x => x.BookingId == id, cancellationToken) 
                                ?? throw new EntityNotFoundException("Booking not found");
                bookingEntity.CheckIn = booking.CheckIn;
                bookingEntity.CheckOut = booking.CheckOut;
            await _nubaHotelContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Deletes a booking from the database based on the specified booking ID. If the booking
        /// does not exist, an exception is thrown.
        /// </summary>
        /// <param name="id">The unique identifier of the booking to be deleted.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <exception cref="EntityNotFoundException">Thrown when the booking with the specified ID does not exist.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteBookingAsync(int id, CancellationToken cancellationToken)
        {
            var bookingToDelete = await _nubaHotelContext.Bookings!
                                      .FirstOrDefaultAsync(x => x.BookingId == id, cancellationToken) 
                                  ?? throw new EntityNotFoundException("Booking not found");
            _nubaHotelContext.Bookings!.Remove(bookingToDelete);
        }
    }
}