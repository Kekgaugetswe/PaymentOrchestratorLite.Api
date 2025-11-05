using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaymentOrchestratorLite.Api.Domain.AccountManagement.Models;

namespace PaymentOrchestratorLite.Api.DataAccess;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // ---- STATIC IDS ----
        const string readerRoleId = "3ef9235c-df3d-4d09-a54e-03adc9ed2283";
        const string writerRoleId = "12a1d508-95f2-4fe2-a712-532fca8e5b9f";
        const string adminUserId  = "dbbe523f-8929-44e0-b440-32ebd86f526d";

        // ---- STATIC PASSWORD HASH ----
        // Password = Admin@123 (generated once and hard-coded)
        const string adminPasswordHash =
            "AQAAAAIAAYagAAAAECfQsOEJ2vPLZnjyDBwFy1uPyTRW23oUOjJ6RHOVE1Q2Vx8uV6EY2IZyZ2/WYcd9BQ==";

        const string adminSecurityStamp = "f28b0e62-aa07-4616-86ed-344d01ce3a6e";
        const string adminEmail = "admin@paymentorchestrator.com";

        // ---- ROLES ----
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = readerRoleId,
                Name = "Reader",
                NormalizedName = "READER",
                ConcurrencyStamp = readerRoleId
            },
            new IdentityRole
            {
                Id = writerRoleId,
                Name = "Writer",
                NormalizedName = "WRITER",
                ConcurrencyStamp = writerRoleId
            }
        );

        // ---- ADMIN USER ----
        builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = adminUserId,
                UserName = adminEmail,
                NormalizedUserName = adminEmail.ToUpper(),
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = adminPasswordHash,
                SecurityStamp = adminSecurityStamp,
                ConcurrencyStamp = adminSecurityStamp,
                
                //custom fields
                Firstname = "Administrator",
                Surname = "Sebati",
                CustomerId = "CUST-0001"
                
            }
        );

        // ---- ADMIN ROLES ----
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = adminUserId, RoleId = readerRoleId },
            new IdentityUserRole<string> { UserId = adminUserId, RoleId = writerRoleId }
        );
    }
}