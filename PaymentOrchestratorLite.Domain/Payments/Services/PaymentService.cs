using Microsoft.Extensions.Logging;
using PaymentOrchestratorLite.Domain.Payments.Dtos;
using PaymentOrchestratorLite.Domain.Payments.Entities;
using PaymentOrchestratorLite.Domain.Payments.enums;
using PaymentOrchestratorLite.Domain.Payments.interfaces.Repositories;
using PaymentOrchestratorLite.Domain.Payments.interfaces.services;
using PaymentOrchestratorLite.Domain.SharedKernel;

namespace PaymentOrchestratorLite.Domain.Payments.Services;

public class PaymentService(IPaymentRepository repository, ILogger<PaymentService> logger) : IPaymentService
{
    public async Task<Payment> CreatePaymentAsync(string customerId, decimal amount)
    {
        logger.LogInformation("Creating new payment for Customer {CustomerId} with Amount {Amount}", customerId, amount);

        var payment = new Payment
        {
            CustomerId = customerId,
            Amount = amount,
            Status = PaymentStatus.Pending
        };

        await repository.AddAsync(payment);

        logger.LogInformation("Payment {PaymentId} created successfully", payment.Id);

        return payment;
    }

    public async Task<ApiResponse<PaginatedResponse<PaymentDto>>> GetPaymentsAsync(PagedRequest request)
    {
        logger.LogInformation(
            "Fetching payments Page {PageNumber} Size {PageSize} Search '{SearchTerm}'",
            request.PageNumber, request.PageSize, request.SearchTerm ?? "none"
        );

        var pagedResult = await repository.GetPagedAsync(request);

        var dtoPagedResult = new PaginatedResponse<PaymentDto>
        {
            Items = pagedResult.Items.Select(p => new PaymentDto
            {
                Id = p.Id,
                Amount = p.Amount,
                Status = p.Status,
                CustomerId = p.CustomerId,
                CreatedAt = p.CreatedAt
            }),
            TotalCount = pagedResult.TotalCount,
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize
        };

        logger.LogInformation("Returning {Count} payments (Total {Total})",
            dtoPagedResult.Items.Count(), dtoPagedResult.TotalCount);

        return new ApiResponse<PaginatedResponse<PaymentDto>>
        {
            Success = true,
            Message = "Payments retrieved successfully.",
            Data = dtoPagedResult
        };
    }
    public async Task<bool> ConfirmPaymentAsync(Guid paymentId)
    {
        logger.LogInformation("Attempting to confirm payment {PaymentId}", paymentId);

        var payment = await repository.GetByIdAsync(paymentId);

        if (payment == null)
        {
            logger.LogWarning("Payment {PaymentId} not found, cannot confirm", paymentId);
            return false;
        }

        if (payment.Status == PaymentStatus.Confirmed)
        {
            logger.LogInformation("Payment {PaymentId} is already confirmed", paymentId);
            return true;
        }

        payment.Status = PaymentStatus.Confirmed;
        await repository.SaveAsync();

        logger.LogInformation("Payment {PaymentId} confirmed successfully", paymentId);

        return true;
    }
}