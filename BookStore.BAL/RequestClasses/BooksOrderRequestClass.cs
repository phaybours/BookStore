using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL;
namespace BookStore.BAL.RequestClasses
{
    public class BooksOrderRequestClass
    {
        public int id { get; set; }
        public int customerid { get; set; }
        public int orderid { get; set; }
        public int bookid { get; set; }
        public int quantity { get; set; }
        public DateTime orderdate { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public IEnumerable<BooksOrder> BookOrderList { get; set; }
    }
}
