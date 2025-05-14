using NubaHotel.BookingSystem.Application.DTOs;

namespace NubaHotel.BookingSystem.Application.CQRS.User.Query.GetUserByEmail.Query;

/// <summary>
/// Represents a contract for retrieving user information based on their email address.
/// </summary>
/// <remarks>
/// This interface defines an operation to fetch a user's data encapsulated in a UserDto object,
/// using the provided email address as the search key.
/// </remarks>
public interface IGetUserByEmailHandler
{
    /// <summary>
    /// Handles the retrieval of a user's information based on their email address.
    /// </summary>
    /// <param name="email">The email address of the user to retrieve.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user information in a <see cref="UserDto"/> object.</returns>
    Task<UserDto> Handle(string email, CancellationToken cancellationToken);
}