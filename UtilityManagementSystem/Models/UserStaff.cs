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
    
    public partial class UserStaff
    {
        public int ID { get; set; }
        public string name { get; set; }
        public Nullable<int> Mobile { get; set; }
        public string Mail { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public byte[] Pic { get; set; }
        public string pictype { get; set; }
        public string usergroup { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<bool> isEnable { get; set; }
    }
}
