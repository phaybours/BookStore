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
    
    public partial class Authors
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string othernames { get; set; }
        public string nationality { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> datecreated { get; set; }
        public Nullable<int> userid { get; set; }
    }
}
