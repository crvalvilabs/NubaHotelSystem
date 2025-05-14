using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.User.Command.UpdateUser
{
    /// <summary>
    /// Handler for updating a user.
    /// Contains the logic to handle the UpdateUserCommand.
    /// </summary>
    public class UpdateUserHandler : IUpdateUserHandler
    {
        /// <summary>
        /// Provides access to user-related data operations.
        /// Used within the handler to perform actions like updating user information
        /// by interacting with the underlying data persistence layer.
        /// </summary>
        private readonly IUserRepository _userRepository;
        
        /// <summary>
        /// Mapper for converting between User and UpdateUserCommand, UserDto and GetUserById.
        /// </summary>
        private readonly UserMapper _userMapper;

        /// <summary>
        /// Constructor for UserUpdateHandler.
        /// Initializes the user repository and user mapper.
        /// </summary>
        public UpdateUserHandler(IUserRepository userRepository, UserMapper userMapper)
        {
            _userMapper = userMapper;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Handles the update of a user.
        /// This method is called when an UpdateUserCommand is received.
        /// This method updates the user information based on the provided user ID and command data.
        /// </summary>
        /// <param name="userId">The unique identifier for the user to be updated.</param>
        /// <param name="updateUserCommand">The command containing the updated user data.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        public async Task Handle(int userId, UpdateUserCommand updateUserCommand, CancellationToken cancellationToken)
        {
            var user = _userMapper.MapToUser(updateUserCommand);
            await _userRepository.UpdateUserAsync(userId, user, cancellationToken);
        }
    }
}
