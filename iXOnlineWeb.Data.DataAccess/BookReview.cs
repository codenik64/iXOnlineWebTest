//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iXOnlineWeb.Data.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookReview
    {
        public int ReviewId { get; set; }
        public string ReviewDescription { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> BookId { get; set; }
    }
}
