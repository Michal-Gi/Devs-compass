using Devs_compass.Models;
using Devs_compass.Models.DTOs;
using Devs_compass.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Devs_compass.Controllers
{
    [ApiController, Route("/Software")]
    public class SoftwareController : Controller
    {
        private SoftwareService service;

        public SoftwareController(SoftwareService service)
        {
            this.service = service;
        }

        [HttpPost()]
        public async Task<ActionResult> CreateSoftware(CreateSoftwareRequest request)
        {
            var res = await service.CreateSoftwareAsync(request);
            if (res is null)
            {
                return BadRequest();
            }
            return Ok(res);
        }

        [HttpGet()]
        public async Task<ActionResult<List<Software>>> GetSoftwares()
        {
            var res = await service.GetSoftwaresAsync();
            return Ok(res.Value);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Software>> GetSoftware(int id)
        {
            var res = await service.GetSoftwareAsync(id);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Software>> DeleteSoftware(int id)
        {
            var res = await service.DeleteSoftwareAsync(id);
            if (res is null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
