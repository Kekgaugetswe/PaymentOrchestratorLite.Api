using System;

namespace PaymentOrchestratorLite.Api.Domain.AccountManagement.Dtos;

public class RegisterRequestDto
{
    public string? Firstname { get; set; }
    public string? Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

}
