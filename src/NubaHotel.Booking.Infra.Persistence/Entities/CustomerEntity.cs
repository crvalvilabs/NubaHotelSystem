namespace NubaHotel.BookingSystem.Infra.Persistence.Entities
{
    /// <summary>
    /// Represents a customer entity.
    /// </summary>
    /// <remarks>
    /// This class is part of the NubaHotel Booking Domain.
    /// It contains properties that define a customer.
    /// </remarks>
    public class CustomerEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the full name of the customer.
        /// </summary>
        public string ? FullName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
        public string ? DocumentNumber { get; set; }
    }
}
