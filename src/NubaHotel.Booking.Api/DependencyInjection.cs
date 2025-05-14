using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NubaHotel.BookingSystem.Api.Logging;

namespace NubaHotel.BookingSystem.Api
{
    /// <summary>
    /// Dependency Injection configuration for the API project.
    /// Contains configuration for Swagger.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configures dependencies for the API layer, including Swagger and logging.
        /// </summary>
        /// <param name="services">The service collection to which dependencies will be added.</param>
        /// <param name="configuration">The application configuration instance.</param>
        /// <returns>The updated service collection with API dependencies configured.</returns>
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NubaHotel.Booking.Api",
                    Version = "v1",
                    Description = "API for the NubaHotel.Booking.Application project.",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
                
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                var secretKey = configuration.GetSection("TokenSecrets:SecretKey").Value!;
                var secretKeyBytes = Convert.FromBase64String(secretKey);
                
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(secretKeyBytes),
                    ValidIssuer = configuration.GetSection("TokenSecrets:Issuer").Value!,
                    ValidAudience = configuration.GetSection("TokenSecrets:Audience").Value!
                };
            });
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            
            services.AddScoped<LoggingService>();
            
            return services;
        }
    }
}