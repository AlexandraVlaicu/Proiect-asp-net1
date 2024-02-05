using System;
using Microsoft.EntityFrameworkCore;
using proiectdaw.Data;
using proiectdaw.Helpers.JwtUtil;
using proiectdaw.Models.DTO;
using proiectdaw.Models.Enums;
using proiectdaw.Models.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;
namespace proiectdaw.Models.Services.AdminService
{
   public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IJwtUtils _jwtUtils;

        public AdminService(IAdminRepository adminRepository, IJwtUtils jwtUtils)
        {
            _adminRepository = adminRepository;
            _jwtUtils = jwtUtils;
        }

        public Admin GetById(Guid id)
        {
            return _adminRepository.FindById(id);
        }

        public async Task<AdminLoginResponse> Login(AdminLoginDto adminDto)
        {
            var admin = await _adminRepository.FindByUsername(adminDto.AdminName);

            if (admin == null || !BCryptNet.Verify(adminDto.Password, admin.Password))
            {
                return null; 
            }

            var token = _jwtUtils.GenerateJwtToken(admin);
            return new AdminLoginResponse(admin, token);
        }

        public async Task<List<Admin>> GetAllUsers()
        {
            return await _adminRepository.GetAllUsers();
        }
        public async Task<Admin> GetUserDetails(Guid userId)
        {
            return await _adminRepository.GetUserDetails(userId);
        }
        public async Task<bool> Register(AdminRegisterDto adminRegisterDto, Role adminRole)
        {
            var adminToCreate = new Admin
            {
                Adminname = adminRegisterDto.UserName,
                FirstName = adminRegisterDto.FirstName,
                LastName = adminRegisterDto.LastName,
                Email = adminRegisterDto.Email,
                Role = adminRole,
                Password = BCryptNet.HashPassword(adminRegisterDto.Password)
            };

            _adminRepository.Create(adminToCreate);
            return await _adminRepository.SaveAsync();
        }

       Admin IAdminService.GetAllUsers()
        {
           throw new NotImplementedException();
        }

        Admin IAdminService.GetUserDetails(int userId)
        {
            throw new NotImplementedException();
        }
    }

}

