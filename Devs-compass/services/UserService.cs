using Devs_compass.DBConnection;
using Devs_compass.Models;
using Devs_compass.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Devs_compass.Services
{
    public class UserService
    {
        private ApiDbContext context;
        public UserService(ApiDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<Developer>> GetDeveloperAsync(int id)
        {
            var developer = await context.Developers.FindAsync(id);
            return developer;
        }

        public async Task<ActionResult<Organizer>> GetOrganizerAsync(int id)
        {
            var organizer = await context.Organizers.FindAsync(id);
            return organizer;
        }

        public async Task<ActionResult<UserVM>> AddDeveloperAsync(CreateUserRequest request)
        {
            var developer = new Developer
            {
                Email = request.Email,
                Login = request.Login,
                Password = request.Password,
                groups = new()
            };

            await context.Developers.AddAsync(developer);
            await context.SaveChangesAsync();
            return new UserVM
            {
                Id = developer.Id,
                Login = developer.Login,
                Password = developer.Password,
                Email = developer.Email,
            };
        }

        public async Task<ActionResult<UserVM>> AddOrganizerAsync(CreateUserRequest request)
        {
            var organizer = new Organizer
            {
                Email = request.Email,
                Login = request.Login,
                Password = request.Password,
                GameJams = new()
            };

            await context.Organizers.AddAsync(organizer);
            await context.SaveChangesAsync();

            return new UserVM
            {
                Email = organizer.Email,
                Login = organizer.Login,
                Password = organizer.Password,
                Id = organizer.Id
            };
        }

        public async Task<bool> DeleteDeveloperAsync(int id)
        {
            var dev = context.Developers.Where(d => d.Id == id).FirstOrDefault();
            if (dev != null)
            {
                context.Developers.Remove(dev);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteOrganizerAsync(int id)
        {
            var org = context.Organizers.Where(d => d.Id == id).FirstOrDefault();
            if (org != null)
            {
                context.Organizers.Remove(org);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ActionResult<UserVM>> ChangeDeveloperToOrganizerAsync(int id) {
            var dev = await context.Developers.FindAsync(id);
            if (dev is null) {
                return null;
            }
            var org = new Organizer
            {
                Email = dev.Email,
                Login = dev.Login,
                Password = dev.Password,
                GameJams = new(),
                Opinions = dev.Opinions
            };

            await context.Organizers.AddAsync(org);
            context.Developers.Remove(dev);
            await context.SaveChangesAsync();
            return new UserVM
            {
                Email = org.Email,
                Login = org.Login,
                Password = org.Password,
                Id = org.Id
            };
        }
        public async Task<ActionResult<UserVM>> ChangeOrganizerToDeveloperAsync(int id)
        {
            var org = await context.Organizers.FindAsync(id);
            if (org is null)
            {
                return null;
            }
            var dev = new Developer
            {
                Email = org.Email,
                Login = org.Login,
                Password = org.Password,
                groups = new(),
                Opinions = org.Opinions
            };

            await context.Developers.AddAsync(dev);
            context.Organizers.Remove(org);
            await context.SaveChangesAsync();
            return new UserVM
            {
                Email = dev.Email,
                Login = dev.Login,
                Password = dev.Password,
                Id = dev.Id
            };
        }

        public async Task<ActionResult<List<Group>>> GetGroupsAsync(int id) {
            var dev = await context.Developers.Include(d => d.groups).Where(d => d.Id == id).FirstOrDefaultAsync();
            if (dev is null) {
                return null;
            }
            return dev.groups;
        }
    }
}
