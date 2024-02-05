using System;
namespace proiectdaw.Models.DTO
{
   public class AdminLoginResponse
    {
        public Guid Id { get; set; }
        public string AdminName { get; set; }
        public string Token { get; set; }


        public AdminLoginResponse(Admin admin, string token)
        {
            Id = admin.Id;
            AdminName = admin.Adminname;
            Token = token;
        }
    }
}

