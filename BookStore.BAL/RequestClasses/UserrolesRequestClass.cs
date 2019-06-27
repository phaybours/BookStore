using BookStore.DAL;
using System.Collections.Generic;

namespace BookStore.BAL.RequestClasses
{
    public class UserrolesRequestClass
    {
        public int id { get; set; }
        public string rolename { get; set; }
        public string description { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public IEnumerable<userroles> UserrolesList { get; set; }
    }
}
