namespace NubaHotel.BookingSystem.Application.CQRS.User.Command.CreateUser
{
    /// <summary>
    /// Represents the command to create a new user in the system.
    /// Encapsulates user details required for creation such as first name, last name, email, and password.
    /// </summary>
    public class CreateUserCommand
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

        // <summary>
        // Gets or sets the password of the user.
        // </summary>
        public string? Password { get; set; }
    }
}
