using NubaHotel.BookingSystem.Application.DTOs;

namespace NubaHotel.BookingSystem.Application.Services
{
    /// <summary>
    /// Defines the contract for registering a user within the system.
    /// </summary>
    public interface IAuthenticateService
    {
        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="email">The email address of the user to register.</param>
        /// <param name="password">The password for the user's account.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the registration operation.</param>
        /// <returns>A task that represents the asynchronous operation, containing the result of the registration operation.</returns>       
        Task<TokenResult> AuthenticateAsync(string email, string password, CancellationToken cancellationToken);
    }
}
