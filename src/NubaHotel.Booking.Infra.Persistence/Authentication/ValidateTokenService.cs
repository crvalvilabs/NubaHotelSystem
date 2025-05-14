using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Application.External;
using NubaHotel.BookingSystem.Application.Services;
using NubaHotel.BookingSystem.Domain.Entities;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Infra.Persistence.Authentication
{
    /// <summary>
    /// Service implementation for validating user tokens and managing refresh token functionality.
    /// This service checks the validity of a user's token and handles the process of generating a new refresh token if necessary.
    /// </summary>
    public class ValidateTokenService : IValidateTokenService
    {
        /// <summary>
        /// A repository instance for managing user tokens, specifically handling operations
        /// related to refresh tokens, such as retrieving, adding, updating, and deleting tokens.
        /// </summary>
        private readonly IUserTokenRepository _tokenRepository;

        /// <summary>
        /// A service instance responsible for retrieving refresh tokens linked to a user's email.
        /// This service is used within the token validation process to acquire or regenerate
        /// refresh tokens as needed to maintain secure authentication.
        /// </summary>
        private readonly IGetRefreshTokenService _getRefreshTokenService;

        /// <summary>
        /// A service responsible for retrieving a JWT access token based on the provided email.
        /// This is used to facilitate the process of token generation and validation.
        /// </summary>
        private readonly IGetAccessTokenService _getAccessTokenService;

        /// <summary>
        /// Service implementation for validating user tokens and managing refresh token functionality.
        /// This service ensures the validity of user tokens and provides mechanisms for refreshing tokens
        /// through operations integrated with the underlying token repository.
        /// </summary>
        public ValidateTokenService(IUserTokenRepository tokenRepository, IGetRefreshTokenService getRefreshTokenService, 
            IGetAccessTokenService getAccessTokenService)
        {
            _tokenRepository = tokenRepository;
            _getRefreshTokenService = getRefreshTokenService;
            _getAccessTokenService = getAccessTokenService;
        }

        /// <summary>
        /// Validates the refresh token associated with the specified user. If the token
        /// has expired, it generates a new refresh token; otherwise, it returns the existing token.
        /// </summary>
        /// <param name="email">The email of the user for whom the refresh token is being validated.</param>
        /// <param name="userId">The unique identifier of the user associated with the refresh token.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="UserToken"/> object representing the validated or newly generated refresh token.</returns>
        public async Task<TokenResult> ValidateRefreshTokenAsync(string email, int userId,
            CancellationToken cancellationToken)
        {
            var isExists = await UserHasRefreshToken(userId, cancellationToken);
            if (isExists)
            {
                var user = await _tokenRepository.GetRefreshToken(userId, cancellationToken);
                
                await CheckAndRefreshTokenIfExpired(user, email, userId, cancellationToken);

                var accessToken = _getAccessTokenService.GetToken(email);
                var result = new TokenResult
                {
                    Access = accessToken.Access,
                    Email = email,
                    Expires = accessToken.Expires
                };
                return result;
            }

            return await GetTokenAsync(email, userId, cancellationToken);
        }

        /// <summary>
        /// Determines whether a refresh token exists for the specified user ID.
        /// This method interacts with the token repository to verify the presence of a refresh token
        /// associated with the given user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user whose refresh token existence is being checked.</param>
        /// <param name="cancellationToken">A token to observe for cancellation during the execution of the operation.</param>
        /// <returns>A task that resolves to a boolean value indicating whether a refresh token exists for the user.</returns>
        private async Task<bool> UserHasRefreshToken(int userId, CancellationToken cancellationToken)
        {
            var isExist = await _tokenRepository.ExistsRefreshToken(userId, cancellationToken);
            return isExist;
        }

        /// <summary>
        /// Checks whether the provided user token has expired and refreshes it if necessary.
        /// If the token is expired, it deletes the old refresh token and generates a new one.
        /// </summary>
        /// <param name="user">The user token to be validated and potentially refreshed.</param>
        /// <param name="email">The email of the user associated with the token.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        private async Task CheckAndRefreshTokenIfExpired(UserToken user, string email, int userId,
            CancellationToken cancellationToken)
        {
            if (user.ExpiresAt < DateTime.UtcNow)
            {
                await DeleteRefreshTokenAsync(userId, cancellationToken);
                await RegenerateRefreshTokenAsync(email, userId, cancellationToken);
            }
        }

        /// <summary>
        /// Asynchronously deletes the refresh token of a specified user from the token repository.
        /// </summary>
        /// <param name="userId">The unique identifier of the user whose refresh token is to be deleted.</param>
        /// <param name="cancellationToken">A cancellation token to observe while performing the delete operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task DeleteRefreshTokenAsync(int userId, CancellationToken cancellationToken)
        {
            await _tokenRepository.DeleteRefreshToken(userId, cancellationToken);
        }

        /// <summary>
        /// Recreates a refresh token for a specified user. This method generates a new refresh token, associates it with the user, and stores it in the repository.
        /// </summary>
        /// <param name="email">The email address associated with the user for whom the token is being regenerated.</param>
        /// <param name="id">The unique identifier of the user requiring a new refresh token.</param>
        /// <param name="cancellationToken">A token that can be used to propagate notification that the operation should be canceled.</param>
        /// <returns>A <see cref="UserToken"/> object containing the newly generated refresh token and associated details.</returns>
        private async Task RegenerateRefreshTokenAsync(string email, int id,
            CancellationToken cancellationToken)
        {
            var token = _getRefreshTokenService.GetToken(email);
            var userToken = new UserToken
            {
                UserId = id,
                RefreshToken = token.Refresh,
                ExpiresAt = token.Expires
            };
            await _tokenRepository.AddRefreshToken(userToken, cancellationToken);
        }

        /// <summary>
        /// Retrieves a new token result for the specified user by generating an access token and a refresh token.
        /// Combines the generated tokens and returns them along with the associated email.
        /// </summary>
        /// <param name="email">The email address of the user for whom the tokens are being generated.</param>
        /// <param name="id">The unique identifier of the user for whom the tokens are being generated.</param>      
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>       
        /// <returns>A <see cref="TokenResult"/> containing the generated access token, refresh token, and the associated email address.</returns>
        private async Task<TokenResult> GetTokenAsync(string email, int id, CancellationToken cancellationToken)
        {
            var accessToken = _getAccessTokenService.GetToken(email);
            var refreshToken = _getRefreshTokenService.GetToken(email);
            var result = new TokenResult
            {
                Access = accessToken.Access,
                Refresh = refreshToken.Refresh,
                Email = email,
                Expires = accessToken.Expires
            };

            var token = new UserToken
            {
                UserId = id,
                RefreshToken = refreshToken.Refresh,
                ExpiresAt = refreshToken.Expires
            };

            await _tokenRepository.AddRefreshToken(token, cancellationToken);
            return result;
        }
    }
}