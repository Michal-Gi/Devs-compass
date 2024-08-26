using Devs_compass.DBConnection;
using Devs_compass.Models.DTOs;
using Devs_compass.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devs_compass.Controllers
{
    [ApiController, Route("/Group")]
    public class GroupController : Controller
    {
        private GroupService service;
        private ApiDbContext context;

        public GroupController(GroupService service, ApiDbContext context)
        {
            this.context = context;
            this.service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupRequest request)
        {
            var res = await service.CreateGroupAsync(request);
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGroup(int id) {
            var res = await service.GetGroupAsync(id);
            if (res is null) {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpGet()]
        public async Task<IActionResult> GetGroups() {
            var res = await service.GetGroupsAsync();
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGroup(int id) {
            var res = await service.DeleteGroupAsync(id);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(res.Value);
        }

        [HttpPost("{GroupId:int}/Members")]
        public async Task<IActionResult> AddGroupMembers(int GroupId, [FromBody] List<int> MemberIds) {
            var res = await service.AddGroupMembersAsync(GroupId, MemberIds);
            if (res is null)
            {
                return BadRequest();
            }
            return Ok(res.Value);
        }

    }
}
