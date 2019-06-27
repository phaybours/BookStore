using BookStore.DAL;
using System.Collections.Generic;

namespace BookStore.BAL.RequestClasses
{
    public class UsersRequestClass
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string firstname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int role { get; set; }
        public int userid { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public IEnumerable<users> UsersList { get; set; }
    }
}
