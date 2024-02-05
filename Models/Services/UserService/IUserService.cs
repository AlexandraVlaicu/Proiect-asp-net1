using System;
using proiectdaw.Models.DTO;
using proiectdaw.Models.Enums;

namespace proiectdaw.Models.Services.UserService
{
   public interface IUserService
    {
        Task<UserLoginResponse> Login(UserLoginDto user);
        User GetById(Guid id);

        Task<bool> Register(UserRegisterDto userRegisterDto, Role userRole);
    }
}

