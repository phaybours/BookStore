using System;
using System.Collections.Generic;
using BookStore.DAL.Interface;
using BookStore.DAL.Implementation;

namespace BookStore.DAL.Repository
{
    public class UserrolesRepository : Repository<userroles>, IUserrolesRepository
    {
        public UserrolesRepository(IDbFactory dbFactory) : base(dbFactory) { }

    }

    public interface IUserrolesRepository : IRepository<userroles> { }
}
