using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Application.Services;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Infra.Persistence.Authentication;

/// <summary>
/// Provides an authentication service that handles user login and generates authentication tokens.
/// </summary>
public class AuthenticateService : IAuthenticateService
{
    /// <summary>
    /// A repository instance for managing user entities, including operations such as validation, retrieval,
    /// creation, update, and deletion of users. Used by the authentication service to interact with
    /// user data in the system.
    /// </summary>
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// A service instance for validating authentication tokens, encompassing access token
    /// and refresh token validation, as well as other token-related processes. Ensures the
    /// integrity and validity of user authentication states within the system.
    /// </summary>
    private readonly IValidateTokenService _validateTokenService;

    /// <summary>
    /// Represents a service responsible for handling user authentication processes.
    /// </summary>
    public AuthenticateService(IUserRepository userRepository, IValidateTokenService validateTokenService)
    {
        _userRepository = userRepository;
        _validateTokenService = validateTokenService;
    }

    /// <summary>
    /// Authenticates a user by verifying their credentials and generating authentication tokens.
    /// </summary>
    /// <param name="email">The email address of the user to authenticate.</param>
    /// <param name="password">The password of the user to authenticate.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation, containing a <see cref="TokenResult"/> object containing the generated authentication tokens.</returns>
    public async Task<TokenResult> AuthenticateAsync(string email, string password,
        CancellationToken cancellationToken)
    {
        await _userRepository.ValidateCredentials(email, password, cancellationToken);
        
        var user = await _userRepository.GetUserByEmailAsync(email, cancellationToken);
        
        var isValid = await _validateTokenService.ValidateRefreshTokenAsync(email, user.UserId, cancellationToken);

        return isValid;
    }
}