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
    
    public partial class student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public student()
        {
            this.student_documentation = new HashSet<student_documentation>();
            this.student_payment = new HashSet<student_payment>();
            this.student_enrollment = new HashSet<student_enrollment>();
        }
    
        public int number { get; set; }
        public string type { get; set; }
        public string type_description { get; set; }
        public string full_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public System.DateTime birth_date { get; set; }
        public string marital_status { get; set; }
        public string marital_status_description { get; set; }
        public string gender { get; set; }
        public string gender_description { get; set; }
        public string place_of_birth { get; set; }
        public string province_of_birth { get; set; }
        public string fathers_name { get; set; }
        public string mothers_name { get; set; }
        public string address { get; set; }
        public string ID_number { get; set; }
        public string ID_issuance_place { get; set; }
        public System.DateTime ID_issuance_date { get; set; }
        public System.DateTime ID_expiry_date { get; set; }
        public string academic_level { get; set; }
        public string job_title { get; set; }
        public string phone_number { get; set; }
        public string cell_phone1 { get; set; }
        public string cell_phone2 { get; set; }
        public string email { get; set; }
        public string status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<student_documentation> student_documentation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<student_payment> student_payment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<student_enrollment> student_enrollment { get; set; }
    }
}