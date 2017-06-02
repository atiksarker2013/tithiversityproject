using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilityManagementSystem.Models
{
    public class FormValidation
    {
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();
        public CompanyClass FillCompanyInfo(Company model)
        {
            UtilityManagementDBEntities bc = new UtilityManagementDBEntities();
            CompanyClass obj = new CompanyClass();
            obj.CompanyKey = model.CompanyKey;
            obj.CompanyID = model.CompanyID;
            obj.CompanyName = model.CompanyName;
            obj.CompanyAddress = model.CompanyAddress;
            obj.CompanyPhone = model.CompanyPhone;
            obj.CompanyMobile = model.CompanyMobile;
            obj.CompanyEmail = model.CompanyEmail;
            obj.CompanyWebsite = model.CompanyWebsite;
            obj.CompanyFax = model.CompanyFax;
            obj.ContactPersonName = model.ContactPersonName;
            obj.ContactPersonNo = model.ContactPersonNo;
            obj.Logo = model.Logo;
            obj.LogoType = model.LogoType;
            obj.IsDelete = model.IsDelete;
            obj.StateCode = model.StateCode;
            obj.CityKey = model.CityKey;
            obj.ZIPKey = model.ZIPKey;
            obj.Title = model.Title;
            obj.ContactEmail = model.ContactEmail;

            return obj;
        }
        public CompanyClass ValidateCompanyClass(CompanyClass model)
        {
            if (String.IsNullOrEmpty(model.CompanyID))
                model.CompanyID = model.CompanyName;
            if (String.IsNullOrEmpty(model.CompanyFax))
                model.CompanyFax = "n/a";
            if (String.IsNullOrEmpty(model.CompanyAddress))
                model.CompanyAddress = "n/a";
            if (String.IsNullOrEmpty(model.CompanyPhone))
                model.CompanyPhone = "n/a";
            if (String.IsNullOrEmpty(model.CompanyMobile))
                model.CompanyMobile = "n/a";
            if (String.IsNullOrEmpty(model.CompanyEmail))
                model.CompanyEmail = "n/a";
            if (String.IsNullOrEmpty(model.Title))
                model.Title = "n/a";
            if (String.IsNullOrEmpty(model.ContactEmail))
                model.ContactEmail = "n/a";
            if (String.IsNullOrEmpty(model.CompanyWebsite))
                model.CompanyWebsite = "n/a";
            if (String.IsNullOrEmpty(model.ContactPersonName))
                model.ContactPersonName = "n/a";
            if (String.IsNullOrEmpty(model.ContactPersonNo))
                model.ContactPersonNo = "n/a";
            return model;
        }
        public Company ValidateCompany(Company model)
        {
            if (String.IsNullOrEmpty(model.CompanyID))
                model.CompanyID = model.CompanyName;
            if (String.IsNullOrEmpty(model.CompanyFax))
                model.CompanyFax = "n/a";
            if (String.IsNullOrEmpty(model.CompanyAddress))
                model.CompanyAddress = "n/a";
            if (String.IsNullOrEmpty(model.CompanyPhone))
                model.CompanyPhone = "n/a";
            if (String.IsNullOrEmpty(model.CompanyMobile))
                model.CompanyMobile = "n/a";
            if (String.IsNullOrEmpty(model.CompanyEmail))
                model.CompanyEmail = "n/a";
            if (String.IsNullOrEmpty(model.Title))
                model.Title = "n/a";
            if (String.IsNullOrEmpty(model.ContactEmail))
                model.ContactEmail = "n/a";
            if (String.IsNullOrEmpty(model.CompanyWebsite))
                model.CompanyWebsite = "n/a";
            if (String.IsNullOrEmpty(model.ContactPersonName))
                model.ContactPersonName = "n/a";
            if (String.IsNullOrEmpty(model.ContactPersonNo))
                model.ContactPersonNo = "n/a";
            return model;
        }

        public StaffClass FillStaffInfo(StaffList model)
        {
            StaffClass obj = new StaffClass();
            obj.PersonnelKey = model.PersonnelKey;
            obj.PID = model.PID;
            obj.PName = model.PName;
            obj.Mobile = model.Mobile;
            obj.Mail = model.Mail;
            obj.Pic = model.Pic;
            obj.Designation = model.Designation;
            obj.Department = model.Department;
            obj.PicType = model.PicType;
            obj.Usergr = model.Usergr;
            obj.Username = model.Username;
            obj.Password = model.Password;

            return obj;
        }

        public StaffClass ValidateStaff(StaffClass model, bool ICreate)
        {
            if (ICreate == true)
            {
                if (String.IsNullOrEmpty(model.PID))
                    model.PID = UniqueIDCreator.CreateID();

                if (String.IsNullOrEmpty(model.Mail))
                    model.Mail = "n/a";
                if (String.IsNullOrEmpty(model.Mobile))
                    model.Mobile = "n/a";
                if (String.IsNullOrEmpty(model.Department))
                    model.Department = "none";

                if (String.IsNullOrEmpty(model.Designation))
                    model.Designation = "none";
            }
            else
            {
                if (String.IsNullOrEmpty(model.PID))
                    model.PID = UniqueIDCreator.CreateID();

                if (String.IsNullOrEmpty(model.Mail))
                    model.Mail = "n/a";
                if (String.IsNullOrEmpty(model.Mail))
                    model.Mail = "n/a";
                if (String.IsNullOrEmpty(model.Mobile))
                    model.Mobile = "n/a";
                if (String.IsNullOrEmpty(model.Department))
                    model.Department = "none";

                if (String.IsNullOrEmpty(model.Designation))
                    model.Designation = "none";

            }
            return model;
        }
    }
}