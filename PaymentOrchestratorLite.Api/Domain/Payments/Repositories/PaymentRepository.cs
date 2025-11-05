using Microsoft.EntityFrameworkCore;
using PaymentOrchestratorLite.Api.DataAccess;
using PaymentOrchestratorLite.Api.Domain.Payments.Entities;

namespace PaymentOrchestratorLite.Api.Domain.Payments.Repositories;

public class PaymentRepository(ApplicationDbContext dbContext) : IPaymentRepository
{
    public async Task AddAsync(Payment payment)
    {
        await dbContext.Payment.AddAsync(payment);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<Payment>> GetAllAsync()
    {
       return  await dbContext.Payment.OrderByDescending(p => p.CreatedAt).ToListAsync();
    }

    public async Task<Payment> GetByIdAsync(Guid id)
    {
       return await dbContext.Payment.FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task SaveAsync()
        => dbContext.SaveChangesAsync();
}