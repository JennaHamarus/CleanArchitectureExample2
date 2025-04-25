using CleanArchitectureExample.Application.Interfaces;
using CleanArchitectureExample.WebAPI.Models;
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

        [HttpPost("UserAsync")]
        public async Task<IActionResult>RegisterUserAsync([FromBody] UserRegistrationRequest request)
        {
            //ASP.NET validoi pyynnön automaattisesti ja palauttaa virheen, jos validointi epäonnistuu
            var isExistingEmail = await _registrationService.EmailExistsAsync(request.Email);

            if (isExistingEmail)
            {
                return BadRequest("Sähköpostiosoite on jo käytössä.");
            }

            //Onnistuiko rekisteröinti?
            var success = await _registrationService.RegisterUserAsync(request.Name, request.Email);

            if (!success)
            {
                return BadRequest("Rekisteröinti epäonnistui.");
            }

            //Palautetaan onnistunut rekisteröinti
            return Created();
        }
    }
}
