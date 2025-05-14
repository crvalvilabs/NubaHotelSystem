using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NubaHotel.BookingSystem.Application.CQRS.Customer.Command.CreateCustomer;
using NubaHotel.BookingSystem.Application.CQRS.Customer.Command.DeleteCustomer;
using NubaHotel.BookingSystem.Application.CQRS.Customer.Command.UpdateCustomer;
using NubaHotel.BookingSystem.Application.CQRS.Customer.Query.GetAllCostumers;
using NubaHotel.BookingSystem.Application.CQRS.Customer.Query.GetCustomerById;

namespace NubaHotel.BookingSystem.Api.Controllers
{
    /// <summary>
    /// Controller responsible for handling customer-related operations such as creating a new customer.
    /// </summary>
    /// <remarks>
    /// Provides endpoints to manage and retrieve customer information.
    /// </remarks>
    [Authorize]
    [ApiController]
    [Route("[controller]/customer")]
    public class CustomerController : Controller
    {
        /// <summary>
        /// Retrieves a list of all customers by invoking the corresponding handler.
        /// </summary>
        /// <param name="handler">The handler responsible for fetching all customers from the data source.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An IActionResult containing the result of the operation. Returns OK with the list of customers on success.
        /// </returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllCustomers([FromServices] IGetAllCustomersHandler handler, 
            CancellationToken cancellationToken)
        {
            var result = await handler.Handle(cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves the details of a specific customer using their unique identifier.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to be retrieved.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <param name="handler">The handler responsible for processing the query to fetch the customer information.</param>
        /// <returns>An IActionResult containing the result of the operation. Returns OK with the customer's details if found.</returns>
        [HttpGet("by-id")]
        public async Task<IActionResult> GetCustomerById(int customerId, [FromServices] IGetCustomerByIdHandler handler, 
            CancellationToken cancellationToken)
        {
            var result = await handler.Handle(customerId, cancellationToken);
            return Ok(result);
        }
        
        /// <summary>
        /// Handles the creation of a new customer by validating the input data and invoking the corresponding handler.
        /// </summary>
        /// <param name="handler">The service responsible for processing and handling the creation of a customer.</param>
        /// <param name="command">The data required to create the customer, including name and document number.</param>
        /// <param name="validator">The service used to validate the provided customer creation data.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An IActionResult indicating the result of the operation. Returns BadRequest if validation fails or OK on success.</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromServices] ICreateCustomerHandler handler,
            [FromBody] CreateCustomerCommand command, IValidator<CreateCustomerCommand> validator, CancellationToken cancellationToken)
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
            
            await handler.Handle(command, CancellationToken.None);
            return Ok();
        }
        
        /// <summary>
        /// Updates an existing customer's information by processing the provided data.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to be updated.</param>
        /// <param name="command">The data containing the updated customer information, including name and document number.</param>
        /// <param name="handler">The service responsible for handling the update process of the customer.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An IActionResult indicating the outcome of the update operation. Returns OK on success.</returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] UpdateCustomerCommand command,
            [FromServices] IUpdateCustomerHandler handler, CancellationToken cancellationToken)
        {
            await handler.Handle(customerId, command, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Deletes an existing customer based on their unique identifier.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to delete.</param>
        /// <param name="handler">The service responsible for processing and handling the deletion of the customer.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An IActionResult indicating the result of the operation. Returns BadRequest if the operation fails or OK on success.</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCustomer(int customerId, [FromServices] IDeleteCustomerHandler handler, 
            CancellationToken cancellationToken)
        {
            await handler.Handle(customerId, cancellationToken);
            return Ok();
        }

        
        
    }
}