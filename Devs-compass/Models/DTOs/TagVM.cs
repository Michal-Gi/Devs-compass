using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.DTOs
{
    public class TagVM
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }
    }
}
