namespace NubaHotel.BookingSystem.Domain.Exceptions
{
    /// <summary>
    /// Exception that is thrown when an entity cannot be found within the application's domain.
    /// </summary>
    /// <remarks>
    /// The <see cref="EntityNotFoundException"/> is intended to indicate that a requested entity, such as a user or other domain object,
    /// was not found in the underlying data store or repository. This can be used to provide meaningful feedback to the application
    /// or user about the absence of the searched entity.
    /// </remarks>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Exception thrown when a specific entity cannot be located in the application's domain.
        /// </summary>
        public EntityNotFoundException() : base()
        {
            
        }
        
        /// <summary>
        /// Exception thrown when a specific entity cannot be located in the application's domain.
        /// </summary>
        /// <remarks>
        /// Typically used in scenarios where an entity, such as a database record, cannot be found.
        /// This provides a structured way of notifying the application about missing entities.
        /// </remarks>
        public EntityNotFoundException(string message) : base(message)
        {
            
        }

        /// <summary>
        /// Exception that is thrown when an entity cannot be found within the application's domain.
        /// </summary>
        /// <remarks>
        /// The <see cref="EntityNotFoundException"/> is intended to indicate that a requested entity, such as a user or other domain object,
        /// was not found in the underlying data store or repository. This can be used to provide meaningful feedback to the application
        /// or user about the absence of the searched entity.
        /// </remarks>
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
