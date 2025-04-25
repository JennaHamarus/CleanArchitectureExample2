using CleanArchitectureExample.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureExample.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRegistrationService _registrationService;

        public UsersController(IUserRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public IActionResult RegisterUser(string name, string email)
        {
            _registrationService.RegisterUser(name, email);
            return Ok("Rekisteröityminen onnistui");
        }
    }
}
