using System;
using BookStore.DAL;
using System.Collections.Generic;

namespace BookStore.BAL.RequestClasses
{
    public class CategoryRequestClass
    {
        public int id { get; set; }
        public string categoryname { get; set; }
        public string description { get; set; }
        public DateTime datecreated { get; set; }
        public int userid { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
    }
}
