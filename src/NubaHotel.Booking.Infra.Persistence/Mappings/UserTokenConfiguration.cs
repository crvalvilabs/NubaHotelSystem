using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NubaHotel.BookingSystem.Infra.Persistence.Entities;

namespace NubaHotel.BookingSystem.Infra.Persistence.Mappings;

/// <summary>
/// Configures the mapping of the UserTokenEntity to the database schema.
/// This configuration sets the table name, primary key, column names, and other constraints for the entity.
/// </summary>
public class UserTokenConfiguration
{
    /// <summary>
    /// Provides the configuration for the UserTokenEntity within the database context.
    /// Implements entity framework configurations such as table mapping,
    /// key definition, column properties, and other constraints for the entity.
    /// </summary>
    public UserTokenConfiguration(EntityTypeBuilder<UserTokenEntity> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("UserTokens", schema: "Seguridad");
        entityTypeBuilder.HasKey(x => x.UserTokenId);
        entityTypeBuilder.Property(x => x.UserTokenId)
            .HasColumnName("UserTokenId")
            .ValueGeneratedOnAdd();
        entityTypeBuilder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .IsRequired();
        entityTypeBuilder.Property(x => x.RefreshToken)
            .HasColumnName("RefreshToken")
            .IsRequired();
        entityTypeBuilder.Property(x => x.ExpiresAt)
            .HasColumnName("ExpiresAt")
            .IsRequired();
    }
}