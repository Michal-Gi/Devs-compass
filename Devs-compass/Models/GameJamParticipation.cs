using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models
{
    public class GameJamParticipation
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public GameJam GameJam { get; set; }

        [Required]
        public Group Group { get; set; }

        public int? Place {  get; set; }
    }
}
