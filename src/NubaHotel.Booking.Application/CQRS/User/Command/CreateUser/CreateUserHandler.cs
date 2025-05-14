using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.User.Command.CreateUser
{
    /// <summary>
    /// Handler for creating a new user.
    /// Contains the logic to handle the CreateUserCommand.
    /// </summary>
    public class CreateUserHandler : ICreateUserHandler
    {
        /// <summary>
        /// Represents the dependency responsible for managing persistence and retrieval of user-related data,
        /// allowing interaction with the underlying data source for operations such as retrieving, adding,
        /// updating, or deleting User entities as part of the user management workflow.
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Represents the dependency responsible for mapping between user-related objects,
        /// such as converting a CreateUserCommand into a User entity, or mapping
        /// domain entities to DTOs within the context of the user creation workflow.
        /// </summary>
        private readonly UserMapper _userMapper;

        /// <summary>
        /// Handles the process of creating a new user by implementing the logic
        /// required to process a CreateUserCommand.
        /// </summary>
        public CreateUserHandler(IUserRepository userRepository, UserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        /// <summary>
        /// Handles the creation of a new user.
        /// This method is called when a CreateUserCommand is received.
        /// </summary>
        /// <param name="createUserCommand">The command containing the user data.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        public async Task Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
        {
            var user = _userMapper.MapToUser(createUserCommand);
            await _userRepository.AddUserAsync(user, cancellationToken);
        }
    }
}
