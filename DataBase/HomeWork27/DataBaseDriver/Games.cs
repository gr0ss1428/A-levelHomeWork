//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBaseDriver
{
    using System;
    using System.Collections.Generic;
    
    public partial class Games
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearPublishing { get; set; }
        public Nullable<int> GenreId { get; set; }
        public Nullable<int> PublicherId { get; set; }
    
        public virtual Genres Genres { get; set; }
        public virtual Publishers Publishers { get; set; }
    }
}