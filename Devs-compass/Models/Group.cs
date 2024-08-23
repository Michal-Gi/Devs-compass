using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models
{
    public class Group
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public required DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public required List<Developer> Developers { get; set; }

        public List<Software> Softwares { get; set; }

        public List<GameJamParticipation> GameJamParticipations { get; set; }
    }
}
