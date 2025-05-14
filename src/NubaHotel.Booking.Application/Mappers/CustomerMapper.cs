using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Domain.Entities;

namespace NubaHotel.BookingSystem.Application.Mappers
{
    /// <summary>
    /// Mapper class for converting between Customer and CustomerDto.
    /// </summary>
    public class CustomerMapper
    {
        /// <summary>
        /// Maps a Customer entity to a CustomerDto.
        /// </summary>
        /// <param name="customer">The Customer entity to map from.</param>
        /// <returns>A CustomerDto object containing the mapped data from the provided Customer entity.</returns>
        public CustomerDto MapToDto(Customer customer)
        {
            var customerDto = new CustomerDto
            {
                CustomerId = customer.CustomerId,
                FullName = customer.FullName,
                DocumentNumber = customer.DocumentNumber
            };
            
            return customerDto;
        }

        /// <summary>
        /// Maps dynamic customer data to a Customer entity.
        /// </summary>
        /// <param name="dynamicCustomer">A dynamic object containing customer properties to map from.</param>
        /// <returns>A Customer entity populated with data from the provided dynamic object.</returns>
        public Customer MapToCustomer(dynamic dynamicCustomer)
        {
            var customer = new Customer
            {
                FullName = dynamicCustomer.FullName,
                DocumentNumber = dynamicCustomer.DocumentNumber
            };
            
            return customer;
        }

        /// <summary>
        /// Maps a Customer entity to a CustomerDto.
        /// </summary>
        /// <param name="customers">The Customer entity to map from.</param>
        /// <returns>A CustomerDto object containing the mapped data from the provided Customer entity.</returns>
        public IEnumerable<CustomerDto> MapToDto(IEnumerable<Customer> customers)
        {
            var customersList = customers.Select(x => new CustomerDto
            {
                CustomerId = x.CustomerId,
                FullName = x.FullName,
                DocumentNumber = x.DocumentNumber
            });
            
            return customersList;
        }
    }
}