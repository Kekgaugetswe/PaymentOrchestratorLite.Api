using Microsoft.Extensions.DependencyInjection;
using PaymentOrchestratorLite.Domain.Payments.interfaces.services;
using PaymentOrchestratorLite.Domain.Payments.Services;

namespace PaymentOrchestratorLite.Domain.Extensions;

public static class DomainExtensions
{

    public static IServiceCollection AddDomain(this IServiceCollection services)
    {

        services.AddServices();
        return services;

    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPaymentService, PaymentService>();
        return services;
    }
    
}