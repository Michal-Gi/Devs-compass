using Devs_compass.DBConnection;
using Devs_compass.Models.DTOs;
using Devs_compass.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Devs_compass.Controllers
{
    [ApiController, Route("/GameJam")]
    public class GameJamController : Controller
    {
        private GameJamService service;
        private ApiDbContext context;

        public GameJamController(GameJamService service, ApiDbContext context)
        {
            this.service = service;
            this.context = context;
        }


        [HttpPost("Sponsored")]
        public IActionResult CreateSponsoredGameJam(CreateSponsoredGameJamRequest request)
        {
            var res = service.CreateSponsoredGameJamAsync(request);
            if (res is null)
            {
                return BadRequest(request);
            }
            return Ok(res);
        }

        [HttpPost("Own")]
        public IActionResult CreateOwnGameJam(CreateOwnGameJamRequest request)
        {
            var res = service.CreateOwnGameJamAsync(request);
            if (res is null)
            {
                return BadRequest(request);
            }
            return Ok(res);
        }

        [HttpGet("Sponsored/{id:int}")]
        public IActionResult GetSponsoredGameJam(int id) {
            var jam = service.GetSponsoredGameJamAsync(id);
            if (jam is null) {
                return NotFound();
            }
            return Ok(jam);
        }
        /// <summary>
        /// Adds a group of developers to a game jam
        /// </summary>
        /// <param name="id"> id of the game jam</param>
        /// <param name="idGrupy">id of the group</param>
        /// <returns></returns>
        [HttpPost("Sponsored/Group/{id:int}")]
        public async Task<IActionResult> AddGroupToSponsoredGameJam(int id, [FromQuery] int idGrupy) {
            var res = await service.AddGroupToSponsoredGameJamAsync(id, idGrupy);
            if (res is null) {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpPost("Own/Group/{id:int}")]
        public async Task<IActionResult> AddGroupToOwnGameJam(int id, [FromQuery] int idGrupy)
        {
            var res = await service.AddGroupToOwnGameJamAsync(id, idGrupy);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpGet("Own")]
        public async Task<IActionResult> GetAllOwnGameJams() { 
            var res = await service.GetAllOwnGameJamsAsync();
            return Ok(res.Value);
        }
        [HttpGet("Sponsored")]
        public async Task<IActionResult> GetAllSponsoredGameJams()
        {
            var res = await service.GetAllSponsoredGameJamsAsync();
            return Ok(res.Value);
        }
        [HttpGet("Own/Active")]
        public async Task<IActionResult> GetAllActiveOwnGameJams()
        {
            var res = await service.GetAllOwnGameJamsAsync();
            return Ok(res.Value);
        }
        [HttpGet("Sponsored/Active")]
        public async Task<IActionResult> GetAllActiveSponsoredGameJams()
        {
            var res = await service.GetAllSponsoredGameJamsAsync();
            return Ok(res.Value);
        }
    }
}
