using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.Customer.Command.CreateCustomer
{
    /// <summary>
    /// Handles the creation of a new customer by processing the CreateCustomerCommand.
    /// </summary>
    /// <remarks>
    /// This class interacts with the ICustomerRepository to persist customer data
    /// and uses CustomerMapper for mapping command data to the domain entity.
    /// </remarks>
    public class CreateCustomerHandler : ICreateCustomerHandler
    {
        /// <summary>
        /// Instance of <see cref="ICustomerRepository"/> used to perform
        /// operations related to the persistence, retrieval, and management
        /// of customer entities within the domain.
        /// </summary>
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Instance of <see cref="CustomerMapper"/> used to facilitate
        /// transformation between data models and domain entities related to customers.
        /// </summary>
        private readonly CustomerMapper _customerMapper;

        /// <summary>
        /// Handles the creation of a new customer by processing the CreateCustomerCommand.
        /// </summary>
        /// <remarks>
        /// This class interacts with the <see cref="ICustomerRepository"/> to persist customer data
        /// and uses the <see cref="CustomerMapper"/> for mapping command data to a domain entity.
        /// </remarks>
        public CreateCustomerHandler(ICustomerRepository customerRepository, CustomerMapper customerMapper)
        {
            _customerRepository = customerRepository;
            _customerMapper = customerMapper;
        }

        /// <summary>
        /// Processes the CreateCustomerCommand to create a new customer entry in the system.
        /// </summary>
        /// <param name="command">The command containing data required to create a new customer.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        public async Task Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = _customerMapper.MapToCustomer(command);
            await _customerRepository.AddCustomerAsync(customer, cancellationToken);
        }
    }
}