using NubaHotel.BookingSystem.Application.DTOs;

namespace NubaHotel.BookingSystem.Application.External;

/// <summary>
/// Interface for a service that retrieves a JWT token based on the provided email.
/// </summary>
public interface IGetAccessTokenService
{
    /// <summary>
    /// Retrieves a JWT token for the provided email.
    /// </summary>
    /// <param name="email">The email of the user for whom the token is being retrieved.</param>
    /// <returns>A TokenResult object containing access and refresh tokens, along with associated metadata.</returns>
    TokenResult GetToken(string email);
}