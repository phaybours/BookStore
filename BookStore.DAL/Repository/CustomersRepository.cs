using BookStore.DAL.Interface;
using BookStore.DAL.Implementation;

namespace BookStore.DAL.Repository
{
    public class CustomersRepository : Repository<Customers>, ICustomersRepository
    {
        public CustomersRepository(IDbFactory dbFactory) : base(dbFactory) { }

    }

    public interface ICustomersRepository : IRepository<Customers> { }
}
