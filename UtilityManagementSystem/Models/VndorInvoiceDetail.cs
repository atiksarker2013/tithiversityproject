//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UtilityManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VndorInvoiceDetail
    {
        public int InvoiceDetailKey { get; set; }
        public Nullable<int> InvoiceKey { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
    }
}
