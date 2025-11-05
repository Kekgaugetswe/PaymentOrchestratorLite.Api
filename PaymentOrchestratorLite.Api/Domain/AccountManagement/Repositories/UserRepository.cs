using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaymentOrchestratorLite.Api.DataAccess;

namespace PaymentOrchestratorLite.Api.Domain.AccountManagement.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthDbContext authDbContext;

    public UserRepository(AuthDbContext authDbContext)
    {
        this.authDbContext = authDbContext;
    }
    public async Task<IEnumerable<IdentityUser>> GetAllAsync()
    {
        var users = await authDbContext.Users.ToListAsync();

        var AdminUser = await authDbContext.Users.FirstOrDefaultAsync(x => x.Email == "admin@codejournalx.com");
        if (AdminUser != null)
        {
            users.Remove(AdminUser);
        }

        return users;
    }
}
