using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models
{
    public class SponsoredGameJam : GameJam
    {
        [Required]
        public string Sponsor {  get; set; }
    }
}
