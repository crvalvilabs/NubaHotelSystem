using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NubaHotel.BookingSystem.Infra.Persistence.Entities;

namespace NubaHotel.BookingSystem.Infra.Persistence.Mappings
{
    /// <summary>
    /// Configuration class for the UserEntity.
    /// </summary>
    public class UserConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserConfiguration"/> class.
        /// </summary>
        /// <param name="entityTypeBuilder">The entity type builder for UserEntity.</param>
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityTypeBuilder) 
        {
            entityTypeBuilder.ToTable("User", schema: "Hotel");
            entityTypeBuilder.HasKey(x => x.UserId);
            entityTypeBuilder.Property(x => x.UserId)
                .HasColumnName("UserId")
                .ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasMaxLength(20);
            entityTypeBuilder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .IsRequired()
                .HasMaxLength(20);
            entityTypeBuilder.Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100);
            entityTypeBuilder.Property(x => x.Password)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(100);
            entityTypeBuilder.Property(x => x.Salt)
                .HasColumnName("Salt")
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
