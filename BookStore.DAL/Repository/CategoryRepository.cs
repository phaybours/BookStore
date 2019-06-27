using System;
using System.Collections.Generic;
using BookStore.DAL.Interface;
using BookStore.DAL.Implementation;

namespace BookStore.DAL.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory) { }

    }

    public interface ICategoryRepository : IRepository<Category> { }
}
