using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NubaHotel.BookingSystem.Infra.Persistence.Entities;

namespace NubaHotel.BookingSystem.Infra.Persistence.Mappings
{
    /// <summary>
    /// Configuration class for the CustomerEntity.
    /// </summary>
    public class CustomerConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerConfiguration"/> class.
        /// </summary>
        /// <param name="entityTypeBuilder">The entity type builder for CustomerEntity.</param>
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Customer", schema: "Hotel");
            entityTypeBuilder.HasKey(x => x.CustomerId);
            entityTypeBuilder.Property(x => x.CustomerId)
                .HasColumnName("CustomerId")
                .ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.FullName)
                .HasColumnName("FullName")
                .IsRequired()
                .HasMaxLength(100);
            entityTypeBuilder.Property(x => x.DocumentNumber)
                .HasColumnName("DocumentNumber")
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
