using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models
{
    public class Developer: User
    {
        public required List<Group> groups { get; set; }
    }
}
