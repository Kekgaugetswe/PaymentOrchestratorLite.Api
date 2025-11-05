using Microsoft.AspNetCore.Mvc;
using PaymentOrchestratorLite.Api.Domain.AccountManagement.Dtos;
using PaymentOrchestratorLite.Api.Domain.AccountManagement.Repositories;

namespace PaymentOrchestratorLite.Api.Domain.AccountManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Route("users")]

        public async Task<IActionResult> GetAll()
        {
            var users = await userRepository.GetAllAsync();

            var userList = new List<UserDto>();
            foreach (var user in users)
            {
                userList.Add(new UserDto()
                {
                    Id = Guid.Parse(user.Id),
                    UserName = user.UserName,
                    Email = user.Email,
                });

            }

            return Ok(userList);
        }
    }
}
