using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.Tag
{
    public class CreateTagRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
