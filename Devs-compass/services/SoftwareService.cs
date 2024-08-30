using Devs_compass.DBConnection;
using Devs_compass.Models;
using Devs_compass.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Devs_compass.Services
{
    public class SoftwareService
    {
        private ApiDbContext context;

        public SoftwareService(ApiDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<SoftwareVM>> CreateSoftwareAsync(CreateSoftwareRequest request)
        {
            if (request.UseLicense is null && request.TimeToBeat is null)
            {
                return null;
            }

            var tags = await context.Tags.Where(t => request.TagIds.Contains(t.Id)).ToListAsync();

            var soft = new Software
            {
                Name = request.Name,
                Description = request.Description,
                Opinions = new(),
                UseLicense = request.UseLicense,
                TimeToBeat = request.TimeToBeat,
                GameJamId = request.GameJamId,
                GroupId = request.GroupId,
                Tags = tags
            };

            context.Softwares.Add(soft);
            await context.SaveChangesAsync();

            return new SoftwareVM
            {
                Id = soft.Id,
                Name = soft.Name,
                Description = soft.Description,
                Opinions = soft.Opinions,
                TimeToBeat = soft.TimeToBeat,
                GameJamId = soft.GameJamId,
                GroupId = soft.GroupId
            };
        }

        public async Task<ActionResult<Software>> GetSoftwareAsync(int id)
        {
            var soft = await context.Softwares.Include(s => s.Opinions).FirstOrDefaultAsync(s => s.Id == id);
            if (soft is null)
            {
                return null;
            }
            return soft;
        }

        public async Task<ActionResult<Software>> DeleteSoftwareAsync(int id)
        {
            var soft = await context.Softwares.Include(s => s.Opinions).FirstOrDefaultAsync(s => s.Id == id);
            if (soft is null)
            {
                return null;
            }
            context.Opinions.RemoveRange(soft.Opinions);
            context.Softwares.Remove(soft);
            await context.SaveChangesAsync();
            return soft;
        }

        public async Task<ActionResult<List<Software>>> GetSoftwaresAsync()
        {
            var softs = await context.Softwares.ToListAsync();
            return softs;
        }
    }
}
