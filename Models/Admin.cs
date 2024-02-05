using System;
using System.Text.Json.Serialization;
using proiectdaw.Models.Enums;

namespace proiectdaw.Models
{
    public class Admin : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Adminname { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public Role Role { get; set; }
    }
}

