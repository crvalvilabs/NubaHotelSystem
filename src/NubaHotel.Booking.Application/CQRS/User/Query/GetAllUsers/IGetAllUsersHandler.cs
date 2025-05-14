using NubaHotel.BookingSystem.Application.DTOs;

namespace NubaHotel.BookingSystem.Application.CQRS.User.Query.GetAllUsers
{
    /// <summary>
    /// Interface for the handler that retrieves all users.
    /// </summary>
    public interface IGetAllUsersHandler
    {
        /// <summary>
        /// Executes the query to retrieve all users.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="global::NubaHotel.Booking.Application.CQRS.User.Query.GetUserById.GetUserByIdQuery"/>.</returns>
        Task<IEnumerable<UserDto>> Handle(CancellationToken cancellationToken);
    }
}
