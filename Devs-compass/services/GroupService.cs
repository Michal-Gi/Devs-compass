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

        public async Task<ActionResult<GroupVM>> CreateGroupAsync(CreateGroupRequest request)
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

            return new GroupVM
            {
                Id = group.Id,
                StartDate = group.StartDate,
                EndDate = group.EndDate,
                Developers = group.Developers.Select(d => new DeveloperVM
                {
                    Id = d.Id,
                    Password = d.Password,
                    Login = d.Login,
                    Email = d.Email
                }).ToList()
            };
        }

        public async Task<ActionResult<GroupVM>> GetGroupAsync(int id)
        {
            var group = await context.Groups
                .Include(g => g.Softwares)
                .Include(g => g.Developers)
                .Include(g => g.GameJamParticipations)
                .FirstOrDefaultAsync(g => g.Id == id);
            if (group is null)
            {
                return null;
            }
            return new GroupVM
            {
                Id = group.Id,
                StartDate = group.StartDate,
                EndDate = group.EndDate,
                Developers = group.Developers.Select(d => new DeveloperVM
                {
                    Id = d.Id,
                    Password = d.Password,
                    Login = d.Login,
                    Email = d.Email
                }).ToList()
            };
        }

        public async Task<ActionResult<List<GroupVM>>> GetGroupsAsync()
        {
            var groups = await context.Groups
                .Include(g => g.Softwares)
                .Include(g => g.Developers)
                .Include(g => g.GameJamParticipations)
                .Where(g => g.Id == g.Id).ToListAsync();
            if (groups is null)
            {
                return null;
            }
            return groups.Select(group => new GroupVM {
                Id = group.Id,
                StartDate = group.StartDate,
                EndDate = group.EndDate,
                Developers = group.Developers.Select(d => new DeveloperVM
                {
                    Id = d.Id,
                    Password = d.Password,
                    Login = d.Login,
                    Email = d.Email
                }).ToList()
            }).ToList();
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

        public async Task<ActionResult<List<UserVM>>> AddGroupMembersAsync(int GroupId, List<int> MemberIds)
        {

            var group = await context.Groups.Include(g => g.Developers).Where(g => g.Id == GroupId).FirstOrDefaultAsync();
            if (group is null)
            {
                return null;
            }
            foreach (Developer dev in group.Developers)
            {
                if (MemberIds.Contains(dev.Id))
                {
                    MemberIds.Remove(dev.Id);
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

            return group.Developers.Select(d => new UserVM
            {
                Email = d.Email,
                Id = d.Id,
                Password = d.Password,
                Login = d.Login
            }).ToList();
        }

    }
}
