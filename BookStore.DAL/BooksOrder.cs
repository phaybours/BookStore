//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStore.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class BooksOrder
    {
        public int id { get; set; }
        public Nullable<int> customerid { get; set; }
        public Nullable<int> orderid { get; set; }
        public Nullable<int> bookid { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<System.DateTime> orderdate { get; set; }
    }
}
