using System;
using Microsoft.EntityFrameworkCore;
using proiectdaw.Data;
using proiectdaw.Helpers.Extensions;
using proiectdaw.Models.Repositories.GenericRepository;

namespace proiectdaw.Models.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext _context) : base(_context)
        {
        }

        public async Task<List<User>> FindAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<List<User>> FindAllActive()
        {
            return await _table.GetActiveUser().ToListAsync();
        }

        public async Task<User> FindByUsername(string username)
        {
            return (await _table.FirstOrDefaultAsync(u => u.Username.Equals(username)))!;
        }

       
    }
}



