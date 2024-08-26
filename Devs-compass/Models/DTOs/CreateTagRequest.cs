using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.DTOs
{
    public class CreateTagRequest
    {
        public required string Name { get; set; }

        public required string Description { get; set; }
    }
}
