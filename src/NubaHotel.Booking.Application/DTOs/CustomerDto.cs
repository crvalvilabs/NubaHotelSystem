namespace NubaHotel.BookingSystem.Application.DTOs;

/// <summary>
/// Data Transfer Object (DTO) for Customer entity.
/// </summary>
/// <remarks>
/// This class is used to transfer customer-related data between different layers
/// in the application, such as services and controllers. It contains the necessary
/// properties to represent a customer.
/// </remarks>
public class CustomerDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the customer.
    /// </summary>
    /// <remarks>
    /// This property is used to uniquely identify a customer within the system.
    /// It is mapped from the corresponding Customer entity's primary key.
    /// </remarks>
    public int CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the full name of the customer.
    /// </summary>
    /// <remarks>
    /// This property represents the complete name of a customer, typically including
    /// the first name, middle name (if applicable), and last name. It is primarily
    /// used for display or identification purposes in the application.
    /// </remarks>
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets the document number associated with the customer.
    /// </summary>
    /// <remarks>
    /// This property represents a unique identifier for the customer's document,
    /// such as an identity card number, passport number, or other official document identification.
    /// It is used to verify and process customer-related transactions within the system.
    /// </remarks>
    public string? DocumentNumber { get; set; }
}