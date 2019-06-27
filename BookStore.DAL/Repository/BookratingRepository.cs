using System;
using System.Collections.Generic;
using BookStore.DAL.Interface;
using BookStore.DAL.Implementation;

namespace BookStore.DAL.Repository
{
    public class BookratingRepository : Repository<Bookrating>, IBookratingRepository
    {
        public BookratingRepository(IDbFactory dbFactory) : base(dbFactory) { }

    }

    public interface IBookratingRepository : IRepository<Bookrating> { }
}
