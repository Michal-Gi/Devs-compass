using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models
{
    public abstract class User
    {
        [Required, Key]
        public int Id { get; set; }

        [Required, MinLength(5)]
        public string Login { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public List<Opinion> Opinions { get; set; }
    }
}
