using NubaHotel.BookingSystem.Domain.Entities;

namespace NubaHotel.BookingSystem.Domain.Repositories
{
    /// <summary>
    /// Defines the contract for handling booking-related operations in the NubaHotel system.
    /// </summary>
    /// <remarks>
    /// This interface provides methods for managing bookings, including retrieving, adding, updating, and deleting bookings.
    /// It interacts with the Booking entity and relies on asynchronous operations.
    /// </remarks>
    public interface IBookingRepository
    {
        /// <summary>
        /// Retrieves all bookings asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of bookings.</returns>
        Task<IEnumerable<Booking>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a booking by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the booking to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation, containing the booking if found.</returns>
        Task<Booking> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new booking asynchronously.
        /// </summary>
        /// <param name="booking">The booking entity to be added.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous addition of the booking.</returns>
        Task AddBookingAsync(Booking booking, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing booking asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the booking to update.</param>
        /// <param name="booking">The updated booking details.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateBookingAsync(int id, Booking booking, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a booking by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the booking to delete.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteBookingAsync(int id, CancellationToken cancellationToken);
    }
}