using BookStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BAL.RequestClasses
{
    public class AuthorsRequestClass
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string othernames { get; set; }
        public string nationality { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public DateTime datecreated { get; set; }
        public int userid { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public IEnumerable<Authors> AuthorsList { get; set; }
    }
}
