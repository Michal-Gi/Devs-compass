using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models
{
    public class Tag
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public List<Software> Softwares { get; set; }
    }
}
