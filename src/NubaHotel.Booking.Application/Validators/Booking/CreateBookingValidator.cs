using FluentValidation;
using NubaHotel.BookingSystem.Application.CQRS.Booking.Command.CreateBooking;

namespace NubaHotel.BookingSystem.Application.Validators.Booking;

/// <summary>
/// Validator for the <see cref="CreateBookingCommand"/> class.
/// </summary>
/// <remarks>
/// This class is responsible for validating the properties of <see cref="CreateBookingCommand"/> to ensure that all
/// required fields are provided and meet the defined validation criteria.
/// </remarks>
/// <example>
/// Ensures validation such as:
/// - Booking date must not be empty.
/// - Code must not be empty.
/// - Type must not be empty.
/// - Check-in date must not be empty.
/// - Check-out date must not be empty.
/// - Customer ID must not be empty.
/// - User ID must not be empty.
/// </example>
public class CreateBookingValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingValidator()
    {
        RuleFor(x => x.BookingDate)
            .NotEmpty()
            .WithMessage("Booking date is required.");
        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Code is required.");
        RuleFor(x => x.Type)
            .NotEmpty()
            .WithMessage("Type is required.");
        RuleFor(x => x.CheckIn)
            .NotEmpty()
            .WithMessage("Check in is required.");
        RuleFor(x => x.CheckOut)
            .NotEmpty()
            .WithMessage("Check out is required.");
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .WithMessage("CustomerId is required.");
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");
    }
}