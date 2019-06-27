using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL;
namespace BookStore.BAL.RequestClasses
{
    public class BookratingRequestClass
    {
        public int id { get; set; }
        public int bookid { get; set; }
        public int rating { get; set; }
        public DateTime daterated { get; set; }
        public int userid { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public IEnumerable<Bookrating> BookratingList { get; set; }
    }
}
