using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NubaHotel.BookingSystem.Application.CQRS.Booking.Command.CreateBooking;
using NubaHotel.BookingSystem.Application.CQRS.Booking.Command.DeleteBooking;
using NubaHotel.BookingSystem.Application.CQRS.Booking.Command.UpdateBooking;
using NubaHotel.BookingSystem.Application.CQRS.Booking.Query.GetAllBookings;
using NubaHotel.BookingSystem.Application.CQRS.Booking.Query.GetBookingById;

namespace NubaHotel.BookingSystem.Api.Controllers;

/// <summary>
/// Provides endpoints for managing bookings in the NubaHotel system.
/// </summary>
/// <remarks>
/// This controller handles HTTP requests related to booking functionality, such as retrieving booking data.
/// It uses the CQRS pattern to delegate query handling logic to the appropriate handlers.
/// </remarks>
[Authorize]
[ApiController]
[Route("[controller]/Booking")]
public class BookingController : Controller
{
    /// <summary>
    /// Retrieves all bookings from the system.
    /// </summary>
    /// <param name="handler">The handler responsible for processing the retrieval of all bookings.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>An IActionResult containing a collection of bookings.</returns>
    [HttpGet("all")]
    public async Task<IActionResult> GetAllBookings([FromServices] IGetAllBookingsHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a booking by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the booking to be retrieved.</param>
    /// <param name="handler">The handler responsible for processing the retrieval of the specified booking.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>An IActionResult containing the details of the specified booking.</returns>
    [HttpGet("by-id")]
    public async Task<IActionResult> GetBookingById(int id, [FromServices] IGetBookingByIdHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(id, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Creates a new booking in the system.
    /// </summary>
    /// <param name="handler">The handler responsible for processing the booking creation.</param>
    /// <param name="command">The command containing the details of the booking to be created.</param>
    /// <param name="validator">The validator to ensure the command is valid.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>An IActionResult indicating the result of the booking creation operation.</returns>
    [HttpPost("create")]
    public async Task<IActionResult> CreateBooking([FromServices] ICreateBookingHandler handler,
        [FromBody] CreateBookingCommand command, IValidator<CreateBookingCommand> validator, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(command, cancellationToken);
        if (!validate.IsValid)
        {
            return BadRequest(new
            {
                Success = false,
                StatusCode = 400,
                Message = "Invalid parameters.",
                Errors = validate.Errors.Select(x => x.ErrorMessage).ToList()
            });
        }
        await handler.Handle(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Updates a specific booking in the system.
    /// </summary>
    /// <param name="id">The unique identifier of the booking to be updated.</param>
    /// <param name="handler">The handler responsible for processing the booking update command.</param>
    /// <param name="command">The command containing the updated booking details.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>An IActionResult indicating the result of the update operation.</returns>
    [HttpPut("update")]
    public async Task<IActionResult> UpdateBooking(int id, [FromServices] IUpdateBookingHandler handler,
        [FromBody] UpdateBookingCommand command, CancellationToken cancellationToken)
    {
        await handler.Handle(id, command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Deletes a booking from the system based on the provided booking ID.
    /// </summary>
    /// <param name="id">The unique identifier of the booking to be deleted.</param>
    /// <param name="handler">The handler responsible for processing the deletion of the booking.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>An IActionResult indicating the outcome of the deletion operation.</returns>
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteBooking(int id, [FromServices] IDeleteBookingHandler handler,
        CancellationToken cancellationToken)
    {
        await handler.Handle(id, cancellationToken);
        return Ok();
    }
}