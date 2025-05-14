using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NubaHotel.BookingSystem.Application.External;
using NubaHotel.BookingSystem.Infra.External.TokenService;

namespace NubaHotel.BookingSystem.Infra.External
{
    /// <summary>
    /// Provides methods for configuring external dependencies to be added
    /// to the application's <see cref="IServiceCollection"/>.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configures and adds external dependencies to the provided <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which the external dependencies will be added.</param>
        /// <param name="configuration">The application configuration instance.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> with the external dependencies configured.</returns>
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGetAccessTokenService, GetAccessTokenService>();
            services.AddScoped<IGetRefreshTokenService, GetRefreshTokenService>();
            return services;
        }
    }
}