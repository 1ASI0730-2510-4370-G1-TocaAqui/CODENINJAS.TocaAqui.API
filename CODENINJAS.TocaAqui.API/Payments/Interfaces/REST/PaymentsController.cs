using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CODENINJAS.TocaAqui.API.Payments.Domain.Model.Queries;
using CODENINJAS.TocaAqui.API.Payments.Domain.Services;
using CODENINJAS.TocaAqui.API.Payments.Interfaces.REST.Resources;
using CODENINJAS.TocaAqui.API.Payments.Interfaces.REST.Transform;

namespace CODENINJAS.TocaAqui.API.Payments.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Payments")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentCommandService _paymentCommandService;
    private readonly IPaymentQueryService _paymentQueryService;

    public PaymentsController(
        IPaymentCommandService paymentCommandService,
        IPaymentQueryService paymentQueryService)
    {
        _paymentCommandService = paymentCommandService;
        _paymentQueryService = paymentQueryService;
    }

    /// <summary>
    /// Create a new payment
    /// </summary>
    /// <param name="resource">Payment creation data</param>
    /// <returns>Created payment</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new payment",
        Description = "Creates a new payment for an event",
        OperationId = "CreatePayment")]
    [SwaggerResponse(201, "The payment was created", typeof(PaymentResource))]
    [SwaggerResponse(400, "The payment was not created")]
    public async Task<ActionResult<PaymentResource>> CreatePayment([FromBody] CreatePaymentResource resource)
    {
        try
        {
            var command = CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(resource);
            var payment = await _paymentCommandService.Handle(command);
            
            if (payment is null) 
                return BadRequest("Could not create payment");
            
            var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, paymentResource);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error creating payment: {ex.Message}");
        }
    }

    /// <summary>
    /// Get payment by ID
    /// </summary>
    /// <param name="id">Payment ID</param>
    /// <returns>Payment details</returns>
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a payment by ID",
        Description = "Gets a payment by its unique identifier",
        OperationId = "GetPaymentById")]
    [SwaggerResponse(200, "The payment was found", typeof(PaymentResource))]
    [SwaggerResponse(404, "The payment was not found")]
    public async Task<ActionResult<PaymentResource>> GetPaymentById(int id)
    {
        var query = new GetPaymentByIdQuery(id);
        var payment = await _paymentQueryService.Handle(query);
        
        if (payment is null) 
            return NotFound();
        
        var resource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(resource);
    }

    /// <summary>
    /// Get all payments
    /// </summary>
    /// <returns>List of all payments</returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all payments",
        Description = "Gets all payments in the system",
        OperationId = "GetAllPayments")]
    [SwaggerResponse(200, "The payments were found", typeof(IEnumerable<PaymentResource>))]
    public async Task<ActionResult<IEnumerable<PaymentResource>>> GetAllPayments()
    {
        var query = new GetAllPaymentsQuery();
        var payments = await _paymentQueryService.Handle(query);
        var resources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    /// <summary>
    /// Get payments by user ID
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="userRole">User role (musician or promoter)</param>
    /// <returns>List of payments for the user</returns>
    [HttpGet("user/{userId:int}")]
    [SwaggerOperation(
        Summary = "Gets payments by user ID",
        Description = "Gets all payments for a specific user (musician or promoter)",
        OperationId = "GetPaymentsByUserId")]
    [SwaggerResponse(200, "The payments were found", typeof(IEnumerable<PaymentResource>))]
    public async Task<ActionResult<IEnumerable<PaymentResource>>> GetPaymentsByUserId(int userId, [FromQuery] string userRole = "musician")
    {
        var query = new GetPaymentsByUserIdQuery(userId, userRole);
        var payments = await _paymentQueryService.Handle(query);
        var resources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    /// <summary>
    /// Update payment status
    /// </summary>
    /// <param name="id">Payment ID</param>
    /// <param name="resource">Status update data</param>
    /// <returns>Updated payment</returns>
    [HttpPatch("{id:int}/status")]
    [SwaggerOperation(
        Summary = "Updates payment status",
        Description = "Updates the status of a payment",
        OperationId = "UpdatePaymentStatus")]
    [SwaggerResponse(200, "The status was updated", typeof(PaymentResource))]
    [SwaggerResponse(404, "The payment was not found")]
    public async Task<ActionResult<PaymentResource>> UpdatePaymentStatus(
        int id, 
        [FromBody] UpdatePaymentStatusResource resource)
    {
        try
        {
            var command = UpdatePaymentStatusCommandFromResourceAssembler.ToCommandFromResource(id, resource);
            var updatedPayment = await _paymentCommandService.Handle(command);
            
            if (updatedPayment is null) 
                return NotFound();
            
            var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(updatedPayment);
            return Ok(paymentResource);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error updating payment status: {ex.Message}");
        }
    }
} 