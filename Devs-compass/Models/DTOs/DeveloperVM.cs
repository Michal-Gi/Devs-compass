using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.DTOs
{
    public class DeveloperVM
    {
        public required int Id { get; set; }

        public required string Login { get; set; }

        public required string Password { get; set; }

        public required string Email { get; set; }
    }
}
