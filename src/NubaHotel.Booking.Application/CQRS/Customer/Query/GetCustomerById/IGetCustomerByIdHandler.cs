using NubaHotel.BookingSystem.Application.DTOs;

namespace NubaHotel.BookingSystem.Application.CQRS.Customer.Query.GetCustomerById
{
    /// <summary>
    /// Represents a contract for handling the retrieval of a customer by their identifier.
    /// </summary>
    /// <remarks>
    /// The implementation of this interface is responsible for managing
    /// the process of finding and returning a customer's information
    /// based on the provided customer identifier. This is typically used
    /// within a CQRS (Command Query Responsibility Segregation) pattern
    /// in the context of customer-related queries.
    /// </remarks>
    public interface IGetCustomerByIdHandler
    {
        /// <summary>
        /// Processes the retrieval of a customer's details based on their unique identifier.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to retrieve.</param>
        /// <param name="cancellationToken">A token that can be used to signal cancellation of the operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the <see cref="CustomerDto"/> with the customer's details.
        /// </returns>
        Task<CustomerDto> Handle(int customerId, CancellationToken cancellationToken);
    }
}