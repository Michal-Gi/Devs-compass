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

        public async Task<ActionResult<SponsoredGameJamVM>> GetSponsoredGameJamAsync(int id)
        {
            var jam = await context.SponsoredGameJams.Include(g => g.GameJamParticipations).Include(g => g.Softwares).ThenInclude(s => s.Opinions).Where(s => s.Id == id).FirstOrDefaultAsync();
            if (jam == null)
            {
                return null;
            }
            return new SponsoredGameJamVM
            {
                Id = jam.Id,
                OrganizerId = jam.OrganizerId,
                Name = jam.Name,
                Motif = jam.Motif,
                StartDate = jam.StartDate,
                Duration = jam.Duration,
                Softwares = jam.Softwares.Select(s => new SoftwareVM
                {
                    Id = s.Id,
                    Description = s.Description,
                    Name = s.Name,
                    GameJamId = s.GameJamId,
                    GroupId = s.GroupId,
                    Score = s.Score,
                    Opinions = s.Opinions
                }).ToList(),
                GameJamParticipations = jam.GameJamParticipations.Select(p => new GameJamParticipationVM
                {
                    Id = p.Id,
                    GameJamId = p.GameJamId,
                    GroupId = p.GroupId
                }).ToList()
            };
        }

        public async Task<ActionResult<GameJamParticipationVM>> AddGroupToSponsoredGameJamAsync(int idGameJam, int idGroup)
        {
            var jam = await context.SponsoredGameJams.FindAsync(idGameJam);
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

            context.GameJamsParticipations.Add(part);
            await context.SaveChangesAsync();

            return new GameJamParticipationVM
            {
                Id = part.Id,
                GameJamId = part.GameJamId,
                GroupId = part.GroupId
            };
        }
        public async Task<ActionResult<GameJamParticipationVM>> AddGroupToOwnGameJamAsync(int idGameJam, int idGroup)
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

            return new GameJamParticipationVM
            {
                Id = part.Id,
                GameJamId = part.GameJamId,
                GroupId = part.GroupId
            };
        }

        public async Task<ActionResult<List<OwnGameJam>>> GetAllOwnGameJamsAsync()
        {
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

        public async Task<ActionResult<List<Software>>> GetGameJamSoftwareAsync(int id)
        {
            var jam = await context.SponsoredGameJams.Include(g => g.Softwares).ThenInclude(s => s.Opinions).Where(g => g.Id == id).FirstOrDefaultAsync();
            if (jam is null)
            {
                return null;
            }
            return jam.Softwares;
        }

        public async Task<ActionResult<WinnerVM>> FinishGameJamManuallyAsync(int id, int softId)
        {
            var jam = await context.SponsoredGameJams
                .Include(g => g.Softwares)
                .ThenInclude(s => s.Opinions)
                .Include(g => g.GameJamParticipations)
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync();
            if (jam is null)
            {
                return null;
            }
            if (jam.Softwares.Any(s => s.Score == 0))
            {
                return null;
            }
            var soft = jam.Softwares.FirstOrDefault(s => s.Id == softId);
            if (soft is null)
            {
                return null;
            }

            var part = jam.GameJamParticipations.FirstOrDefault(p => p.GroupId == soft.GroupId);
            if (part is null)
            {
                return null;
            }

            var check = jam.GameJamParticipations.Any(p => p.Place == 1);
            if (check)
            {
                return new WinnerVM
                {
                    GameJamId = jam.Id,
                    GroupId = soft.GroupId,
                    SoftwareId = soft.Id,
                    SoftwareName = soft.Name,
                    GameJamMotif = jam.Motif,
                    GameJamName = jam.Name
                };
            }

            part.Place = 1;
            await context.SaveChangesAsync();
            return new WinnerVM
            {
                GameJamId = jam.Id,
                GroupId = soft.GroupId,
                SoftwareId = soft.Id,
                SoftwareName = soft.Name,
                GameJamMotif = jam.Motif,
                GameJamName = jam.Name
            };
        }

        public async Task<ActionResult<WinnerVM>> FinishGameJamAsync(int id)
        {
            var jam = await context.SponsoredGameJams
                .Include(g => g.Softwares)
                .ThenInclude(s => s.Opinions)
                .Include(g => g.GameJamParticipations)
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync();

            if (jam is null)
            {
                return null;
            }
            if (jam.Softwares.Any(s => s.Score == 0))
            {
                return null;
            }

            if (jam.GameJamParticipations.Any(p => p.Place == 1))
            {
                return await GetGameJamWinnerAsync(jam.Id);
            }
            var winner = jam.Softwares.OrderBy(g => -g.Score).FirstOrDefault();

            if (winner is null)
            {
                return null;
            }

            var contenders = jam.Softwares.Where(s => s.Id != winner.Id && s.Score == winner.Score).ToList();
            if (contenders.Any())
            {
                return null;
            }

            var part = jam.GameJamParticipations.FirstOrDefault(p => p.GroupId == winner.GroupId);
            if (part is null)
            {
                return null;
            }
            part.Place = 1;
            await context.SaveChangesAsync();
            return new WinnerVM
            {
                GameJamId = jam.Id,
                GameJamName = jam.Name,
                SoftwareId = winner.Id,
                SoftwareName = winner.Name,
                GameJamMotif = jam.Motif,
                GroupId = winner.GroupId
            };

        }

        public async Task<ActionResult<WinnerVM>> GetGameJamWinnerAsync(int id)
        {
            var jam = await context.SponsoredGameJams
                    .Include(g => g.Softwares)
                    .ThenInclude(s => s.Opinions)
                    .Include(g => g.GameJamParticipations)
                    .Where(g => g.Id == id)
                    .FirstOrDefaultAsync();

            if (jam is null)
            {
                return null;
            }
            if (!jam.GameJamParticipations.Any(p => p.Place == 1))
            {
                return null;
            }
            var part = jam.GameJamParticipations.FirstOrDefault(p => p.Place == 1);
            var soft = jam.Softwares.Where(s => s.GroupId == part.GroupId).First();
            return new WinnerVM
            {
                GameJamId = jam.Id,
                GameJamName = jam.Name,
                SoftwareId = soft.Id,
                GameJamMotif = jam.Motif,
                SoftwareName = soft.Name,
                GroupId = part.GroupId
            };

        }

        public async Task<ActionResult<List<SoftwareVM>>> GetContendersAsync(int id)
        {
            var jam = await context.SponsoredGameJams
                .Include(g => g.Softwares)
                .ThenInclude(s => s.Opinions)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (jam is null)
            {
                return null;
            }

            var topScore = jam.Softwares.Max(s => s.Score);

            var contenders = jam.Softwares.Where(s => s.Score == topScore).ToList();

            return contenders.Select(c => new SoftwareVM { 
                Description = c.Description,
                Name = c.Name,
                GroupId= c.GroupId,
                GameJamId= jam.Id,
                Score = c.Score,
                Id = c.Id
            }).ToList();
        }
    }
}
