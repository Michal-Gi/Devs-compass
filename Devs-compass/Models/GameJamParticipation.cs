using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs_compass.Models
{
    public class GameJamParticipation
    {
        [Required, Key]
        public int Id { get; set; }

        [Required, ForeignKey("GameJam")]
        public required int GameJamId { get; set; }
        public GameJam GameJam { get; set; }

        [Required, ForeignKey("Group")]
        public required int GroupId { get; set; }
        public Group Group { get; set; }

        public int? Place {  get; set; }
    }
}
