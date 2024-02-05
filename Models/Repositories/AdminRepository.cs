using System;
using Microsoft.EntityFrameworkCore;
using proiectdaw.Data;
using proiectdaw.Helpers.Extensions;
using proiectdaw.Models.Repositories.GenericRepository;

namespace proiectdaw.Models.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Admin>> FindAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<List<Admin>> FindAllActive()
        {
            return await _table.GetActiveAdmin().ToListAsync();
        }

        public async Task<Admin> FindByUsername(string username)
        {
            return await _table.FirstOrDefaultAsync(a => a.Adminname.Equals(username));
        }
        public async Task<List<Admin>> GetAllUsers()
        {
            return await _table.ToListAsync();

        }
        public async Task<Admin> GetUserDetails(Guid userId)
        {
            return await _table.FirstOrDefaultAsync(a => a.Id == userId);
        }

    }
    }

