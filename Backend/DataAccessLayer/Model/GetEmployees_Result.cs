//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Model
{
    using System;
    
    public partial class GetEmployees_Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> DeptId { get; set; }
        public System.DateTime JoiningDate { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
    }
}
