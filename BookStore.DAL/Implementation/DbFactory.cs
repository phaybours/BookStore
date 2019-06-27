using BookStore.DAL.Context;
using BookStore.DAL.Interface;

namespace BookStore.DAL.Implementation
{
    public class DbFactory : Disposable, IDbFactory
    {
        BookStoreContext dbContext;

        public BookStoreContext Init()
        {
            return dbContext ?? (dbContext = new BookStoreContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
