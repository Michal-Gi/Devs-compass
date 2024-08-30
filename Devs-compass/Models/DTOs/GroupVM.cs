using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.DTOs
{
    public class GroupVM
    {
        public required int Id { get; set; }

        public required DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public required List<DeveloperVM> Developers { get; set; }

        public List<SoftwareVM> Softwares { get; set; }

        public List<GameJamParticipationVM> GameJamParticipations { get; set; }
    }
}
