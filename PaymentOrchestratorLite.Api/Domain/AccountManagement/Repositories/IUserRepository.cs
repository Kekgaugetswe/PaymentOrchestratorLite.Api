using System;
using Microsoft.AspNetCore.Identity;

namespace PaymentOrchestratorLite.Api.Domain.AccountManagement.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<IdentityUser>> GetAllAsync();

}
