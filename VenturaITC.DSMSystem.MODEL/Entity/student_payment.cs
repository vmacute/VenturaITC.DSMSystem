//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VenturaITC.DSMSystem.MODEL.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class student_payment
    {
        public int receipt_number { get; set; }
        public int student_number { get; set; }
        public Nullable<int> installment_number { get; set; }
        public decimal amount { get; set; }
        public decimal total_paid_amount { get; set; }
        public decimal remaining_amount { get; set; }
        public string username { get; set; }
        public System.DateTime date { get; set; }
    
        public virtual student student { get; set; }
        public virtual user user { get; set; }
    }
}
