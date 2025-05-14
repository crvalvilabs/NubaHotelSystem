using NubaHotel.BookingSystem.Application.CQRS.User.Command.CreateUser;
using NubaHotel.BookingSystem.Application.CQRS.User.Command.UpdateUser;
using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Domain.Entities;

namespace NubaHotel.BookingSystem.Application.Mappers
{
    /// <summary>
    /// Mapper class for converting between User and UserDto.
    /// </summary>
    public class UserMapper
    {
        /// <summary>
        /// Maps a dynamic object, such as a CreateUserCommand, to a User entity.
        /// </summary>
        /// <param name="dynamicUser">The dynamic object to map, containing user information.</param>
        /// <returns>A mapped User entity.</returns>
        public User MapToUser(dynamic dynamicUser)
        {
            return dynamicUser switch
            {
                CreateUserCommand cmd => new User
                {
                    FirstName = cmd.FirstName,
                    LastName = cmd.LastName,
                    Email = cmd.Email,
                    Password = cmd.Password
                },
                UpdateUserCommand cmd => new User
                {
                    FirstName = cmd.FirstName,
                    LastName = cmd.LastName,
                    Email = cmd.Email
                },

                _ => throw new ArgumentException($"Tipo no soportado: {dynamicUser?.GetType()?.Name ?? "null"}")
            };
        }

        /// <summary>
        /// Maps a User entity to a UserDto.
        /// </summary>
        /// <param name="user">The User entity to map.</param>  
        /// <returns>A UserDto.</returns>
        public UserDto MapToUserDto(User user)
        {
            var userDto = new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return userDto;
        }

        /// <summary>
        /// Maps a list of User entities to a list of UserDto.
        /// </summary>
        /// <param name="users">The list of User entities to map.</param>
        /// <returns>A list of UserDto.</returns>
        public IEnumerable<UserDto> MapToUserDto(IEnumerable<User> users)
        {
            var usersList = users.Select(x => new UserDto
            {
                UserId = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            });

            return usersList;
        }
    }
}
