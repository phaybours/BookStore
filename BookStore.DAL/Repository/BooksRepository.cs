using BookStore.DAL.Interface;
using BookStore.DAL.Implementation;

namespace BookStore.DAL.Repository
{
    public class BooksRepository : Repository<Books>, IBooksRepository
    {
        public BooksRepository(IDbFactory dbFactory) : base(dbFactory) { }

    }

    public interface IBooksRepository : IRepository<Books> { }
}
