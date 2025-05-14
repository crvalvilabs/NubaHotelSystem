namespace NubaHotel.BookingSystem.Application.CQRS.Customer.Command.CreateCustomer;

/// <summary>
/// Represents a command to create a customer in the system.
/// </summary>
public class CreateCustomerCommand
{
    /// <summary>
    /// Gets or sets the full name of the customer for the create customer command.
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets the document number of the customer for the create customer command.
    /// </summary>
    public string? DocumentNumber { get; set; }
}