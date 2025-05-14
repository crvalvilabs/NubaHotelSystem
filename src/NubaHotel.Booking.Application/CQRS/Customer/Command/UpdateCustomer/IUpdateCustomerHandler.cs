namespace NubaHotel.BookingSystem.Application.CQRS.Customer.Command.UpdateCustomer
{
    /// <summary>
    /// Interface for handling customer update operations.
    /// </summary>
    public interface IUpdateCustomerHandler
    {
        /// <summary>
        /// Handles the update operation for a customer.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to be updated.</param>
        /// <param name="command">The command containing the updated customer information.</param>      
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Handle(int customerId, UpdateCustomerCommand command, CancellationToken cancellationToken);
    }
}