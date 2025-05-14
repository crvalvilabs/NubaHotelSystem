using NubaHotel.BookingSystem.Domain.Entities;
using NubaHotel.BookingSystem.Infra.Persistence.Entities;

namespace NubaHotel.BookingSystem.Infra.Persistence.Mappers
{
    /// <summary>
    /// Provides mapping functionality between domain-level <see cref="Customer"/> objects
    /// and persistence-level <see cref="CustomerEntity"/> objects.
    /// </summary>
    /// <remarks>
    /// This class is responsible for transforming data between two equivalent representations
    /// intended for different layers of the application:
    /// - The <see cref="Customer"/> class is used in the domain model.
    /// - The <see cref="CustomerEntity"/> class is used within the persistence layer.
    /// </remarks>
    public class CustomerMapper
    {
        /// <summary>
        /// Maps a domain-level <see cref="Customer"/> object to a persistence-level <see cref="CustomerEntity"/> object.
        /// </summary>
        /// <param name="customer">The domain-level <see cref="Customer"/> instance to be mapped.</param>
        /// <returns>A new instance of <see cref="CustomerEntity"/> containing mapped data from the provided <see cref="Customer"/> object.</returns>
        public CustomerEntity MapToCustomerEntity(Customer customer)
        {
            var customerEntity = new CustomerEntity
            {
                FullName = customer.FullName,
                DocumentNumber = customer.DocumentNumber,
            };

            return customerEntity;
        }

        /// <summary>
        /// Maps a persistence-level <see cref="CustomerEntity"/> object to a domain-level <see cref="Customer"/> object.
        /// </summary>
        /// <param name="customerEntity">The persistence-level <see cref="CustomerEntity"/> instance to be mapped.</param>
        /// <returns>A new instance of <see cref="Customer"/> containing mapped data from the provided <see cref="CustomerEntity"/> object.</returns>
        public Customer MapToCustomer(CustomerEntity customerEntity)
        {
            var customer = new Customer
            {
                CustomerId = customerEntity.CustomerId,
                FullName = customerEntity.FullName,
                DocumentNumber = customerEntity.DocumentNumber,
            };

            return customer;
        }
    }
}