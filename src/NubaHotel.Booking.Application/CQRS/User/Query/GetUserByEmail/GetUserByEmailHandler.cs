using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.User.Query.GetUserByEmail.Query
{
    /// <summary>
    /// Provides functionality for retrieving user information by their email address.
    /// </summary>
    /// <remarks>
    /// This class implements the <see cref="IGetUserByEmailHandler"/> interface and interacts with the
    /// <see cref="IUserRepository"/> to fetch user details encapsulated in a <see cref="UserDto"/>.
    /// </remarks>
    /// <example>
    /// This class is typically used in scenarios where the user's email serves as the unique identifier
    /// for retrieving user-specific data. This operation is asynchronous and includes cancellation token support.
    /// </example>
    public class GetUserByEmailHandler : IGetUserByEmailHandler
    {
        /// <summary>
        /// A private readonly field that holds a reference to the <see cref="IUserRepository"/> implementation.
        /// </summary>
        /// <remarks>
        /// The <c>_userRepository</c> field is used to interact with the user repository layer for performing data operations related to user entities,
        /// such as fetching user details by email or managing user-related data within the system.
        /// This dependency is injected via the constructor to promote better testability and adherence to the Dependency Inversion Principle.
        /// </remarks>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// A private readonly field that holds a reference to the <see cref="UserMapper"/> class instance.
        /// </summary>
        /// <remarks>
        /// The <c>_userMapper</c> field is responsible for handling the mapping between domain user entities
        /// and data transfer objects (DTOs). It is used within the class to convert user-related objects
        /// into appropriate forms required for the application logic, ensuring a separation of concerns
        /// between data and business layers. This dependency is injected to maintain modularity and facilitate testing.
        /// </remarks>
        private readonly UserMapper _userMapper;

        /// <summary>
        /// Represents the mechanism for retrieving user data based on an email address.
        /// </summary>
        /// <remarks>
        /// This class leverages the <see cref="IUserRepository"/> to perform database operations
        /// and fetch user details. It is implemented as a handler for commands or queries related
        /// to fetching user information using their email.
        /// </remarks>
        public GetUserByEmailHandler(IUserRepository userRepository, UserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        /// <summary>
        /// Handles the process of retrieving user details by their email address.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>A <see cref="UserDto"/> object containing the user's details.</returns>
        public async Task<UserDto> Handle(string email, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(email, cancellationToken);
            var userDto = _userMapper.MapToUserDto(user);
            return userDto;
        }
    }
}

