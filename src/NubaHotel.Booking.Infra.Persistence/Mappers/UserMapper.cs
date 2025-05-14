using NubaHotel.BookingSystem.Domain.Entities;
using NubaHotel.BookingSystem.Infra.Persistence.Entities;

namespace NubaHotel.BookingSystem.Infra.Persistence.Mappers
{
    /// <summary>
    /// Mapper class for converting between User and UserEntity.
    /// </summary>
    public class UserMapper
    {
        /// <summary>
        /// Maps a User entity to a UserEntity.
        /// </summary>
        /// <param name="user">The User entity to map.</param>
        /// <returns>A UserEntity.</returns>
        public UserEntity MapToUserEntity(User user)
        {
            var userEntity = new UserEntity
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Salt = user.Salt
            };

            return userEntity;
        }

        /// <summary>
        /// Maps a UserEntity to a User entity.
        /// </summary>
        /// <param name="userEntity">The UserEntity to map.</param>
        /// <returns>A User entity.</returns>
        public User MapToUser(UserEntity userEntity)
        {
            var user = new User
            {
                UserId = userEntity.UserId,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email,
                Password = userEntity.Password,
                Salt = userEntity.Salt
            };
            return user;
        }
    }
}
