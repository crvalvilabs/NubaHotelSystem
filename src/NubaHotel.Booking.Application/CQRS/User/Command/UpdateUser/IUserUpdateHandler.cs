namespace NubaHotel.BookingSystem.Application.CQRS.User.Command.UpdateUser;

/// <summary>
/// Interface for handling the update of a user.
/// Contains the logic to handle the UpdateUserCommand.
/// </summary>
public interface IUpdateUserHandler
{
    /// <summary>
    /// Handles the update of a user.
    /// This method is called when an UpdateUserCommand is received.
    /// This method updates the user information based on the provided user ID and command data.
    /// </summary>
    /// <param name="userId">The unique identifier for the user to be updated.</param>
    /// <param name="updateUserCommand">The command containing the updated user data.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
    Task Handle(int userId, UpdateUserCommand updateUserCommand, CancellationToken cancellationToken);
}