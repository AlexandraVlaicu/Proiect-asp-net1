using proiectdaw.Models;

namespace proiectdaw.Helpers.JwtUtil
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        string GenerateJwtToken(Admin admin);
        public Guid? GetUserId(string? token);
        public Guid? GetAdminId(string? token);
    }
}
