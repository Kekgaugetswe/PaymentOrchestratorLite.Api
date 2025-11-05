using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PaymentOrchestratorLite.Api.Domain.AccountManagement.Models;
using PaymentOrchestratorLite.Api.Domain.Payments.Dtos;
using PaymentOrchestratorLite.Api.Domain.Payments.Services;

namespace PaymentOrchestratorLite.Api.Domain.Payments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPaymentService _paymentService;

        public PaymentsController(
            UserManager<ApplicationUser> userManager,
            IPaymentService paymentService)
        {
            _userManager = userManager;
            _paymentService = paymentService;
        }

        // POST /payments
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentRequestDto request)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var payment = await _paymentService.CreatePaymentAsync(user.CustomerId, request.Amount);

            return Ok(payment);
        }

        // GET /payments
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var payments = await _paymentService.GetPaymentsAsync();
            return Ok(payments);
        }

        [HttpPost("simulate-confirmation/{id:guid}")]
        public async Task<IActionResult> Confirm(Guid id)
        {
            var success = await _paymentService.ConfirmPaymentAsync(id);

            return success ? Ok(new { message = "Payment confirmed" }) 
                : NotFound(new { message = "Payment not found" });
        }
    }
}
