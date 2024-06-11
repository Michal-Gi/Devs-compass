using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs_compass.Models
{
    public class Opinion
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float Score { get; set; }

        [Required]
        public DateTime MakeDate { get; set; }

        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        [Required, ForeignKey("Software")]
        public int SoftwareId { get; set; }
    }
}
