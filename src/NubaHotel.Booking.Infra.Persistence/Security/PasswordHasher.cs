using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;
using NubaHotel.BookingSystem.Domain.Security;

namespace NubaHotel.BookingSystem.Infra.Persistence.Security
{
    /// <summary>
    /// Implements the IPasswordHasher interface for hashing and verifying passwords.
    /// This class uses the Argon2Id algorithm for secure password hashing.
    /// </summary>
    public class PasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// Hashes the provided password using the Argon2Id algorithm.
        /// This method generates a random salt and uses it to hash the password.
        /// The hashed password and the salt are returned as a tuple.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>A tuple containing the hashed password and the salt used for hashing.</returns>
        public Tuple<string, string> HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(16);
            var argon2Id = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                Iterations = 2,
                MemorySize = 19456,
                DegreeOfParallelism = 1
            };

            var hash = argon2Id.GetBytes(32);
            
            return new Tuple<string, string>(Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

        /// <summary>
        /// Verifies a provided password against a stored hashed password.
        /// This method uses the Argon2Id algorithm to hash the provided password with the stored salt
        /// and compares the result with the stored hash.
        /// </summary>
        /// <param name="password">The password to verify.</param>
        /// <param name="storedHash">The stored hashed password.</param>
        /// <param name="storedSalt">The salt used to hash the stored password.</param>
        /// <returns>True if the password matches the stored hash; otherwise, false.</returns>
        public bool VerifyHashedPassword(string password, string storedHash, string storedSalt)
        {
            var salt = Convert.FromBase64String(storedSalt);
            var expectedHash = storedHash;

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 1,
                MemorySize = 19456,
                Iterations = 2
            };

            var hash = argon2.GetBytes(32);
            return Convert.ToBase64String(hash) == expectedHash;
        }
    }
}
