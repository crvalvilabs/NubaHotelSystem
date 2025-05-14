using Microsoft.EntityFrameworkCore;
using NubaHotel.BookingSystem.Domain.Entities;
using NubaHotel.BookingSystem.Domain.Exceptions;
using NubaHotel.BookingSystem.Domain.Repositories;
using NubaHotel.BookingSystem.Infra.Persistence.Database;
using NubaHotel.BookingSystem.Infra.Persistence.Entities;
using NubaHotel.BookingSystem.Infra.Persistence.Mappers;

namespace NubaHotel.BookingSystem.Infra.Persistence.Repositories
{
    /// <summary>
    /// Provides an implementation for managing user tokens, specifically tailored to handle
    /// operations like updating refresh tokens within the persistence store.
    /// </summary>
    public class UserTokenRepository : IUserTokenRepository
    {
        /// <summary>
        /// Represents the database context instance used to interact with the Nuba Hotel persistence layer.
        /// Acts as the primary data source for performing operations on entities such as users,
        /// bookings, customers, and user tokens.
        /// </summary>
        private readonly NubaHotelContext _nubaHotelContext;

        /// <summary>
        /// Responsible for mapping data between the domain-level <see cref="UserToken"/> representation
        /// and the persistence-level <see cref="UserTokenEntity"/>. Provides transformation methods
        /// to enable seamless conversion of user token data models for database operations and domain logic.
        /// </summary>
        private readonly TokenMapper _tokenMapper;

        /// <summary>
        /// Repository class for managing user tokens in the persistence layer.
        /// Handles operations such as updating refresh tokens.
        /// </summary>
        public UserTokenRepository(NubaHotelContext nubaHotelContext, TokenMapper tokenMapper)
        {
            _nubaHotelContext = nubaHotelContext;
            _tokenMapper = tokenMapper;
        }

        /// <summary>
        /// Adds a new refresh token to the persistence layer for the specified user token.
        /// </summary>
        /// <param name="userToken">The user token entity to be added to the persistence layer.</param>       
        /// <param name="cancellationToken">A token for handling cancellation of the asynchronous operation.</param>
        /// <returns>Returns the user token entity added to the persistence layer.</returns>
        public async Task AddRefreshToken(dynamic userToken, CancellationToken cancellationToken)
        {
            var userTokenEntity = _tokenMapper.MapToUserTokenEntity(userToken);
            await _nubaHotelContext.UserTokens!.AddAsync(userTokenEntity, cancellationToken);
            await _nubaHotelContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves the refresh token associated with a specific user ID.
        /// </summary>
        /// <param name="id">The unique identifier of the user for which the refresh token is being retrieved.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete, allowing the operation to be canceled.</param>
        /// <returns>A <see cref="UserToken"/> object containing the refresh token information for the specified user.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when no associated refresh token is found for the specified user ID.</exception>
        public async Task<UserToken> GetRefreshToken(int id, CancellationToken cancellationToken)
        {
            var userTokenEntity = await _nubaHotelContext.UserTokens!
                .FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
            var userToken = _tokenMapper.MapToUserToken(userTokenEntity!);
            return userToken;
        }

        /// <summary>
        /// Deletes a user refresh token from the persistence layer.
        /// Removes the refresh token associated with the specified user ID.
        /// </summary>
        /// <param name="id">The unique identifier of the user whose refresh token is to be deleted.</param>
        /// <param name="cancellationToken">A token that can be used to propagate notifications that the operation should be canceled.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when no refresh token exists for the specified user ID.</exception>
        public async Task DeleteRefreshToken(int id, CancellationToken cancellationToken)
        {
            var userTokenEntity = await _nubaHotelContext.UserTokens!
                .FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
            _nubaHotelContext.UserTokens!.Remove(userTokenEntity!);
            await _nubaHotelContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Checks if a refresh token exists for the specified user ID in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the user associated with the refresh token.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the refresh token exists.</returns>
        public async Task<bool> ExistsRefreshToken(int id, CancellationToken cancellationToken)
        {
            return await _nubaHotelContext.UserTokens!.AnyAsync(x => x.UserId == id, cancellationToken);
        }
    }
}