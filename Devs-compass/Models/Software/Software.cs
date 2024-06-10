using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.Software
{
    public class Software
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
