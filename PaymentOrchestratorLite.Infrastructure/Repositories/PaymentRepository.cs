using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PaymentOrchestratorLite.Api.DataAccess;
using PaymentOrchestratorLite.Domain.Payments.Entities;
using PaymentOrchestratorLite.Domain.Payments.interfaces.Repositories;
using PaymentOrchestratorLite.Domain.SharedKernel;

namespace PaymentOrchestratorLite.Infrastructure.Repositories;

public class PaymentRepository(ApplicationDbContext dbContext, ILogger<PaymentRepository> logger) : IPaymentRepository
{
    public async Task AddAsync(Payment payment)
    {
        logger.LogInformation("Adding new payment for CustomerId {CustomerId}, Amount {Amount}",
            payment.CustomerId, payment.Amount);

        await dbContext.Payment.AddAsync(payment);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Payment {PaymentId} successfully created", payment.Id);
    }

    
    public async Task<Payment?> GetByIdAsync(Guid id)
    {
        logger.LogInformation("Retrieving payment with Id {PaymentId}", id);

        var payment = await dbContext.Payment.FirstOrDefaultAsync(p => p.Id == id);

        if (payment == null)
        {
            logger.LogWarning("Payment with Id {PaymentId} was not found", id);
        }
        else
        {
            logger.LogInformation("Payment {PaymentId} retrieved successfully", id);
        }

        return payment;
    }
    
    
    public async Task<PaginatedResponse<Payment>> GetPagedAsync(PagedRequest request)
    {
        logger.LogInformation(
            "Fetching payments Page {PageNumber}, Size {PageSize}, Search '{SearchTerm}'",
            request.PageNumber, request.PageSize, request.SearchTerm ?? "none");

        var query = dbContext.Payment.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var term = request.SearchTerm.Trim().ToLower();

            query = query.Where(p =>
                p.Id.ToString().ToLower().Contains(term) ||
                p.Status.ToString().ToLower().Contains(term) ||
                p.CustomerId.ToString().ToLower().Contains(term));
        }

        var totalCount = await query.CountAsync();

        if (totalCount == 0)
        {
            logger.LogInformation("No payments found matching search criteria '{SearchTerm}'", request.SearchTerm);
        }

        var items = await query
            .OrderByDescending(p => p.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        logger.LogInformation("Returning {Count} payments out of total {Total}", items.Count, totalCount);

        return new PaginatedResponse<Payment>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }


    public Task SaveAsync()
        => dbContext.SaveChangesAsync();
}