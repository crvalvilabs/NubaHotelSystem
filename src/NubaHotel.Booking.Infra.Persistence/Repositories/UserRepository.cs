using Microsoft.EntityFrameworkCore;
using NubaHotel.BookingSystem.Infra.Persistence.Database;
using NubaHotel.BookingSystem.Domain.Entities;
using NubaHotel.BookingSystem.Domain.Repositories;
using NubaHotel.BookingSystem.Infra.Persistence.Mappers;
using NubaHotel.BookingSystem.Domain.Security;
using NubaHotel.BookingSystem.Domain.Exceptions;

namespace NubaHotel.BookingSystem.Infra.Persistence.Repositories
{
    /// <summary>
    /// Represents a repository for managing user-related data and operations
    /// within the application.
    /// Responsible for interactions with the database related to users.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The database context for accessing user data.
        /// </summary>
        private readonly NubaHotelContext _nubaHotelContext;

        /// <summary>
        /// The mapper for converting between User and UserEntity.
        /// </summary>
        private readonly UserMapper _userMapper;

        /// <summary>
        /// The password hasher for hashing user passwords.
        /// </summary>
        private readonly IPasswordHasher _passwordHasher;

        /// <summary>
        /// Constructor for UserRepository.
        /// This constructor initializes the repository with the database context, user mapper, and password hasher.
        /// </summary>
        /// <param name="nubaHotelContext">The database context for accessing user data.</param>
        /// <param name="userMapper">The mapper for converting between User and UserEntity.</param>
        /// <param name="passwordHasher">The password hasher for hashing user passwords.</param>
        public UserRepository(NubaHotelContext nubaHotelContext, UserMapper userMapper, IPasswordHasher passwordHasher)
        {
            _nubaHotelContext = nubaHotelContext;
            _userMapper = userMapper;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// GetAllAsync
        /// This method retrieves all users from the database.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            var users = await _nubaHotelContext.Users!
                .Select(x => new User
                {
                    UserId = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                }).ToListAsync(cancellationToken);
            
            return users;
        }

        /// <summary>
        /// GetByIdAsync
        /// This method retrieves a user by their ID from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var userEntity = await _nubaHotelContext.Users!
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == id, cancellationToken) 
                       ?? throw new EntityNotFoundException("User not found");
            var userSearched = _userMapper.MapToUser(userEntity);
            return userSearched;
        }

        /// <summary>
        /// AddUserAsync
        /// </summary>
        /// <param name="user">The user entity to be added.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        public async Task AddUserAsync(User user, CancellationToken cancellationToken)
        {
            var (password, salt) = _passwordHasher.HashPassword(user.Password!);
            user.Password = password;
            user.Salt = salt;

            var userEntity = _userMapper.MapToUserEntity(user);

            _nubaHotelContext.Users!.Add(userEntity);
            await _nubaHotelContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Deletes a user with the specified user ID from the database.
        /// If the user does not exist, throws an EntityNotFoundException.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be deleted.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous delete operation.</returns>
        public async Task DeleteUserAsync(int userId, CancellationToken cancellationToken)
        {
            var userToDelete = await _nubaHotelContext.Users!
                .FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken) 
                               ?? throw new EntityNotFoundException("User not found");

            _nubaHotelContext.Users!.Remove(userToDelete);
            await _nubaHotelContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// UpdateUserAsync
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="user">The user entity to be updated.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        public async Task UpdateUserAsync(int id, User user, CancellationToken cancellationToken)
        {
            var userEntity = await _nubaHotelContext.Users!
                                 .FirstOrDefaultAsync(x => x.UserId == id, cancellationToken) 
                             ?? throw new EntityNotFoundException("User not found");

            if (!string.IsNullOrEmpty(user.FirstName))
            {
                userEntity.FirstName = user.FirstName;
            }
            if (!string.IsNullOrEmpty(user.LastName))
            {
                userEntity.LastName = user.LastName;
            }
            if (!string.IsNullOrEmpty(user.Email))
            {
                userEntity.Email = user.Email;
            }

            await _nubaHotelContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a user by their email address asynchronously.
        /// Throws an exception if the user is not found.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains the user associated with the given email address.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when no user with the specified email address is found.
        /// </exception>
        public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var userEntity = await _nubaHotelContext.Users!
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.Email == email, cancellationToken) 
                             ?? throw new EntityNotFoundException("User not found");
            var userSearched = _userMapper.MapToUser(userEntity);
            return userSearched;
        }

        /// <summary>
        /// UserExistsAsync
        /// </summary>
        /// <param name="email">The email of the user to check.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        public async Task UserExistsAsync(string email, CancellationToken cancellationToken)
        {
            var userExist = await _nubaHotelContext.Users!
                .AsNoTracking()
                .Where(x => x.Email == email)
                .AnyAsync(cancellationToken);
            if (userExist)
            {
                throw new EntityAlreadyExistsException("User already exists");
            }
        }

        /// <summary>
        /// Validates the credentials of a user by verifying the email and password.
        /// </summary>
        /// <param name="email">The email address of the user attempting to authenticate.</param>
        /// <param name="password">The plaintext password provided by the user.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the operation to complete.
        /// </param>
        /// <exception cref="EntityNotFoundException">Thrown if no user with the specified email is found in the database.
        /// </exception>
        /// <exception cref="CredentialsException">
        /// Thrown if the provided password does not match the stored hashed password for the user.</exception>
        public async Task ValidateCredentials(string email, string password, CancellationToken cancellationToken)
        {
            var userExist = await _nubaHotelContext.Users!
                                .FirstAsync(x => x.Email == email, cancellationToken) ??
                            throw new EntityNotFoundException("User not found");
            var isPasswordValid = _passwordHasher.VerifyHashedPassword(password, userExist.Password!, userExist.Salt!);
            if (!isPasswordValid)
            {
                throw new CredentialsException("Invalid credentials");
            }
        }
    }
}
