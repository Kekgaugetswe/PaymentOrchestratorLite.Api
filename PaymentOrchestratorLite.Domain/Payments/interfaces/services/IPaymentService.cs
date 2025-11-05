using PaymentOrchestratorLite.Domain.Payments.Dtos;
using PaymentOrchestratorLite.Domain.Payments.Entities;
using PaymentOrchestratorLite.Domain.SharedKernel;

namespace PaymentOrchestratorLite.Domain.Payments.interfaces.services;

public interface IPaymentService
{
    Task<Payment> CreatePaymentAsync(string customerId, decimal amount);
    Task<ApiResponse<PaginatedResponse<PaymentDto>>> GetPaymentsAsync(PagedRequest request);
    Task<bool> ConfirmPaymentAsync(Guid paymentId);

}