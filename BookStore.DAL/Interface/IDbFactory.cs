using BookStore.DAL.Context;

namespace BookStore.DAL.Interface
{
    public interface IDbFactory
    {
        BookStoreContext Init();
    }
}
