namespace NubaHotel.BookingSystem.Application.DTOs
{
    // <summary>
    // Represents a Data Transfer Object (DTO) for user information.
    // </summary>
    // <remarks>
    // This class is used to transfer user data between different layers of the application.
    // </remarks>
    public class UserDto
    {
        // <summary>
        // Gets or sets the unique identifier for the user.
        // </summary>
        public int UserId { get; set; }

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
