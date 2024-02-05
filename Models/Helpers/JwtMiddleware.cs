using proiectdaw.Helpers.JwtUtil;
using proiectdaw.Models.Services.AdminService;
using proiectdaw.Models.Services.UserService;
using proiectdaw.Services.UserService;

namespace proiectdaw.Helpers
{
    public class JwtMiddleware
    {
         private readonly RequestDelegate _next;

         public JwtMiddleware(RequestDelegate next)
         {
             _next = next;
         }

         public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtil)
         {
             // "Bearer sdsfkdkgkfgkflkgflgklfg"
             var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
             var userId = jwtUtil.GetUserId(token);
             if (userId != null)
             {
                 context.Items["User"] = userService.GetById(userId.Value);
             }

             await _next(context);
         }
         public async Task Invoke(HttpContext context, IAdminService adminService, IJwtUtils jwtUtil)
         {
             // "Bearer sdsfkdkgkfgkflkgflgklfg"
             var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
             var adminId = jwtUtil.GetAdminId(token);
             if (adminId != null)
             {
                 context.Items["User"] = adminService.GetById(adminId.Value);
             }

             await _next(context);
         }
     }
    }

