namespace NubaHotel.BookingSystem.Application.CQRS.User.Command.DeleteUser
{
    /// <summary>
    /// Interface for handling the deletion of a user.
    /// </summary>
    public interface IDeleteUserHandler
    {
        /// <summary>
        /// Handles the request to delete a user by their ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be deleted.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation of deleting a user.</returns>
        Task Handle(int userId, CancellationToken cancellationToken);
    }
}
