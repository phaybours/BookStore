using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL;
namespace BookStore.BAL.RequestClasses
{
    public class BooksRequestClass
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int category { get; set; }
        public int author { get; set; }
        public string publisher { get; set; }
        public string isbn { get; set; }
        public DateTime datepublished { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public DateTime datecreated { get; set; }
        public int userid { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public IEnumerable<Books> BooksList { get; set; }
    }
}
