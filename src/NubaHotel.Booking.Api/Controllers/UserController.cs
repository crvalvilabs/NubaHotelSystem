using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NubaHotel.BookingSystem.Application.CQRS.User.Command.CreateUser;
using NubaHotel.BookingSystem.Application.CQRS.User.Command.DeleteUser;
using NubaHotel.BookingSystem.Application.CQRS.User.Command.UpdateUser;
using NubaHotel.BookingSystem.Application.CQRS.User.Query.GetAllUsers;
using NubaHotel.BookingSystem.Application.CQRS.User.Query.GetUserById;
using NubaHotel.BookingSystem.Application.Services;

namespace NubaHotel.BookingSystem.Api.Controllers
{
    /// <summary>
    /// Controller responsible for handling user-related operations.
    /// </summary>
    /// <remarks>
    /// Provides endpoints to manage and retrieve user information.
    /// </remarks>
    [Authorize]
    [ApiController]
    [Route("[controller]/user")]
    public class UserController : Controller
    {
        /// <summary>
        /// Retrieves all users from the system.
        /// </summary>
        /// <param name="handler">The handler responsible for fetching user data.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An <see cref="IActionResult"/> containing the result of the operation,
        /// including a list of users and operation status information.</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers([FromServices] IGetAllUsersHandler handler,
            CancellationToken cancellationToken)
        {
            var result = await handler.Handle(cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves the information of a specific user based on their unique identifier.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to retrieve.</param>
        /// <param name="handler">The handler responsible for processing the retrieval of user data.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An <see cref="IActionResult"/> containing the retrieved user information or an error status
        /// if the user is not found.</returns>
        [HttpGet("by-id")]
        public async Task<IActionResult> GetUserById(int userId,
            [FromServices] IGetUserByIdHandler handler, CancellationToken cancellationToken)
        {
            var result = await handler.Handle(userId, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new user in the system.
        /// </summary>
        /// <param name="handler">The handler responsible for processing the user creation logic.</param>
        /// <param name="command">The command containing the data required to create a new user.</param>
        /// <param name="validator">The validator responsible for validating the command parameters.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the outcome of the operation.</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromServices] ICreateUserHandler handler,
            [FromBody] CreateUserCommand command, IValidator<CreateUserCommand> validator,
            CancellationToken cancellationToken)
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
        /// Updates the details of an existing user in the system.
        /// </summary>
        /// <param name="handler">The handler responsible for processing the user update operation.</param>
        /// <param name="command">The command containing the updated user information, such as first name, last name, and email.</param>
        /// <param name="userId">The unique identifier of the user to be updated.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromServices] IUpdateUserHandler handler,
            [FromBody] UpdateUserCommand command, int userId, CancellationToken cancellationToken)
        {
            await handler.Handle(userId, command, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Deletes a user from the system by their unique identifier.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to be deleted.</param>
        /// <param name="handler">The handler responsible for processing the user deletion operation.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation,
        /// including status information.</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser(int userId, [FromServices] IDeleteUserHandler handler,
            CancellationToken cancellationToken)
        {
            await handler.Handle(userId, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Authenticates the user by validating their email and password.
        /// </summary>
        /// <param name="email">The email address of the user attempting to log in.</param>
        /// <param name="password">The password provided by the user during login.</param>
        /// <param name="authenticateService">The authentication service used to verify the user's credentials.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the authentication process.</returns>
        [AllowAnonymous]
        [HttpGet("login")]
        public async Task<IActionResult> LogInUser(string email, string password,
            [FromServices] IAuthenticateService authenticateService, CancellationToken cancellationToken)
        {
            var result = await authenticateService.AuthenticateAsync(email, password, cancellationToken);
            return Ok(result);
        }
    }
}