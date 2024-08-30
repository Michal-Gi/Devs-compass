using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.DTOs
{
    public class GameJamParticipationVM
    {
        public int Id { get; set; }

        public required int GameJamId { get; set; }
        public required int GroupId { get; set; }
    }
}
