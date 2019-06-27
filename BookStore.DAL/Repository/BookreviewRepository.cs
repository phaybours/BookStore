using BookStore.DAL.Implementation;
using BookStore.DAL.Interface;

namespace BookStore.DAL.Repository
{
    public class BookreviewRepository : Repository<Bookreview>, IBookreviewRepository
    {
        public BookreviewRepository(IDbFactory dbFactory) : base(dbFactory) { }

    }

    public interface IBookreviewRepository : IRepository<Bookreview> { }
}
