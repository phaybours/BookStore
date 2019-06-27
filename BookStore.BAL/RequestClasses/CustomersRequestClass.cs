using System;
using BookStore.DAL;
using System.Collections.Generic;

namespace BookStore.BAL.RequestClasses
{
    public class CustomersRequestClass
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string firstname { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public DateTime dateregistered { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public IEnumerable<Customers> CustomersList { get; set; }
    }
}
