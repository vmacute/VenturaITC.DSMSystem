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
    
    public partial class student_documentation
    {
        public int id { get; set; }
        public int student_number { get; set; }
        public string document_type { get; set; }
        public byte[] document_content { get; set; }
    
        public virtual document_type document_type1 { get; set; }
        public virtual student student { get; set; }
    }
}
