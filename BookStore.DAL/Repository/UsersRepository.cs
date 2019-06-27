using BookStore.DAL.Interface;
using BookStore.DAL.Implementation;

namespace BookStore.DAL.Repository
{
    public class UsersRepository : Repository<users>, IUsersRepository
    {
        public UsersRepository(IDbFactory dbFactory) : base(dbFactory) { }

    }

    public interface IUsersRepository : IRepository<users> { }
}
