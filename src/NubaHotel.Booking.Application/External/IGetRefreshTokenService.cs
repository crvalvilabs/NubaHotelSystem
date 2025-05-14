using NubaHotel.BookingSystem.Application.DTOs;

namespace NubaHotel.BookingSystem.Application.External;

/// <summary>
/// Provides a service to retrieve a refresh token associated with a specific email.
/// </summary>
public interface IGetRefreshTokenService
{
    /// <summary>
    /// Retrieves a refresh token associated with the specified email.
    /// </summary>
    /// <param name="email">The email address to retrieve the refresh token for.</param>
    /// <returns>A <see cref="TokenResult"/> object containing the refresh token and expiration date.</returns>   
    TokenResult GetToken(string email);
}