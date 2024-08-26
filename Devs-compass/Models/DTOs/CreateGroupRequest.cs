using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.DTOs
{
    public class CreateGroupRequest
    {
        public required DateTime StartDate { get; set; }
    }
}
