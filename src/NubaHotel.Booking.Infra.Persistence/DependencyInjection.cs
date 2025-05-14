using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NubaHotel.BookingSystem.Application.Services;
using NubaHotel.BookingSystem.Infra.Persistence.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;
using NubaHotel.BookingSystem.Domain.Security;
using NubaHotel.BookingSystem.Infra.Persistence.Authentication;
using NubaHotel.BookingSystem.Infra.Persistence.Database;
using NubaHotel.BookingSystem.Infra.Persistence.Repositories;
using NubaHotel.BookingSystem.Infra.Persistence.Security;

namespace NubaHotel.BookingSystem.Infra.Persistence
{
    /// <summary>
    /// Provides methods for registering persistence layer dependencies in the application's dependency injection container.
    /// </summary> 
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the persistence layer dependencies, including database context and repositories, into the service collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> instance to which the dependencies will be added.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> instance providing application configuration settings.</param>
        /// <returns>Returns the updated <see cref="IServiceCollection"/> with the registered persistence layer dependencies.</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NubaHotelContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IValidateTokenService, ValidateTokenService>();
            
            services.AddScoped<UserMapper>();
            services.AddScoped<CustomerMapper>();
            services.AddScoped<BookingMapper>();
            services.AddScoped<TokenMapper>();
            
            return services;
        }
    }
}