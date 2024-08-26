using Devs_compass.DBConnection;
using Devs_compass.Models;
using Devs_compass.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Devs_compass.Services
{
    public class GroupService
    {

        private ApiDbContext context;

        public GroupService(ApiDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<Group>> CreateGroupAsync(CreateGroupRequest request)
        {
            var group = new Group
            {
                StartDate = request.StartDate,
                EndDate = null,
                Developers = new(),
                Softwares = new(),
                GameJamParticipations = new()
            };

            await context.Groups.AddAsync(group);
            await context.SaveChangesAsync();

            return group;
        }

        public async Task<ActionResult<Group>> GetGroupAsync(int id)
        {
            var group = await context.Groups.FindAsync(id);
            if (group is null)
            {
                return null;
            }
            return group;
        }

        public async Task<ActionResult<List<Group>>> GetGroupsAsync()
        {
            var groups = await context.Groups.Where(g => g.Id == g.Id).ToListAsync();
            if (groups is null)
            {
                return null;
            }
            return groups;
        }

        public async Task<ActionResult<Group>> DeleteGroupAsync(int id)
        {
            var group = await context.Groups.FindAsync(id);
            if (group is null)
            {
                return null;
            }
            context.Groups.Remove(group);
            await context.SaveChangesAsync();
            return group;
        }

        public async Task<ActionResult<List<Developer>>> AddGroupMembersAsync(int GroupId, List<int> MemberIds)
        {

            var group = await context.Groups.Include(g => g.Developers).Where(g => g.Id == GroupId).FirstOrDefaultAsync();
            if (group is null) {
                return null;
            }
            foreach (Developer dev in group.Developers) {
                if (MemberIds.Contains(dev.Id)) {
                    return null;
                }
            }

            List<Developer> devs = new();
            foreach (int id in MemberIds)
            {
                var dev = await context.Developers.FindAsync(id);
                if (dev is null)
                {
                    return null;
                }
                devs.Add(dev);
            }

            group.Developers.AddRange(devs);
            await context.SaveChangesAsync();

            return group.Developers;
        }

    }
}
