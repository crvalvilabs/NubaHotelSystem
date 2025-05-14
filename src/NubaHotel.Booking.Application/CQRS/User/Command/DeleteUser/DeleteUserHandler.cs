using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.User.Command.DeleteUser
{
    /// <summary>
    /// Handler for deleting a user.
    /// </summary>
    public class DeleteUserHandler : IDeleteUserHandler
    {
        /// <summary>
        /// Repository for accessing user data.
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Mapper for converting between User and UserEntity, DeleteUserCommand.
        /// </summary>
        private readonly UserMapper _userMapper;

        /// <summary>
        /// Constructor for DeleteUserHandler.
        /// Creates an instance of the handler with the specified user repository and mapper.
        /// </summary>
        /// <param name="userRepository">The user repository for accessing user data.</param>
        /// <param name="userMapper">The user mapper for converting between User and UserEntity.</param>
        public DeleteUserHandler(IUserRepository userRepository, UserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        /// <summary>
        /// Handles the request to delete a user by their ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be deleted.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation of deleting a user.</returns>
        public async Task Handle(int userId, CancellationToken cancellationToken)
        {
            var userExits = await _userRepository.GetByIdAsync(userId, cancellationToken);
            await _userRepository.DeleteUserAsync(userId, cancellationToken);
        }
    }
}
