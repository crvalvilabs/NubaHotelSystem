namespace NubaHotel.BookingSystem.Application.CQRS.Customer.Command.UpdateCustomer
{
    /// <summary>
    /// Represents a command to update customer information.
    /// </summary>
    public class UpdateCustomerCommand
    {
        /// <summary>
        /// Gets or sets the full name of the customer being updated.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Gets or sets the document number associated with the customer being updated.
        /// </summary>
        public string? DocumentNumber { get; set; }
    }
}