using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityManagementSystem.Models;
namespace UtilityManagementSystem.Controllers
{
    
    public class HomeController : Controller
    {
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();
        public ActionResult Index()
        {
            return View();


        }

        public ActionResult Signup()
        {
            ViewBag.mess = "";
            return View();

        }
        [HttpPost]
        public ActionResult Signup(Vendor vendor, int vtype)
        {
            ViewBag.mess = "";
            if (ModelState.IsValid)
            {
                if (vtype == 1)
                {
                    vendor.IsEnabled = true;
                    db.Vendor.Add(vendor);
                    db.SaveChanges();
                    ViewBag.mess = "Vendor has been Registered";
                    vendor = new Vendor();
                }
                if (vtype == 2)
                {
                    Customer obj = new Customer();
                    obj.name = vendor.name;
                    obj.Mobile = Convert.ToInt32(vendor.Mobile);
                    obj.Email = vendor.Email;
                    obj.Address = vendor.Address;
                    obj.companyName = vendor.companyName;
                    obj.IsEnabled = true;
                    db.Customer.Add(obj);
                    db.SaveChanges();
                    ViewBag.mess = "Customer has been Registered";
                    vendor = new Vendor();
                }
            }

            return View(vendor);

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();

        }
    }
}