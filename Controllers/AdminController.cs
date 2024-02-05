using System;
using Microsoft.AspNetCore.Mvc;
using proiectdaw.Helpers.Attributes;
using proiectdaw.Models.DTO;
using proiectdaw.Models.Enums;
using proiectdaw.Models.Services.AdminService;
using proiectdaw.Models.Services.UserService;

namespace proiectdaw.Controllers
{
   /* [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        public IActionResult GetAdminData()
        {
            
            return Ok("Admin data");
        }

        [Authorize(Role.Admin)]
        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(AdminRegisterDto adminRegisterDto)
        {
            var response = await _adminService.Register(adminRegisterDto, Models.Enums.Role.Admin);

            if (response == false)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [Authorize(Role.Admin)]
        [HttpGet("check-auth-admin")]
        public IActionResult GetTextAdmin()
        {
            return Ok("Admin is logged in");
        }

        [Authorize(Role.Admin)]
        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            // Retrieve all users (admin-only action)
            var users = _adminService.GetAllUsers();
            return Ok(users);
        }

        [Authorize(Role.Admin)]
        [HttpGet("get-user/{userId}")]
        public IActionResult GetUserDetails(int userId)
        {
            
            var userDetails = _adminService.GetUserDetails(userId);

            if (userDetails == null)
            {
                return NotFound();
            }

            return Ok(userDetails);
        }

    }*/
   


}


