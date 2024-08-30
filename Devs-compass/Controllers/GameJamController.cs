using Devs_compass.DBConnection;
using Devs_compass.Models;
using Devs_compass.Models.DTOs;
using Devs_compass.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel;

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

        /// <summary>
        /// Creates a new sponsored game jam.
        /// </summary>
        /// <param name="request">Details of the game jam we're setting up.</param>
        /// <returns>The sponsored game jam that gets created.</returns>
        [HttpPost("Sponsored")]
        public async Task<ActionResult<SponsoredGameJam>> CreateSponsoredGameJam(CreateSponsoredGameJamRequest request)
        {
            var res = await service.CreateSponsoredGameJamAsync(request);
            if (res is null)
            {
                return BadRequest(request);
            }
            return Ok(res.Value);
        }

        /// <summary>
        /// Creates a new own game jam.
        /// </summary>
        /// <param name="request">The details of the own game jam to create.</param>
        /// <returns>The created own game jam.</returns>
        [HttpPost("Own")]
        public async Task<ActionResult<OwnGameJam>> CreateOwnGameJam(CreateOwnGameJamRequest request)
        {
            var res = await service.CreateOwnGameJamAsync(request);
            if (res is null)
            {
                return BadRequest(request);
            }
            return Ok(res.Value);
        }

        /// <summary>
        /// Gets a sponsored game jam by its ID.
        /// </summary>
        /// <param name="id">The ID of the sponsored game jam.</param>
        /// <returns>The sponsored game jam we are looking for.</returns>
        /// <returns></returns>
        [HttpGet("Sponsored/{id:int}")]
        public async Task<ActionResult<SponsoredGameJam>> GetSponsoredGameJam(int id)
        {
            var jam = await service.GetSponsoredGameJamAsync(id);
            if (jam is null)
            {
                return NotFound();
            }
            return Ok(jam.Value);
        }

        /// <summary>
        /// Adds a group of developers to a sponsored game jam
        /// </summary>
        /// <param name="id">ID of the game jam.</param>
        /// <param name="idGrupy">ID of the group to add.</param>
        /// <returns>Updated sponsored game jam view model.</returns>
        [HttpPost("Sponsored/Group/{id:int}")]
        public async Task<ActionResult<SponsoredGameJamVM>> AddGroupToSponsoredGameJam(int id, [FromQuery] int idGrupy)
        {
            var res = await service.AddGroupToSponsoredGameJamAsync(id, idGrupy);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }


        /// <summary>
        /// Adds a group of developers to an own game jam.
        /// </summary>
        /// <param name="id">The ID of the game jam.</param>
        /// <param name="idGrupy">The ID of the group to add.</param>
        /// <returns>The updated own game jam if successful, otherwise NotFound.</returns>
        [HttpPost("Own/Group/{id:int}")]
        public async Task<ActionResult<OwnGameJam>> AddGroupToOwnGameJam(int id, [FromQuery] int idGrupy)
        {
            var res = await service.AddGroupToOwnGameJamAsync(id, idGrupy);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }


        [HttpGet("Own")]
        public async Task<ActionResult<List<OwnGameJam>>> GetAllOwnGameJams()
        {
            var res = await service.GetAllOwnGameJamsAsync();
            return Ok(res.Value);
        }
        [HttpGet("Sponsored")]
        public async Task<ActionResult<List<SponsoredGameJam>>> GetAllSponsoredGameJams()
        {
            var res = await service.GetAllSponsoredGameJamsAsync();
            return Ok(res.Value);
        }
        [HttpGet("Own/Active")]
        public async Task<ActionResult<List<OwnGameJam>>> GetAllActiveOwnGameJams()
        {
            var res = await service.GetAllOwnGameJamsAsync();
            return Ok(res.Value);
        }
        [HttpGet("Sponsored/Active")]
        public async Task<ActionResult<List<SponsoredGameJam>>> GetAllActiveSponsoredGameJams()
        {
            var res = await service.GetAllSponsoredGameJamsAsync();
            return Ok(res.Value);
        }

        [HttpGet("Sponsored/{id:int}/software")]
        public async Task<ActionResult<List<Software>>> GetGameJamSoftware(int id)
        {
            var res = await service.GetGameJamSoftwareAsync(id);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpPost("Sponsored/{id:int}/Winner/{softId:int}")]
        public async Task<IActionResult> FinishGameJamManually(int id, int softId)
        {
            var res = await service.FinishGameJamManuallyAsync(id, softId);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpPost("Sponsored/{id:int}/Winner")]
        public async Task<IActionResult> FinishGameJam(int id)
        {
            var res = await service.FinishGameJamAsync(id);
            if (res is null)
            {
                return BadRequest();
            }
            return Ok(res.Value);
        }

        [HttpGet("Sponsored/{id:int}/Winner")]
        public async Task<IActionResult> GetGameJamWinner(int id)
        {
            var res = await service.GetGameJamWinnerAsync(id);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpGet("Sponsored/{id:int}/Contenders")]
        public async Task<IActionResult> GetContenders(int id)
        {
            var res = await service.GetContendersAsync(id);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }
    }
}
