using Devs_compass.Models.DTOs;
using Devs_compass.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devs_compass.Controllers
{
    [ApiController, Route("/Tag")]
    public class TagController : Controller
    {
        private TagService service;

        public TagController(TagService service)
        {
            this.service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateTag(CreateTagRequest request) {
            var res = await service.CreateTagAsync(request);
            if (res is null) {
                return BadRequest();
            }
            return Ok(res.Value);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTag(int id)
        {
            var res = await service.GetTagAsync(id);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpGet()]
        public async Task<IActionResult> GetTags()
        {
            var res = await service.GetTagsAsync();
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTag(int id) {
            var res = await service.DeleteTagAsync(id);
            if (res is null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
