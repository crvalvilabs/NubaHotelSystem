using NubaHotel.BookingSystem.Domain.Entities;

namespace NubaHotel.BookingSystem.Domain.Repositories;

/// <summary>
/// Represents a repository interface for managing user tokens, specifically for handling operations
/// related to refresh tokens.
/// </summary>
public interface IUserTokenRepository
{
    /// <summary>
    /// Adds a new refresh token for a user.
    /// </summary>
    /// <param name="userToken">The <see cref="UserToken"/> object containing user-specific token details to be added.</param>
    /// <param name="cancellationToken">A cancellation token to observe while performing the operation.</param>
    Task AddRefreshToken(dynamic userToken, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves the refresh token for a specified user by their identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user whose refresh token is to be retrieved.</param>
    /// <param name="cancellationToken">A cancellation token to observe while performing the operation.</param>
    /// <returns>A <see cref="UserToken"/> object containing the refresh token details of the specified user.</returns>
    Task<UserToken> GetRefreshToken(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes the refresh token associated with the specified user.
    /// </summary>
    /// <param name="id">The unique identifier of the user whose refresh token needs to be deleted.</param>
    /// <param name="cancellationToken">A cancellation token to observe while performing the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteRefreshToken(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Checks if a refresh token exists for the specified user ID in the database.
    /// </summary>
    /// <param name="id">The unique identifier of the user associated with the refresh token.</param>
    /// <param name="cancellationToken">A cancellation token to observe while performing the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the refresh token exists.</returns>
    Task<bool> ExistsRefreshToken(int id, CancellationToken cancellationToken);
}