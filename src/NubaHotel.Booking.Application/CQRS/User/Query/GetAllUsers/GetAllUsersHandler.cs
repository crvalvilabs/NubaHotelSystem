using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.User.Query.GetAllUsers
{
    /// <summary>
    /// Handler for retrieving all users.
    /// </summary>
    /// <remarks>
    /// This class is responsible for handling the query to get all users.
    /// It uses the IUserQueryRepository to fetch user data and the IUserMapper to map the data to the appropriate model.
    /// </remarks>
    public class GetAllUsersHandler : IGetAllUsersHandler
    {
        /// <summary>
        /// The user query repository used to fetch user data.
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// The user mapper used to map user data to the appropriate model.
        /// </summary>
        private readonly UserMapper _userMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUsersHandler"/> class.
        /// </summary>
        /// <param name="userRepository">The user query repository used to fetch user data.</param>
        /// <param name="userMapper">The user mapper used to map user data to the appropriate model.</param>
        public GetAllUsersHandler(IUserRepository userRepository, UserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        // <summary>
        // Executes the query to retrieve all users.
        // </summary>
        // <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        // <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="UserDto"/>.</returns>
        public async Task<IEnumerable<UserDto>> Handle(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);
            var userModels = _userMapper.MapToUserDto(users);
            return userModels;
        }
    }
}
