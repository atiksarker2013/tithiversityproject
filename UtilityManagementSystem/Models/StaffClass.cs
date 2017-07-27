using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UtilityManagementSystem.Models
{
    public class StaffClass
    {
        public System.Guid PersonnelKey { get; set; }
        [Display(Name = "ID")]
        public string PID { get; set; }
        [Display(Name = "Full Name*")]
        [Required(ErrorMessage = "Full Name is required")]
        public string PName { get; set; }
        [Display(Name = "Contact No*")]
        [Required(ErrorMessage = "Contact No is required")]
        public string Mobile { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Mail { get; set; }
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        [Display(Name = "Department")]
        public string Department { get; set; }
        public Nullable<System.Guid> DepartmentKey { get; set; }
        public byte[] Pic { get; set; }
        public string PicType { get; set; }
        public Nullable<System.Guid> CompanyKey { get; set; }
        [Required(ErrorMessage = "Usergroup is not selected Correctly")]
        public Nullable<System.Guid> Usergr { get; set; }
        [Display(Name = "Username*")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Display(Name = "Password*")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password*")]
        [Required(ErrorMessage = "Please enter the Password again.")]
        [Compare("Password", ErrorMessage = "Your Confirm Password does not match.")]
        public string ConfirmPassword { get; set; }
        public Nullable<bool> IsUser { get; set; }
       
    }
}