namespace NubaHotel.BookingSystem.Application.DTOs;

/// <summary>
/// Represents the result of a refresh token operation.
/// </summary>
public class TokenResult
{
    /// <summary>
    /// Gets or sets the token value as part of the authentication process.
    /// </summary>
    public string? Refresh { get; set; }

    /// <summary>
    /// Gets or sets the access token value used for authentication and authorization.
    /// </summary>
    public string? Access { get; set; }

    /// <summary>
    /// Gets or sets the email address associated with the token operation.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the expiration date and time for the token.
    /// </summary>
    public DateTime? Expires { get; set; }
}