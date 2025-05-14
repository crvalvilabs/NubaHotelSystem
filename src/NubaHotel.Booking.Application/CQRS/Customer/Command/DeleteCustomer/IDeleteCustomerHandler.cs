namespace NubaHotel.BookingSystem.Application.CQRS.Customer.Command.DeleteCustomer
{
    /// <summary>
    /// Represents a contract for handling the deletion of a customer.
    /// </summary>
    /// <remarks>
    /// This interface defines the contract for the DeleteCustomerHandler.
    /// </remarks>
    public interface IDeleteCustomerHandler
    {
        /// <summary>
        /// Handles the operation of deleting a customer by their ID.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to delete.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Handle(int customerId, CancellationToken cancellationToken);
    }
}