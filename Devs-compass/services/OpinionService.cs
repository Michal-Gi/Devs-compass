using Devs_compass.DBConnection;
using Devs_compass.Models;
using Devs_compass.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Devs_compass.Services
{
    public class OpinionService
    {
        private ApiDbContext context;

        public OpinionService(ApiDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<Opinion>> CreateOpinionAsync(CreateOpinionRequest request)
        {
            var user = await context.Organizers.FindAsync(request.UserId);
            if (user == null)
            {
                return null;
            }
            var soft = await context.Softwares.FindAsync(request.SoftwareId);
            if (soft == null)
            {
                return null;
            }
            var opinia = new Opinion
            {
                Name = request.Name,
                Description = request.Description,
                Score = request.Score,
                MakeDate = DateTime.UtcNow,
                UserId = request.UserId,
                SoftwareId = request.SoftwareId,
            };
            context.Add(opinia);
            await context.SaveChangesAsync();
            return opinia;
        }

        public async Task<ActionResult<Opinion>> GetOpinionAsync(int id)
        {
            var op = await context.Opinions.FindAsync(id);
            if (op == null)
            {
                return null;
            }
            return op;
        }

        public async Task<ActionResult<Opinion>> DeleteOpinionAsync(int id)
        {
            var op = await context.Opinions.FindAsync(id);
            if (op == null)
            {
                return null;
            }
            context.Opinions.Remove(op);
            await context.SaveChangesAsync();
            return op;
        }
    }
}
