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
            var org = await service.AddOrganizerAsync(organizer);
            return Ok(org);
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
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("Organizer/{id:int}")]
        public async Task<IActionResult> DeleteOrganizer(int id)
        {
            var result = await service.DeleteOrganizerAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Implements dynamic inheritance between Developer and Organizer
        /// </summary>
        /// <param name="id"> id of developer to change into organizer</param>
        /// <returns></returns>
        [HttpPost("DeveloperToOrganizer/{id:int}")]
        public async Task<IActionResult> ChangeDeveloperToOrganizer(int id)
        {
            var res = await service.ChangeDeveloperToOrganizerAsync(id);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }
        /// <summary>        
        /// Implements dynamic inheritance between Organizer and Developer
        /// </summary>
        /// <param name="id"> id of organizer to change into developer</param>
        /// <returns></returns>
        [HttpPost("OrganizerToDeveloper/{id:int}")]
        public async Task<IActionResult> ChangeOrganizerToDeveloper(int id)
        {
            var res = await service.ChangeOrganizerToDeveloperAsync(id);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }

        /// <summary>
        /// Gets the groups of specified user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}/Groups")]
        public async Task<IActionResult> GetGroups(int id)
        {
            var res = await service.GetGroupsAsync(id);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }
    }
}
