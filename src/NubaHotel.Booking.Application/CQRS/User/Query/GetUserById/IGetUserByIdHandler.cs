using NubaHotel.BookingSystem.Application.DTOs;

namespace NubaHotel.BookingSystem.Application.CQRS.User.Query.GetUserById
{
    /// <summary>
    /// Interface for the handler that retrieves user information by ID.
    /// </summary>
    public interface IGetUserByIdHandler
    {
        /// <summary>
        /// Handles the retrieval of user information by user ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be retrieved.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="UserDto"/> containing the retrieved user information.</returns>
        Task<UserDto> Handle(int userId, CancellationToken cancellationToken);
    }
}
