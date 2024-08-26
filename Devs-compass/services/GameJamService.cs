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

        public async Task<ActionResult<GameJamParticipation>> AddGroupToSponsoredGameJamAsync(int idGameJam, int idGroup) {
            var jam = await context.SponsoredGameJams.FindAsync(idGameJam);
            if (jam is null) {
                return null;
            }
            var group = await context.Groups.FindAsync(idGroup);
            if (group is null)
            {
                return null;
            }

            var part = new GameJamParticipation
            {
                GameJamId = jam.Id,
                GroupId = group.Id,
                Group = group,
                GameJam = jam,
                Place = null
            };

            return part;
        }
        public async Task<ActionResult<GameJamParticipation>> AddGroupToOwnGameJamAsync(int idGameJam, int idGroup)
        {
            var jam = await context.OwnGameJams.FindAsync(idGameJam);
            if (jam is null)
            {
                return null;
            }
            var group = await context.Groups.FindAsync(idGroup);
            if (group is null)
            {
                return null;
            }

            var part = new GameJamParticipation
            {
                GameJamId = jam.Id,
                GroupId = group.Id,
                Group = group,
                GameJam = jam,
                Place = null
            };

            await context.GameJamsParticipations.AddAsync(part);
            context.SaveChanges();

            return part;
        }

        public async Task<ActionResult<List<OwnGameJam>>> GetAllOwnGameJamsAsync() {
            var jams = await context.OwnGameJams.Where(g => g.Id == g.Id).ToListAsync();
            return jams;
        }
        public async Task<ActionResult<List<SponsoredGameJam>>> GetAllSponsoredGameJamsAsync()
        {
            var jams = await context.SponsoredGameJams.Where(g => g.Id == g.Id).ToListAsync();
            return jams;
        }
        public async Task<ActionResult<List<OwnGameJam>>> GetAllActiveOwnGameJamsAsync()
        {
            var jams = await context.OwnGameJams.Where(g => g.StartDate < DateTime.UtcNow && g.StartDate.AddHours(g.Duration) > DateTime.UtcNow).ToListAsync();
            return jams;
        }
        public async Task<ActionResult<List<SponsoredGameJam>>> GetAllActiveSponsoredGameJamsAsync()
        {
            var jams = await context.SponsoredGameJams.Where(g => g.StartDate < DateTime.UtcNow && g.StartDate.AddHours(g.Duration) > DateTime.UtcNow).ToListAsync();
            return jams;
        }
    }
}
