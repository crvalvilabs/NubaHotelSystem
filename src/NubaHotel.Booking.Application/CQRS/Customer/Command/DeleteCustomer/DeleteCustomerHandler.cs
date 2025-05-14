using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.Customer.Command.DeleteCustomer
{
    /// <summary>
    /// Handles the deletion of a customer by using a repository to remove the specified customer's data.
    /// </summary>
    public class DeleteCustomerHandler : IDeleteCustomerHandler
    {
        /// <summary>
        /// Repository instance for accessing and managing customer data within the domain.
        /// Provides methods for adding, retrieving, updating, and deleting customer entities.
        /// Used by application logic to delegate persistent operations on customer records.
        /// </summary>
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Handles the deletion of a customer by facilitating interaction with the customer repository.
        /// </summary>
        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Handles the deletion of a customer by delegating the operation to the customer repository.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to be deleted.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation of deleting a customer.</returns>
        public async Task Handle(int customerId, CancellationToken cancellationToken)
        {
            await _customerRepository.DeleteCustomerAsync(customerId, cancellationToken);
        }
    }
}