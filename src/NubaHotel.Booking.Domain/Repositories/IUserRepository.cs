using NubaHotel.BookingSystem.Domain.Entities;

namespace NubaHotel.BookingSystem.Domain.Repositories
{
    /// <summary>
    /// Defines the contract for a repository responsible for managing User entities.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves all users asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a user by their ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        Task<User> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The user entity to add.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        Task AddUserAsync(User user, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="user">The user entity to update.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        Task UpdateUserAsync(int id, User user, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a user with the specified ID asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be deleted.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteUserAsync(int userId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a user by their email address asynchronously.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        /// <returns>The user associated with the specified email address.</returns>
        Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if a user with the specified email exists.
        /// </summary>
        /// <param name="email">The email address to check.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        Task UserExistsAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// Validates user credentials by verifying the provided email and password.
        /// </summary>
        /// <param name="email">The email of the user whose credentials need to be validated.</param>
        /// <param name="password">The password corresponding to the specified email.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        Task ValidateCredentials(string email, string password, CancellationToken cancellationToken);
    }
}
