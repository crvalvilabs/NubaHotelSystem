using NubaHotel.BookingSystem.Domain.Entities;
using NubaHotel.BookingSystem.Infra.Persistence.Entities;

namespace NubaHotel.BookingSystem.Infra.Persistence.Mappers;

/// <summary>
/// Provides functionalities to map data between domain-level <see cref="UserToken"/> objects
/// and persistence-level <see cref="UserTokenEntity"/> objects.
/// Responsible for transforming user token data to support operations in different layers
/// of the application, ensuring a clear separation between domain and infrastructure concerns.
/// </summary>
public class TokenMapper
{
    /// <summary>
    /// Maps a domain-level <see cref="UserToken"/> object to a persistence-level <see cref="UserTokenEntity"/> object.
    /// This method facilitates the transformation of user token data between different layers
    /// of the application.
    /// </summary>
    /// <param name="token">The <see cref="UserToken"/> instance representing the domain-level user token to be mapped.</param>
    /// <returns>Returns a <see cref="UserTokenEntity"/> object representing the persistence-level equivalent of the input <see cref="UserToken"/>.</returns>
    public UserTokenEntity MapToUserTokenEntity(dynamic token)
    {
        var tokenEntity = new UserTokenEntity
        {
            UserId = token.UserId,
            RefreshToken = token.RefreshToken,
            ExpiresAt = token.ExpiresAt
        };
        return tokenEntity;
    }

    /// <summary>
    /// Maps a persistence-level <see cref="UserTokenEntity"/> object to a domain-level <see cref="UserToken"/> object.
    /// This method facilitates the transformation of user token data between the persistence and domain layers
    /// of the application.
    /// </summary>
    /// <param name="tokenEntity">The <see cref="UserTokenEntity"/> instance representing the persistence-level user token to be mapped.</param>
    /// <returns>Returns a <see cref="UserToken"/> object representing the domain-level equivalent of the input <see cref="UserTokenEntity"/>.</returns>
    public UserToken MapToUserToken(UserTokenEntity tokenEntity)
    {
        var token = new UserToken
        {
            UserId = tokenEntity.UserId,
            RefreshToken = tokenEntity.RefreshToken,
            ExpiresAt = tokenEntity.ExpiresAt
        };
        return token; 
    }
}