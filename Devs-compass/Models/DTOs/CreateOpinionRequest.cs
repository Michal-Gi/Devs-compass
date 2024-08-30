using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.DTOs
{
    public class CreateOpinionRequest
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required float Score { get; set; }

        public required int UserId { get; set; }

        public required int SoftwareId { get; set; }
    }
}
