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
    
    public partial class StaffList
    {
        public System.Guid PersonnelKey { get; set; }
        public string PID { get; set; }
        public string PName { get; set; }
        public string Mobile { get; set; }
        public string Mail { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public byte[] Pic { get; set; }
        public string PicType { get; set; }
        public Nullable<System.Guid> CompanyKey { get; set; }
        public Nullable<System.Guid> Usergr { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsUser { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
