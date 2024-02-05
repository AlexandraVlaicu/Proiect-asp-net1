using System;
using System.ComponentModel.DataAnnotations;

namespace proiectdaw.Models.DTO
{
    public class UserLoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

