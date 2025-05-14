namespace NubaHotel.BookingSystem.Infra.Persistence.Entities;

/// <summary>
/// Represents a token entity associated with a user, used for managing authentication and session handling.
/// </summary>
public class UserTokenEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the user token.
    /// This identifier is used to distinguish and manage individual user token entries.
    /// </summary>
    public int UserTokenId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the user associated with the token.
    /// This property links the token to a specific user entity within the system.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the refresh token associated with the user token.
    /// This token is used to get a new access token without requiring re-authentication.
    /// </summary>
    public string? RefreshToken { get; set; }

    /// <summary>
    /// Gets or sets the expiration date and time for the token.
    /// This property indicates when the token will no longer be valid or usable for authentication purposes.
    /// </summary>
    public DateTime? ExpiresAt { get; set; }
}