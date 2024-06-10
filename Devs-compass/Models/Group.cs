using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models
{
    public class Group
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public List<Developer> Developers { get; set; }

        [Required]
        public List<Software> Softwares { get; set; }

        [Required]
        public List<GameJamParticipation> GameJamParisipations { get; set; }
    }
}
