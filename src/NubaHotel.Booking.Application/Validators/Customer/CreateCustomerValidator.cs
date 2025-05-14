using FluentValidation;
using NubaHotel.BookingSystem.Application.CQRS.Customer.Command.CreateCustomer;

namespace NubaHotel.BookingSystem.Application.Validators.Customer
{
    /// <summary>
    /// Validator for the <see cref="CreateCustomerCommand"/> class.
    /// </summary>
    /// <remarks>
    /// This validator ensures that the necessary properties for creating a customer are provided and valid.
    /// </remarks>
    /// <example>
    /// The validation rules include checks for required fields and maximum length constraints.
    /// </example>
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        /// <summary>
        /// Validator for the <see cref="CreateCustomerCommand"/> class.
        /// </summary>
        /// <remarks>
        /// Defines validation rules that ensure the validity of the input data required for creating a customer.
        /// Includes checks for ensuring properties like FullName and DocumentNumber are not empty,
        /// and conform to specific constraints such as maximum length restrictions.
        /// </remarks>
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Full name is required.");
            RuleFor(x => x.DocumentNumber)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Document number is required.");
        }
    }
}