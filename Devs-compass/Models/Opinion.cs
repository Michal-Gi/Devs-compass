using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs_compass.Models
{
    public class Opinion
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required float Score { get; set; }

        [Required]
        public required DateTime MakeDate { get; set; }

        [Required, ForeignKey("User")]
        public required int UserId { get; set; }

        [Required, ForeignKey("Software")]
        public required int SoftwareId { get; set; }
    }
}
