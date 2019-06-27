using BookStore.DAL.Implementation;
using BookStore.DAL.Interface;

namespace BookStore.DAL.Repository
{
    public class BooksOrderRepository : Repository<BooksOrder>, IBooksOrderRepository
    {
        public BooksOrderRepository(IDbFactory dbFactory) : base(dbFactory) { }

    }

    public interface IBooksOrderRepository : IRepository<BooksOrder> { }
}
