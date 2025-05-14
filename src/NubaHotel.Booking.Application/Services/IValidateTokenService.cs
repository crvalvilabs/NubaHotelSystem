using NubaHotel.BookingSystem.Application.DTOs;

namespace NubaHotel.BookingSystem.Application.Services;

/// <summary>
/// Provides methods for validating and managing tokens such as access tokens
/// and refresh tokens, as well as generating a new refresh token.
/// </summary>
public interface IValidateTokenService
{
    /// <summary>
    /// Validates the refresh token for a specified user based on the provided email and user ID.
    /// </summary>
    /// <param name="email">The email address of the user associated with the refresh token.</param>
    /// <param name="userId">The unique identifier of the user associated with the refresh token.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete, used to cancel the operation if needed.</param>
    /// <returns>A task that represents the asynchronous operation, containing a <see cref="TokenResult"/> object with updated token details if validation is successful.</returns>
    Task<TokenResult> ValidateRefreshTokenAsync(string email, int userId, CancellationToken cancellationToken);
}