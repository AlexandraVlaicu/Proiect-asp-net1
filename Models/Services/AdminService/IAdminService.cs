using System;
using proiectdaw.Models.DTO;
using proiectdaw.Models.Enums;

namespace proiectdaw.Models.Services.AdminService
{
   public interface IAdminService
    {
        Task<AdminLoginResponse> Login(AdminLoginDto admin);
        Admin GetById(Guid id);

        Task<bool> Register(AdminRegisterDto adminRegisterDto, Role adminRole);
        Admin GetAllUsers();
        Admin GetUserDetails(int userId);
    }

}

