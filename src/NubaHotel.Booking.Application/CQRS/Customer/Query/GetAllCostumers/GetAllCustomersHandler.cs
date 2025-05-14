using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.Customer.Query.GetAllCostumers
{
    /// <summary>
    /// Represents a query responsible for retrieving all customers from the system.
    /// </summary>
    /// <remarks>
    /// The <c>GetAllCustomersQuery</c> class leverages the <see cref="ICustomerRepository"/>
    /// for accessing customer data from the data source and the <seealso cref="CustomerMapper"/>
    /// to transform the domain entities into DTOs.
    /// </remarks>
    public class GetAllCustomersHandler : IGetAllCustomersHandler
    {
        /// <summary>
        /// Provides access to customer data from the underlying data source.
        /// </summary>
        /// <remarks>
        /// This private field represents an instance of <see cref="ICustomerRepository"/> used to interact with
        /// the repository layer for performing various customer-related operations, such as adding, retrieving,
        /// updating, and deleting customer entities.
        /// </remarks>
        private readonly ICustomerRepository _customerRepository;
        
        /// <summary>
        /// Provides a mechanism for mapping customer entities to DTOs.
        /// </summary>
        private readonly CustomerMapper _customerMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllCustomersHandler"/> class.
        /// </summary>
        /// <param name="customerRepository">An instance of <see cref="ICustomerRepository"/> to handle data operations for customers.</param>
        /// <param name="customerMapper">An instance of <see cref="CustomerMapper"/> to map customer domain entities to require DTOs.</param>
        public GetAllCustomersHandler(ICustomerRepository customerRepository, CustomerMapper customerMapper)
        {
            _customerRepository = customerRepository;
            _customerMapper = customerMapper;
        }

        /// <summary>
        /// Handles the execution of the query to retrieve all customers.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance that can be used to observe cancellation requests.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a collection of <see cref="CustomerDto"/> representing the retrieved customers.
        /// </returns>
        public async Task<IEnumerable<CustomerDto>> Handle(CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllCustomersAsync(cancellationToken);
            var customersDto = _customerMapper.MapToDto(customers);
            return customersDto;
        }
    }
}