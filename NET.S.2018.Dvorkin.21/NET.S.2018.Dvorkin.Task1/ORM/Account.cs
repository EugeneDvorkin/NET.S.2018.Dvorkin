//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public int Number { get; set; }
        public decimal Balance { get; set; }
        public int Points { get; set; }
        public bool Valid { get; set; }
        public int TypeId { get; set; }
        public int PersonId { get; set; }
        public int Id { get; set; }
    
        public virtual AccountType AccountType { get; set; }
        public virtual Person Person { get; set; }
    }
}
