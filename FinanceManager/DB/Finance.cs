//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinanceManager.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Finance
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Recurring { get; set; }
        public System.DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
