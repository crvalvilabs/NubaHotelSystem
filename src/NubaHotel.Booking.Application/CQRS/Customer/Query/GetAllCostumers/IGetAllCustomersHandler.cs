using NubaHotel.BookingSystem.Application.DTOs;

namespace NubaHotel.BookingSystem.Application.CQRS.Customer.Query.GetAllCostumers
{
    /// <summary>
    /// Represents a query interface for retrieving all customers.
    /// </summary>
    /// <remarks>
    /// This interface defines the contract for handling the process of fetching
    /// all customer records from the system in the form of a collection of CustomerDto.
    /// Implementations of this interface are expected to provide appropriate logic to
    /// interact with the underlying data source.
    /// </remarks>
    public interface IGetAllCustomersHandler
    {
        /// <summary>
        /// Handles the execution of a query to retrieve all customers.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for operation cancellation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="CustomerDto"/> representing all customers.
        /// </returns>
        Task<IEnumerable<CustomerDto>> Handle(CancellationToken cancellationToken);
    }
}