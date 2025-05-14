using NubaHotel.BookingSystem.Application.DTOs;

namespace NubaHotel.BookingSystem.Application.CQRS.User.Command.CreateUser
{
    /// <summary>
    /// Interface for handling the creation of a new user.
    /// This interface defines the contract for the CreateUserHandler.
    /// </summary>
    public interface ICreateUserHandler
    {
        /// <summary>
        /// Handles the creation of a new user.
        /// This method is called when a CreateUserCommand is received.
        /// </summary>
        /// <param name="createUserCommand">The command containing the user data.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        Task Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken);
    }
}
