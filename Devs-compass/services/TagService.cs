using Devs_compass.DBConnection;
using Devs_compass.Models;
using Devs_compass.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Devs_compass.Services
{
    public class TagService
    {
        private ApiDbContext context;

        public TagService(ApiDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<Tag>> CreateTagAsync(CreateTagRequest request) {
            var tag = new Tag
            {
                Name = request.Name,
                Description = request.Description,
                Softwares = new()
            };

            await context.Tags.AddAsync(tag);
            await context.SaveChangesAsync();

            return tag;
        }

        public async Task<ActionResult<Tag>> GetTagAsync(int id)
        {
            var tag = await context.Tags.Include(t => t.Softwares).FirstOrDefaultAsync(t => t.Id == id);

            if (tag == null)
            {
                return null;
            }

            return tag;
        }

        public async Task<ActionResult<List<Tag>>> GetTagsAsync()
        {
            var tag = await context.Tags.Include(t => t.Softwares).ToListAsync();

            if (tag == null)
            {
                return null;
            }

            return tag;
        }

        public async Task<ActionResult<Tag>> DeleteTagAsync(int id)
        {
            var tag = await context.Tags.FindAsync(id);

            if (tag == null)
            {
                return null;
            }

            context.Tags.Remove(tag);
            await context.SaveChangesAsync();

            return tag;
        }

    }
}
