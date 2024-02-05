using proiectdaw.Models;

namespace proiectdaw.Helpers.Extensions
{
    public static class OnlyActive
    {
        public static IQueryable<User> GetActiveUser(this IQueryable<User> query)
        {
            return query.Where(x => !x.IsDeleted);
        }
        public static IQueryable<Admin> GetActiveAdmin(this IQueryable<Admin> query)
        {
            return query.Where(x => !x.IsDeleted);
        }
    }
}
