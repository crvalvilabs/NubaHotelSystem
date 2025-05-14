using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NubaHotel.BookingSystem.Infra.Persistence.Entities;

namespace NubaHotel.BookingSystem.Infra.Persistence.Mappings
{
    /// <summary>
    /// Configuration class for the BookingEntity.
    /// </summary>
    public class BookingConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingConfiguration"/> class.
        /// </summary>
        /// <param name="entityTypeBuilder">The entity type builder for the BookingEntity.</param>
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> entityTypeBuilder) 
        {
            entityTypeBuilder.ToTable("Booking", schema: "Hotel");
            entityTypeBuilder.HasKey(x => x.BookingId);
            entityTypeBuilder.Property(x => x.BookingId)
                .HasColumnName("BookingId")
                .ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.BookingDate)
                .HasColumnName("BookingDate")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
            entityTypeBuilder.Property(x => x.Code)
                .HasColumnName("Code")
                .IsRequired();
            entityTypeBuilder.Property(x => x.Type)
                .HasColumnName("Type")
                .IsRequired();
            entityTypeBuilder.Property(x => x.CustomerId)
                .HasColumnName("CustomerId")
                .IsRequired();
            entityTypeBuilder.Property(x => x.UserId)
                .HasColumnName("UserId")
                .IsRequired();
        }
    }
}
