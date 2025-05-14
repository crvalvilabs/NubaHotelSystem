using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NubaHotel.BookingSystem.Application.CQRS.Booking.Command.CreateBooking;
using NubaHotel.BookingSystem.Application.CQRS.Booking.Command.DeleteBooking;
using NubaHotel.BookingSystem.Application.CQRS.Booking.Command.UpdateBooking;
using NubaHotel.BookingSystem.Application.CQRS.Booking.Query.GetAllBookings;
using NubaHotel.BookingSystem.Application.CQRS.Booking.Query.GetBookingById;
using NubaHotel.BookingSystem.Application.CQRS.Customer.Command.CreateCustomer;
using NubaHotel.BookingSystem.Application.CQRS.Customer.Command.DeleteCustomer;
using NubaHotel.BookingSystem.Application.CQRS.Customer.Command.UpdateCustomer;
using NubaHotel.BookingSystem.Application.CQRS.Customer.Query.GetAllCostumers;
using NubaHotel.BookingSystem.Application.CQRS.Customer.Query.GetCustomerById;
using NubaHotel.BookingSystem.Application.CQRS.User.Command.CreateUser;
using NubaHotel.BookingSystem.Application.CQRS.User.Command.DeleteUser;
using NubaHotel.BookingSystem.Application.CQRS.User.Command.UpdateUser;
using NubaHotel.BookingSystem.Application.CQRS.User.Query.GetAllUsers;
using NubaHotel.BookingSystem.Application.CQRS.User.Query.GetUserById;
using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Application.Validators.Booking;
using NubaHotel.BookingSystem.Application.Validators.Customer;
using NubaHotel.BookingSystem.Application.Validators.User;

namespace NubaHotel.BookingSystem.Application
{
    /// <summary>
    /// Provides functionality to register user-related command and query handlers
    /// to the application's dependency injection container.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers application services necessary for handling various user-related commands and queries.
        /// </summary>
        /// <param name="services">The IServiceCollection instance to which the services are added.</param>
        /// <returns>The modified IServiceCollection instance.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Queries
            services.AddScoped<IGetAllUsersHandler, GetAllUsersHandler>();
            services.AddScoped<IGetUserByIdHandler, GetUserByIdHandler>();
            services.AddScoped<IGetAllCustomersHandler, GetAllCustomersHandler>();
            services.AddScoped<IGetCustomerByIdHandler, GetCustomerByIdHandler>();
            services.AddScoped<IGetAllBookingsHandler, GetAllBookingsHandler>();
            services.AddScoped<IGetBookingByIdHandler, GetBookingByIdHandler>();
            
            // Commands
            services.AddScoped<ICreateUserHandler, CreateUserHandler>();
            services.AddScoped<IUpdateUserHandler, UpdateUserHandler>();
            services.AddScoped<IDeleteUserHandler, DeleteUserHandler>();
            services.AddScoped<ICreateCustomerHandler, CreateCustomerHandler>();
            services.AddScoped<IDeleteCustomerHandler, DeleteCustomerHandler>();
            services.AddScoped<IUpdateCustomerHandler, UpdateCustomerHandler>();
            services.AddScoped<ICreateBookingHandler, CreateBookingHandler>();
            services.AddScoped<IDeleteBookingHandler, DeleteBookingHandler>();
            services.AddScoped<IUpdateBookingHandler, UpdateBookingHandler>();
            
            // Validators 
            services.AddScoped<IValidator<CreateUserCommand>, CreateUserValidator>();
            services.AddScoped<IValidator<CreateCustomerCommand>, CreateCustomerValidator>();
            services.AddScoped<IValidator<CreateBookingCommand>, CreateBookingValidator>();
            
            // Mappers
            services.AddScoped<UserMapper>();
            services.AddScoped<CustomerMapper>();
            services.AddScoped<BookingMapper>();
            
            return services;
        }
    }
}