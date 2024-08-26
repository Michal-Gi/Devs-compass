using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models
{
    public class Tag
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        public List<Software> Softwares { get; set; }
    }
}
