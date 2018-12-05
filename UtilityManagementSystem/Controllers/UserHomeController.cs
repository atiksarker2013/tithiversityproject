using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityManagementSystem.Models;

namespace UtilityManagementSystem.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();


        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            ViewBag.mess = "";
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            try
            {
               // int mobilePassword = 0;
                //mobilePassword = Convert.ToInt32(password);
                StaffList obj = db.StaffList.SingleOrDefault(m => m.Username == username && m.Password == password && m.IsDelete == false && m.IsUser == true);
                if (obj == null)
                {
                    ViewBag.mess = "Incorrect Username/  Password.";
                }
                else
                {
                    GlobalClass.LoginUser = obj;
                    return RedirectToAction("Index", "Jobs");
                }
               
                    Customer customerObj = db.Customer.SingleOrDefault(m => m.Email == username && m.Mobile == password);

                    if (customerObj ==null)
                    {
                    ViewBag.mess = "Incorrect Username/  Password.";
                }
                else
                {
                    GlobalClass.LoginCustomerUser = customerObj;
                    GlobalClass.SystemSession = true;
                    return RedirectToAction("CustomerJobRequest", "CustomerJobRequests");

                }
                Vendor vendorObj = db.Vendor.SingleOrDefault(m => m.Email == username && m.Mobile == password);
                        if (vendorObj ==null)
                        {
                    ViewBag.mess = "Incorrect Username/  Password.";

                }
                        else
                        {
                            GlobalClass.LoginVendorUser = vendorObj;
                            GlobalClass.SystemSession = true;
                            return RedirectToAction("VIndex", "Jobs");

                        }
                   
                

              return View();

            }
            catch (DivideByZeroException e)
            {
                return View("Error", new HandleErrorInfo(e, "UserHome", "Login"));
            }
        }
        public ActionResult AdminLogin()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(string username, string password)
        {
            try
            {
                if (username == System.Configuration.ConfigurationManager.AppSettings["superAdd"] && password == System.Configuration.ConfigurationManager.AppSettings["sp"])
                {
                    GlobalClass.MasterSession = true;
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (DivideByZeroException e)
            {
                return View("Error", new HandleErrorInfo(e, "Home", "Index"));
            }

            return View();
        }


        
       
        public ActionResult Index()
        {
            if (GlobalClass.SystemSession)
            {
                return View();
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }

        }
    }
}