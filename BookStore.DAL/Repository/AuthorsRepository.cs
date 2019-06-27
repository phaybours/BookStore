using BookStore.DAL.Interface;
using BookStore.DAL.Implementation;

namespace BookStore.DAL.Repository
{

    public class AuthorsRepository : Repository<Authors>, IAuthorsRepository
    {
        public AuthorsRepository(IDbFactory dbFactory) : base(dbFactory) { }

    }

    public interface IAuthorsRepository : IRepository<Authors> { }
}
