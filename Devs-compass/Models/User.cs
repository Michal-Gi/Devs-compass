using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models
{
    public abstract class User
    {
        [Required, Key]
        public int Id { get; set; }

        [Required, MinLength(5)]
        public required string Login { get; set; }

        [Required, MinLength(8)]
        public required string Password { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        public List<Opinion> Opinions { get; set; }
    }
}
