using PaymentOrchestratorLite.Api.Domain.Payments.Entities;
using PaymentOrchestratorLite.Api.Domain.Payments.enums;
using PaymentOrchestratorLite.Api.Domain.Payments.Repositories;

namespace PaymentOrchestratorLite.Api.Domain.Payments.Services;

public class PaymentService(IPaymentRepository repository) : IPaymentService
{
    public async Task<Payment> CreatePaymentAsync(string customerId, decimal amount)
    {
        var payment = new Payment
        {
            CustomerId = customerId,
            Amount = amount,
            Status = PaymentStatus.Pending
        };

        await repository.AddAsync(payment);
        return payment;
    }

    public async Task<List<Payment>> GetPaymentsAsync()
    {
        return await repository.GetAllAsync();
    }
    
    public async Task<bool> ConfirmPaymentAsync(Guid paymentId)
    {
        var payment = await repository.GetByIdAsync(paymentId);
        if (payment == null)
            return false;

        payment.Status = PaymentStatus.Confirmed;
        await repository.SaveAsync();
        return true;
    }
}