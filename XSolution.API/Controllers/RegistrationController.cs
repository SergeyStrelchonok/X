using Microsoft.AspNetCore.Mvc;
using XSolution.API.Services;
using XSolution.Data.IncomingModels;

namespace XSolution.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationService _registration;

        public RegistrationController(IRegistrationService registration)
        {
            _registration = registration;
        }

        [HttpGet]
        public async Task<List<KeyValuePair<int, string>>> GetAllCountries()
        {
            return await _registration.GetAllCountries();
        }

        [HttpGet]
        public async Task<List<KeyValuePair<int, string>>> GetProvincesByCountryId([FromQuery] int id)
        {
            return await _registration.GetProvincesByCountryId(id);
        }

        [HttpPost]
        public async Task<IActionResult> NewUser(UserIncoming model)
        {
            // some validate
            if (ModelState.IsValid)
            {
                // Save new user
                var newUser = await _registration.NewUserRegistration(model);
                return Ok(newUser);
            }
            else
                return BadRequest("Something went wrong");
        }
    }
}
