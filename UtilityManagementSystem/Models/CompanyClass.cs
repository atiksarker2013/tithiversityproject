using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UtilityManagementSystem.Models
{
    public class CompanyClass
    {
        public System.Guid CompanyKey { get; set; }

        [Display(Name = "ID")]
        public string CompanyID { get; set; }

        [Display(Name = "Company Name*")]
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Display(Name = "Address")]
        public string CompanyAddress { get; set; }
        [Display(Name = "Telephone")]
        [Required(ErrorMessage = "Telephone Number is required")]
        public string CompanyPhone { get; set; }
        [Display(Name = "Alternate Contact #")]
        public string CompanyMobile { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string CompanyEmail { get; set; }
        [Display(Name = "Website")]
        public string CompanyWebsite { get; set; }
        [Display(Name = "Fax")]
        public string CompanyFax { get; set; }
        [Display(Name = "Represented By")]
        public string ContactPersonName { get; set; }
        [Display(Name = "Telephone")]
        public string ContactPersonNo { get; set; }
        public byte[] Logo { get; set; }
        public string LogoType { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        [Required(ErrorMessage = "The State name is required")]
        public Nullable<int> StateCode { get; set; }
        [Required(ErrorMessage = "The City Name is required")]
        public Nullable<int> CityKey { get; set; }
        [Required(ErrorMessage = "The Zipcode is required")]
        public Nullable<long> ZIPKey { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string ContactEmail { get; set; }
    }
}