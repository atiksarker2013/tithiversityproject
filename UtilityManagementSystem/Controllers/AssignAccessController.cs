using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityManagementSystem.Models;

namespace UtilityManagementSystem.Controllers
{
    public class AssignAccessController : Controller
    {
        // GET: AssignAccess
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();
        private FormValidation Val = new FormValidation();
        public ActionResult Index()
        {
            if (GlobalClass.SystemSession)
            {
                var staffList = db.StaffList.Where(m => m.CompanyKey == GlobalClass.Company.CompanyKey).OrderBy(m => m.PName);
                return View(staffList.ToList());
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }

        }
        public ActionResult DIndex()
        {
            if (GlobalClass.SystemSession)
            {
                var staffList = db.StaffList.Where(m => m.CompanyKey == GlobalClass.Company.CompanyKey && m.IsUser == true).OrderBy(m => m.PName);
                return View(staffList.ToList());
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }

        }
        public ActionResult Access(Guid? id)
        {
            if (GlobalClass.SystemSession)
            {
                StaffClass staffList = Val.FillStaffInfo(db.StaffList.Find(id));

                return View(staffList);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
        [HttpPost]
        public ActionResult Access(StaffClass model, string Save)
        {
            if (GlobalClass.SystemSession)
            {
                if (!string.IsNullOrEmpty(Save))
                {
                    StaffList staffList = db.StaffList.Find(model.PersonnelKey);
                    staffList.IsUser = true;

                    staffList.Password = model.Password;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        public ActionResult ChangePass()
        {
            if (GlobalClass.SystemSession)
            {
                StaffClass staffList = Val.FillStaffInfo(db.StaffList.Find(GlobalClass.LoginUser.PersonnelKey));

                return View(staffList);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
        [HttpPost]
        public ActionResult ChangePass(StaffClass model, string Save)
        {
            if (GlobalClass.SystemSession)
            {
                if (!string.IsNullOrEmpty(Save))
                {
                    StaffList staffList = db.StaffList.Find(model.PersonnelKey);
                    staffList.IsUser = true;

                    staffList.Password = model.Password;
                    db.SaveChanges();
                    return RedirectToAction("Index", "UserHome");
                }
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        public ActionResult Delete(Guid? id)
        {
            if (GlobalClass.SystemSession)
            {
                StaffList staffList = db.StaffList.Find(id);
                staffList.IsUser = false;
                staffList.Password = "0";
                staffList.Username = "0";
                db.SaveChanges();
                return RedirectToAction("DIndex");
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
    }
}