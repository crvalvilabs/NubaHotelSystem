namespace NubaHotel.BookingSystem.Domain.Exceptions;

public class CredentialsException : Exception
{
    /// <summary>
    /// Represents errors that occur related to credential issues.
    /// </summary>
    public CredentialsException()
    {
        
    }

    /// <summary>
    /// Represents errors that occur related to credential issues.
    /// </summary>
    public CredentialsException(string message) : base(message)
    {
    }

    /// <summary>
    /// Represents errors that occur related to credential issues.
    /// </summary>
    public CredentialsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}