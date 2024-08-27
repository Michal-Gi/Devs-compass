using Devs_compass.Models;
using Devs_compass.Models.DTOs;
using Devs_compass.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devs_compass.Controllers
{
    [ApiController, Route("/Opinion")]
    public class OpinionController : Controller
    {
        private OpinionService service;
        public OpinionController(OpinionService service)
        {
            this.service = service;
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult<Opinion>> CreateOpinion(CreateOpinionRequest request)
        {
            var res = await service.CreateOpinionAsync(request);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Opinion>> GetOpinion(int id)
        {
            var res = await service.GetOpinionAsync(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Opinion>> DeleteOpinion(int id)
        {
            var res = await service.DeleteOpinionAsync(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }
    }
}
