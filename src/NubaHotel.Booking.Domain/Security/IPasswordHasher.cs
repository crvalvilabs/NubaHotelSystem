namespace NubaHotel.BookingSystem.Domain.Security
{
    /// <summary>
    /// Interface for password hashing and verification.
    /// Provides methods to hash a password and verify a hashed password against a provided password.
    /// This is useful for securely storing and checking user passwords.
    /// </summary>
    public interface IPasswordHasher
    {
        /// <summary>
        /// Hashes the provided password using a secure hashing algorithm.
        /// This method should be used to hash user passwords before storing them in a database.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hashed password as a string.</returns>
        Tuple<string, string> HashPassword(string password);

        /// <summary>
        /// Verifies a provided password against a stored hashed password.
        /// This method should be used to check if a user-provided password matches the stored hashed password.
        /// </summary>
        /// <param name="password">The password to verify.</param>
        /// <param name="storedHash">The stored hashed password.</param>
        /// <param name="storedSalt">The salt used to hash the stored password.</param>
        bool VerifyHashedPassword(string password, string storedHash, string storedSalt);
    }
}
