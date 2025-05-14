namespace NubaHotel.BookingSystem.Domain.Entities
{
    // <summary>
    // Represents a user in the system.
    // </summary>
    // <remarks>
    // This class is part of the NubaHotel Booking Domain and is used to manage user information.
    // </remarks>
    public class User
    {
        // <summary>
        // Gets or sets the unique identifier for the user.
        // </summary>
        public int UserId { get; set; }

        // <summary>
        // Gets or sets the first name of the user.
        // </summary>
        public string ? FirstName { get; set; }

        // <summary>
        // Gets or sets the last name of the user.
        // </summary>
        public string ? LastName { get; set; }

        // <summary>
        // Gets or sets the email address of the user.
        // </summary>
        public string ? Email { get; set; }

        // <summary>
        // Gets or sets the password of the user.
        // </summary>
        public string ? Password { get; set; }

        // <summary>
        // Salt used for hashing the password.
        // </summary>
        public string ? Salt { get; set; }
    }
}
