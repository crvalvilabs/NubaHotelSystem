using NubaHotel.BookingSystem.Domain.Entities;

namespace NubaHotel.BookingSystem.Domain.Repositories
{
    /// <summary>
    /// Defines a contract for managing Customer entities within the domain.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Asynchronously adds a new customer to the repository.
        /// </summary>
        /// <param name="customer">The customer entity to be added.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>       
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously retrieves a customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to retrieve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>      
        /// <returns>A task that represents the asynchronous operation. The task result contains the customer entity if found, otherwise null.</returns>
        Task<Customer> GetCustomerByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously updates an existing customer in the repository.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to be updated.</param>      
        /// <param name="customer">The customer entity containing updated information.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>      
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateCustomerAsync(int customerId, Customer customer, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously deletes a customer from the repository.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to be deleted.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>     
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteCustomerAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously retrieves all customers from the repository.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of customer entities.</returns>
        Task<IEnumerable<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken);
    }
}