using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.DTOs
{
    public class SponsoredGameJamVM
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Motif { get; set; }

        public required DateTime StartDate { get; set; }

        public required int Duration { get; set; } = 24;

        public string? Link { get; set; }

        public string? Address { get; set; }

        public required int OrganizerId { get; set; }

        public List<GameJamParticipationVM> GameJamParticipations { get; set; }

        public List<SoftwareVM> Softwares { get; set; }
    }
}
