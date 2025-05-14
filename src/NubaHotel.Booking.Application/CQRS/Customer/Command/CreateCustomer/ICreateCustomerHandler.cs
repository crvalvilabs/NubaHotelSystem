namespace NubaHotel.BookingSystem.Application.CQRS.Customer.Command.CreateCustomer
{
    /// <summary>
    /// Defines a handler responsible for processing the creation of a customer within the application.
    /// </summary>
    public interface ICreateCustomerHandler
    {
        /// <summary>
        /// Handles the processing of a CreateCustomerCommand to create a customer.
        /// </summary>
        /// <param name="command">The CreateCustomerCommand containing the details of the customer to be created.</param>
        /// <param name="cancellationToken">Token to signal the cancellation of the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Handle(CreateCustomerCommand command, CancellationToken cancellationToken);
    }
}