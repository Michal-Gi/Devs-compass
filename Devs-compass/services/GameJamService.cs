using Devs_compass.DBConnection;
using Devs_compass.Models;
using Devs_compass.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Devs_compass.Services
{
    public class GameJamService
    {
        private ApiDbContext context;
        public GameJamService(ApiDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<SponsoredGameJam>> CreateSponsoredGameJamAsync(CreateSponsoredGameJamRequest request)
        {
            var SponsoredGameJam = new SponsoredGameJam
            {
                Name = request.Name,
                Motif = request.Motif,
                StartDate = request.StartDate,
                Duration = request.Duration,
                Link = request.link,
                Address = request.address,
                OrganizerId = request.OrganizerId,
                GameJamParticipations = new(),
                Softwares = new(),
                Sponsor = request.Sponsor
            };

            await context.SponsoredGameJams.AddAsync(SponsoredGameJam);
            await context.SaveChangesAsync();

            var result = await context.SponsoredGameJams.FindAsync(SponsoredGameJam.Id);
            return result;
        }

        public async Task<ActionResult<OwnGameJam>> CreateOwnGameJamAsync(CreateOwnGameJamRequest request)
        {
            var OwnGameJam = new OwnGameJam
            {
                Name = request.Name,
                Motif = request.Motif,
                StartDate = request.StartDate,
                Duration = request.Duration,
                Link = request.link,
                Address = request.address,
                OrganizerId = request.OrganizerId,
                GameJamParticipations = new(),
                Softwares = new(),
                Price = request.Price
            };

            await context.OwnGameJams.AddAsync(OwnGameJam);
            await context.SaveChangesAsync();

            var result = await context.OwnGameJams.FindAsync(OwnGameJam.Id);
            return result;
        }

        public async Task<ActionResult<SponsoredGameJam>> GetSponsoredGameJamAsync(int id)
        {
            var jam = await context.SponsoredGameJams.Where(s => s.Id == id).FirstOrDefaultAsync();
            return jam;
        }
    }
}
