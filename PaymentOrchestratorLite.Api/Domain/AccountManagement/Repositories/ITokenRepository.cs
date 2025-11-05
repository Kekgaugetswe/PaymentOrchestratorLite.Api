using Microsoft.AspNetCore.Identity;

namespace PaymentOrchestratorLite.Api.Domain.AccountManagement.Repositories;

public interface ITokenRepository
{

    string CreateToken(IdentityUser user, List<string> roles);

}
