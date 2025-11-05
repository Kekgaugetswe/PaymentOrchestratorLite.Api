using PaymentOrchestratorLite.Api.Domain.Payments.enums;

namespace PaymentOrchestratorLite.Api.Domain.Payments.Entities;

public class Payment
{
    public Guid Id { get; set; }
    public string CustomerId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}