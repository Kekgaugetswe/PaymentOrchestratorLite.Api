using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PaymentOrchestratorLite.Api.Domain.AccountManagement.Models;
using PaymentOrchestratorLite.Domain.Payments.Dtos;
using PaymentOrchestratorLite.Domain.Payments.interfaces.services;
using PaymentOrchestratorLite.Domain.SharedKernel;

namespace PaymentOrchestratorLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(
        UserManager<ApplicationUser> userManager,
        IPaymentService paymentService)
        : ControllerBase
    {
        // POST /payments
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreatePaymentRequestDto request)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var payment = await paymentService.CreatePaymentAsync(user.CustomerId, request.Amount);

            return Ok(payment);
        }

        // GET /payments
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagedRequest request)
        {
            return Ok(await paymentService.GetPaymentsAsync(request));
        }

        [HttpPost("simulate-confirmation/{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Confirm(Guid id)
        {
            var success = await paymentService.ConfirmPaymentAsync(id);

            return success
                ? Ok(new { message = "Payment confirmed" })
                : NotFound(new { message = "Payment not found" });
        }
    }
}