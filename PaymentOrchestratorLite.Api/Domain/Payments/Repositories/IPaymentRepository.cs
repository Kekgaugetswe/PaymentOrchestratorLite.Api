using PaymentOrchestratorLite.Api.Domain.Payments.Entities;

namespace PaymentOrchestratorLite.Api.Domain.Payments.Repositories;

public interface IPaymentRepository
{
    Task AddAsync(Payment payment);
    Task<List<Payment>> GetAllAsync();
    Task<Payment> GetByIdAsync(Guid id);
    Task SaveAsync();
    
}