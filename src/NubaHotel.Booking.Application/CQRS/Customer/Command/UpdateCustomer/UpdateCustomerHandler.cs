using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.Customer.Command.UpdateCustomer
{
    /// <summary>
    /// Handles the update operation for a customer entity within the booking system.
    /// </summary>
    public class UpdateCustomerHandler : IUpdateCustomerHandler
    {
        /// <summary>
        /// Repository instance for accessing and managing customer data within the domain.
        /// Provides methods for adding, retrieving, updating, and deleting customer entities.
        /// Used by application logic to delegate persistent operations on customer records.
        /// </summary>
        private readonly ICustomerRepository _customerRepository;
        
        /// <summary>
        /// Mapper for converting between data models and domain entities related to customers.
        /// </summary>
        private readonly CustomerMapper _customerMapper;

        /// <summary>
        /// Handles the update operation for a customer entity within the booking system.
        /// </summary>
        /// <param name="customerRepository">The repository instance for accessing and managing customer data within the domain.</param>
        /// <param name="customerMapper">The mapper for converting between data models and domain entities related to customers.</param>
        /// <remarks>
        /// This class interacts with the <see cref="ICustomerRepository"/> to persist customer data
        /// and uses the <see cref="CustomerMapper"/> for mapping command data to a domain entity.
        /// </remarks>
        public UpdateCustomerHandler(ICustomerRepository customerRepository, CustomerMapper customerMapper)
        {
            _customerRepository = customerRepository;
            _customerMapper = customerMapper;
        }

        /// <summary>
        /// Processes the update operation for a customer entity within the booking system.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to be updated.</param>
        /// <param name="command">The command containing the updated customer details such as full name and document number.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests while performing the update operation.</param>
        /// <returns>A task representing the asynchronous operation for updating a customer's information in the system.</returns>
        public async Task Handle(int customerId, UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = _customerMapper.MapToCustomer(command);
            await _customerRepository.UpdateCustomerAsync(customerId, customer, cancellationToken);
        }
    }
}