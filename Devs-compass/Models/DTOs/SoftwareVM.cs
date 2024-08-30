using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.DTOs
{
    public class SoftwareVM
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public List<Opinion> Opinions { get; set; }

        public float Score { get; set; }

        public string? UseLicense { get; set; }

        public float? TimeToBeat { get; set; }

        public required int GameJamId { get; set; }

        public required int GroupId { get; set; }
    }
}
