using PaymentOrchestratorLite.Domain.Payments.Entities;
using PaymentOrchestratorLite.Domain.SharedKernel;

namespace PaymentOrchestratorLite.Domain.Payments.interfaces.Repositories;

public interface IPaymentRepository
{
    Task AddAsync(Payment payment);
    Task<PaginatedResponse<Payment>> GetPagedAsync(PagedRequest request);
    Task<Payment?> GetByIdAsync(Guid id);
    Task SaveAsync();
    
}