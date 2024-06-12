﻿using System.ComponentModel.DataAnnotations;

namespace Devs_compass.Models.DTOs
{
    public class UserVM
    {
        [Required, Key]
        public required int Id { get; set; }

        [Required, MinLength(5)]
        public required string Login { get; set; }

        [Required, MinLength(8)]
        public required string Password { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }
    }
}