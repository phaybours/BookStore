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
    
    public partial class Books
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Nullable<int> category { get; set; }
        public Nullable<int> author { get; set; }
        public string publisher { get; set; }
        public string isbn { get; set; }
        public Nullable<System.DateTime> datepublished { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<System.DateTime> datecreated { get; set; }
        public Nullable<int> userid { get; set; }
    }
}