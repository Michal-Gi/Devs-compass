using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs_compass.Models
{
    public abstract class GameJam
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
        [Required]
        public required string motif { get; set; }

        [Required]
        public required DateTime StartDate { get; set; }

        [Required]
        public required int Duration { get; set; } = 24;

        public string? link { get; set; }

        public string? address { get; set; }

        [Required, ForeignKey("Organizer")]
        public required int OrganizerId { get; set; }

        public List<GameJamParticipation> GameJamParticipations { get; set; }

        public List<Software> Softwares { get; set; }
    }
}
