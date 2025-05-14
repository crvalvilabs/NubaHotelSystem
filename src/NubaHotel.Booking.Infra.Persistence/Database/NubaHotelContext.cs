using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using NubaHotel.BookingSystem.Infra.Persistence.Entities;
using NubaHotel.BookingSystem.Infra.Persistence.Mappings;

namespace NubaHotel.BookingSystem.Infra.Persistence.Database
{
    /// <summary>
    /// Represents the Nuba Hotel context.
    /// </summary>
    public class NubaHotelContext : DbContext
    {
        /// <summary>
        /// Represents the database context for Nuba Hotel.
        /// </summary>
        /// <remarks>
        /// This context manages the database operations for the booking system of Nuba Hotel.
        /// It includes DbSet properties for entities such as Users, Bookings, and Customers,
        /// and configures the model using the OnModelCreating method.
        /// </remarks>
        public NubaHotelContext(DbContextOptions<NubaHotelContext> options) : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the DbSet of UserEntity.
        /// </summary>
        public DbSet<UserEntity> ? Users { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of BookingEntity.
        /// </summary>
        public DbSet<BookingEntity> ? Bookings { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of CustomerEntity.
        /// </summary>
        public DbSet<CustomerEntity> ? Customers { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of UserTokenEntity.
        /// </summary>
        public DbSet<UserTokenEntity>? UserTokens { get; set; }

        /// <summary>
        /// Configures the model for the Nuba Hotel context.
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure the model.</param>
        /// <remarks>
        /// This method is called when the model for the context is being created.
        /// It allows for configuring the model and its properties.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigurationEntity(modelBuilder);
        }

        /// <summary>
        /// Configures the entity properties for the Nuba Hotel context.
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure the entity properties.</param>
        /// <remarks>
        /// This method is used to configure the properties of the entities in the context.
        /// It allows for setting up relationships, constraints, and other configurations.
        /// </remarks>
        private void ConfigurationEntity(ModelBuilder modelBuilder)
        {
            _ = new UserConfiguration(modelBuilder.Entity<UserEntity>());
            _ = new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
            _ = new BookingConfiguration(modelBuilder.Entity<BookingEntity>());
            _ = new UserTokenConfiguration(modelBuilder.Entity<UserTokenEntity>());
        }
    }
}
