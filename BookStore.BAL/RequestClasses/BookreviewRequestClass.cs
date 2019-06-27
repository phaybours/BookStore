using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL;
namespace BookStore.BAL.RequestClasses
{
    public class BookreviewRequestClass
    {
        public int id { get; set; }
        public int bookid { get; set; }
        public int userid { get; set; }
        public string userreview { get; set; }
        public DateTime reviewdate { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public IEnumerable<Bookreview> BookreviewList { get; set; }
        public string reviewedby { get; set; }
    }
}
