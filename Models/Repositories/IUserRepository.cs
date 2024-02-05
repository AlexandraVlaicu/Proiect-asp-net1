using System;
using proiectdaw.Models.Repositories.GenericRepository;

namespace proiectdaw.Models.Repositories
{
   public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindByUsername(string username);
       


        Task<List<User>> FindAll();

        Task<List<User>> FindAllActive();

    }
}

