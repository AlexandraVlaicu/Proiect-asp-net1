using System;
using System.ComponentModel.DataAnnotations;

namespace proiectdaw.Models.DTO
{
    public class AdminLoginDto
    {
        [Required]
        public string AdminName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

