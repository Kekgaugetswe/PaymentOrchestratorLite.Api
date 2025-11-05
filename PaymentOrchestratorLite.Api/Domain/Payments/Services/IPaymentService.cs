using PaymentOrchestratorLite.Api.Domain.Payments.Entities;

namespace PaymentOrchestratorLite.Api.Domain.Payments.Services;

public interface IPaymentService
{
    Task<Payment> CreatePaymentAsync(string customerId, decimal amount);
    Task<List<Payment>> GetPaymentsAsync();
    Task<bool> ConfirmPaymentAsync(Guid paymentId);

}