using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.Customer.Query.GetCustomerById
{
    /// <summary>
    /// Handles the query to retrieve a customer's information by their identifier.
    /// </summary>
    /// <remarks>
    /// This class implements the <see cref="IGetCustomerByIdHandler"/> interface
    /// to manage the process of locating and returning customer details based
    /// on the provided customer ID. It facilitates retrieving data in the
    /// context of a CQRS pattern within the application.
    /// </remarks>
    public class GetCustomerByIdHandler : IGetCustomerByIdHandler
    {
        /// <summary>
        /// Used to interact with the customer repository layer for performing data access operations
        /// related to Customer entities. Provides methods to retrieve, add, update, and delete
        /// customer data in the domain.
        /// </summary>
        /// <remarks>
        /// This variable is an instance of the <see cref="ICustomerRepository"/> interface, responsible for
        /// handling persistence operations and data retrieval. It enables access to domain-level
        /// functionality for managing customers, such as fetching a customer by ID or getting
        /// all customers.
        /// </remarks>
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Provides functionality to map Customer domain entities to CustomerDto objects and vice versa.
        /// Used within the context of query handling to facilitate data transformations by converting
        /// entities into appropriate data transfer objects or other types.
        /// </summary>
        /// <remarks>
        /// This variable is an instance of the <see cref="CustomerMapper"/> class, responsible for
        /// carrying out mapping operations. It ensures seamless conversion of Customer entities
        /// into DTOs required by the application layer, helping maintain separation between
        /// domain entities and API contracts.
        /// </remarks>
        private readonly CustomerMapper _customerMapper;

        /// <summary>
        /// Handles the operation of retrieving a customer by their unique identifier.
        /// </summary>
        /// <param name="customerRepository">An instance of the <see cref="ICustomerRepository"/> interface used to interact with the customer repository.</param>
        /// <param name="customerMapper">An instance of the <see cref="CustomerMapper"/> class used to map customer entities to DTOs.</param>
        /// <remarks>
        /// This constructor initializes the <see cref="GetCustomerByIdHandler"/> instance with the required dependencies.
        /// </remarks>
        public GetCustomerByIdHandler(ICustomerRepository customerRepository, CustomerMapper customerMapper)
        {
            _customerRepository = customerRepository;
            _customerMapper = customerMapper;
        }

        /// <summary>
        /// Processes the operation of retrieving a customer's details by their unique identifier.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the operation to complete.</param>
        /// <returns>A <see cref="CustomerDto"/> representing the retrieved customer information.</returns>
        public async Task<CustomerDto> Handle(int customerId, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId, cancellationToken);
            var customerDto = _customerMapper.MapToDto(customer);
            return customerDto;
        }
    }
}