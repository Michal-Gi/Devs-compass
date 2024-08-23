using Devs_compass.DBConnection;
using Devs_compass.Models;
using Devs_compass.Models.DTOs;
using Devs_compass.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devs_compass.Controllers
{
    [ApiController, Route("/User")]
    public class UserController : Controller
    {
        private UserService service;
        private ApiDbContext context;
        public UserController(UserService service, ApiDbContext context)
        {
            this.service = service;
            this.context = context;
        }
        [HttpPost("Developer")]
        public async Task<IActionResult> AddDeveloper([FromBody] CreateUserRequest developer)
        {
            var dev = await service.AddDeveloperAsync(developer);
            return Ok(dev);
        }
        [HttpPost("Organizer")]
        public async Task<IActionResult> AddOrganizer([FromBody] CreateUserRequest organizer)
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
        [HttpDelete("Developer/{id:int}")]
        public async Task<IActionResult> DeleteDeveloper(int id)
        {
            var result = await service.DeleteDeveloperAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("Organizer/{id:int}")]
        public async Task<IActionResult> DeleteOrganizer(int id)
        {
            var result = await service.DeleteOrganizerAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
