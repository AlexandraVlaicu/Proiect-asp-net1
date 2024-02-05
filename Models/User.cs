using System;
using System.Data;
using System.Text.Json.Serialization;
using proiectdaw.Models.Enums;

namespace proiectdaw.Models
{
	public class User: BaseEntity
	{
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public Role Role { get; set; }
    }
}

