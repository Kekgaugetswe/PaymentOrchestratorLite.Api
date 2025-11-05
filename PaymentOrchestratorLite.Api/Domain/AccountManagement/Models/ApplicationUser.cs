using Microsoft.AspNetCore.Identity;

namespace PaymentOrchestratorLite.Api.Domain.AccountManagement.Models;

public class ApplicationUser: IdentityUser
{
    public string? Firstname { get; set; }
    public string? Surname { get; set; }
    public string? CustomerId { get; set; }
    
}