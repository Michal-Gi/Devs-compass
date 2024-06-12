using Devs_compass.DBConnection;
using Devs_compass.Models;
using Devs_compass.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devs_compass.Controllers
{
    [ApiController, Route("/User")]
    public class UserController(UserService service, ApiDbContext context) : Controller
    {
        [HttpPost("Developer")]
        public async Task<IActionResult> AddDeveloper([FromBody] Developer devloper)
        {
            return Ok();
        }
        [HttpPost("Organizer")]
        public async Task<IActionResult> AddOrganizer([FromBody] Organizer organizer)
        {
            return Ok();
        }
        [HttpGet("Developer/{id:int}")]
        public async Task<IActionResult> GetDeveloper(int id)
        {
            var result = await service.GetDeveloperAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.Value);
        }
        [HttpGet("Organizer/{id:int}")]
        public async Task<IActionResult> GetOrganizer(int id)
        {
            var result = await service.GetOrganizerAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.Value);
        }
    }
}
