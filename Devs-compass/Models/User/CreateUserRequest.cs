using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.User
{
    public class CreateUserRequest
    {
        [Required, MinLength(5)]
        public string Login { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
