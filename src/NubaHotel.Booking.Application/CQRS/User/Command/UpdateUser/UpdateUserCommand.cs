namespace NubaHotel.BookingSystem.Application.CQRS.User.Command.UpdateUser
{
    /// <summary>
    /// Represents a command to update user information.
    /// This command encapsulates the data necessary for updating a user's details
    /// such as first name, last name, and email.
    /// </summary>
    public class UpdateUserCommand
    {
        // <summary>
        // Gets or sets the first name of the user.
        // </summary>
        public string? FirstName { get; set; }

        // <summary>
        // Gets or sets the last name of the user.
        // </summary>
        public string? LastName { get; set; }

        // <summary>
        // Gets or sets the email address of the user.
        // </summary>
        public string? Email { get; set; }
    }
}
