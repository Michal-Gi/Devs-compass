using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models
{
    public class OwnGameJam : GameJam
    {
        [Required]
        public required float Price { get; set; }
    }
}
