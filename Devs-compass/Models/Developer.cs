using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models
{
    public class Developer: User
    {
        [Required]
        public List<Group> groups { get; set; }
    }
}
