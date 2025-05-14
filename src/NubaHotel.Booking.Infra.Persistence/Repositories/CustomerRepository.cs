using Microsoft.EntityFrameworkCore;
using NubaHotel.BookingSystem.Domain.Entities;
using NubaHotel.BookingSystem.Domain.Exceptions;
using NubaHotel.BookingSystem.Domain.Repositories;
using NubaHotel.BookingSystem.Infra.Persistence.Database;
using NubaHotel.BookingSystem.Infra.Persistence.Mappers;

namespace NubaHotel.BookingSystem.Infra.Persistence.Repositories
{
    /// <summary>
    /// The CustomerRepository class provides an implementation of the ICustomerRepository interface.
    /// It manages persistence operations for the Customer entity, such as adding, retrieving, updating,
    /// and deleting customers in the database.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Represents the database context used to interact with the underlying database for
        /// persistence operations related to the Nuba Hotel application.
        /// </summary>
        private readonly NubaHotelContext _nubaHotelContext;

        /// <summary>
        /// Represents the mapper used to convert between Customer and CustomerEntity.
        /// </summary>
        private readonly CustomerMapper _customerMapper;

        /// <summary>
        /// Provides methods to perform CRUD operations on Customer entities in the persistence layer.
        /// </summary>
        public CustomerRepository(NubaHotelContext nubaHotelContext, CustomerMapper customerMapper)
        {
            _nubaHotelContext = nubaHotelContext;
            _customerMapper = customerMapper;
        }

        /// <summary>
        /// Adds the specified customer to the data store asynchronously.
        /// </summary>
        /// <param name="customer">The customer entity to be added.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken)
        {
            var customerEntity = _customerMapper.MapToCustomerEntity(customer);
            _nubaHotelContext.Customers!.Add(customerEntity);
            await _nubaHotelContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a customer entity by its unique identifier asynchronously from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation, if required.</param>
        /// <returns>The customer entity associated with the specified identifier.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when a customer with the specified identifier is not found.</exception>
        public async Task<Customer> GetCustomerByIdAsync(int id, CancellationToken cancellationToken)
        {
            var customerEntity = await _nubaHotelContext.Customers!
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.CustomerId == id, cancellationToken)
                                 ?? throw new EntityNotFoundException("Customer not found");
            var customerSearched = _customerMapper.MapToCustomer(customerEntity);
            return customerSearched;
        }

        /// <summary>
        /// Updates a customer's information in the database based on the given customer ID.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to be updated.</param>
        /// <param name="customer">An instance of the <see cref="Customer"/> class containing the updated information.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when the customer with the specified ID does not exist.</exception>
        public async Task UpdateCustomerAsync(int customerId, Customer customer, CancellationToken cancellationToken)
        {
            var customerEntity = await _nubaHotelContext.Customers!
                                     .FirstOrDefaultAsync(x => x.CustomerId == customerId, cancellationToken)
                                 ?? throw new EntityNotFoundException("Customer not found");

            if (!string.IsNullOrEmpty(customer.FullName))
            {
                customerEntity.FullName = customer.FullName;
            }

            if (!string.IsNullOrEmpty(customer.DocumentNumber))
            {
                customerEntity.DocumentNumber = customer.DocumentNumber;
            }

            await _nubaHotelContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Deletes a customer with the specified ID from the database asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to be deleted.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when no customer is found with the specified ID.</exception>
        public async Task DeleteCustomerAsync(int id, CancellationToken cancellationToken)
        {
            var customerToDelete = await _nubaHotelContext.Customers!
                                       .FirstOrDefaultAsync(x => x.CustomerId == id, cancellationToken)
                                   ?? throw new EntityNotFoundException("Customer not found");
            _nubaHotelContext.Customers!.Remove(customerToDelete);
            await _nubaHotelContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves a collection of all customers from the database.
        /// </summary>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a collection of customers.</returns>
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            var customers = await _nubaHotelContext.Customers!
                .Select(x => new Customer
                {
                    CustomerId = x.CustomerId,
                    FullName = x.FullName,
                    DocumentNumber = x.DocumentNumber
                }).ToListAsync(cancellationToken);

            return customers;
        }
    }
}