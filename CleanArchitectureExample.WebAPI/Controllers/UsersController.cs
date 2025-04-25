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

        [HttpPost("UserAsync")]
        public async Task<IActionResult>RegisterUserAsync(string name, string email)
        {
            //Onko nimi ja sähköposti annettu?
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                return BadRequest("Nimi ja sähköpostiosoite ovat pakollisia tietoja.");
            }

            //Onko sähöposti oikeassa muodossa?
            var isExistingEmail = await _registrationService.EmailExistsAsync(email);

            if (isExistingEmail)
            {
                return BadRequest("Sähköpostiosoite on jo käytössä.");
            }

            //Onnistuiko rekisteröinti?
            var success = await _registrationService.RegisterUserAsync(name, email);

            if (!success)
            {
                return BadRequest("Rekisteröinti epäonnistui.");
            }

            return Created();
        }
    }
}
