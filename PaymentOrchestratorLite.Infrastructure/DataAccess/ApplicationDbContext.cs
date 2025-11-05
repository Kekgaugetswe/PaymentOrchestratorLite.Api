using System;
using Microsoft.EntityFrameworkCore;
using PaymentOrchestratorLite.Domain.Payments.Entities;

namespace PaymentOrchestratorLite.Api.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Payment> Payment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}