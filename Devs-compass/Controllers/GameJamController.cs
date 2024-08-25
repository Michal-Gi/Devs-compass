using Devs_compass.DBConnection;
using Devs_compass.Models.DTOs;
using Devs_compass.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
