using FluentValidation;
using NubaHotel.BookingSystem.Application.CQRS.User.Command.CreateUser;

namespace NubaHotel.BookingSystem.Application.Validators.User
{
    /// <summary>
    /// Provides validation rules for the <see cref="CreateUserCommand"/> object to ensure data integrity during user creation.
    /// </summary>
    /// <remarks>
    /// Enforces the following validation rules:
    /// - First name must not be empty.
    /// - Last name must not be empty.
    /// - Email must not be empty.
    /// - Password must not be empty.
    /// - Password must have a minimum length of 8 characters.
    /// - Password must have a maximum length of 16 characters.
    /// </remarks>
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");
            RuleFor(x => x.Password)
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.");
            RuleFor(x => x.Password)
                .MaximumLength(16)
                .WithMessage("Password must be at most 16 characters long.");
        }
    }
}