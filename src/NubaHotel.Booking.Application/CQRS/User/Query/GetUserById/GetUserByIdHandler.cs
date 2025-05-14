using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.User.Query.GetUserById
{
    /// <summary>
    /// Handler for retrieving user information by ID.
    /// </summary>
    public class GetUserByIdHandler : IGetUserByIdHandler
    {
        /// <summary>
        /// The user query repository used to retrieve user data.
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// The user mapper used to map user entities to DTOs.
        /// </summary>
        private readonly UserMapper _userMapper;

        /// <summary>
        /// Constructor for GetUserByIdHandler.
        /// This constructor initializes the handler with the user query repository and user mapper.
        /// </summary>
        /// <param name="userRepository">The user query repository used to retrieve user data.</param>
        /// <param name="userMapper">The user mapper used to map user entities to DTOs.</param>
        public GetUserByIdHandler(IUserRepository userRepository, UserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        /// <summary>
        /// Handles the retrieval of user information by user ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be retrieved.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="UserDto"/> object containing the user information.</returns>
        public async Task<UserDto> Handle(int userId, CancellationToken cancellationToken)
        {
            var userSearched = await _userRepository.GetByIdAsync(userId, cancellationToken);
            var userDto = _userMapper.MapToUserDto(userSearched);
            return userDto;
        }
    }
}
