using System;
using proiectdaw.Models.Repositories.GenericRepository;

namespace proiectdaw.Models.Repositories
{
    public interface IAdminRepository: IGenericRepository<Admin>
    {
        Task<List<Admin>> FindAll();
        Task<List<Admin>> FindAllActive();
        Admin FindById(Guid id);
        Task<Admin> FindByUsername(string username);
        Task<bool> SaveAsync();
        Task<List<Admin>> GetAllUsers();
        Task<Admin> GetUserDetails(Guid userId);

    }

}

