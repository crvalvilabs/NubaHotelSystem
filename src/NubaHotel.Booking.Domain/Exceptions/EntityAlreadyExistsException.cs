namespace NubaHotel.BookingSystem.Domain.Exceptions;

/// <summary>
/// Represents an exception thrown when an attempt is made to create or add an entity
/// that already exists in the system.
/// </summary>
public class EntityAlreadyExistsException : Exception
{
    /// <summary>
    /// Represents an exception thrown when an attempt is made to create or add an entity
    /// that already exists in the system.
    /// </summary>
    public EntityAlreadyExistsException()
    {
        
    }

    /// <summary>
    /// Represents an exception thrown when an attempt is made to create or add an entity
    /// that already exists in the system.
    /// </summary>
    public EntityAlreadyExistsException(string message) : base(message)
    {
        
    }

    /// <summary>
    /// Represents an exception thrown when an attempt is made to create or add an entity
    /// that already exists in the system.
    /// </summary>
    public EntityAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}