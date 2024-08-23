using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models
{
    public class SponsoredGameJam : GameJam
    {
        [Required]
        public required string Sponsor {  get; set; }
    }
}
