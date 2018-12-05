using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityManagementSystem.Models;
namespace UtilityManagementSystem.Controllers
{
    public class AdminInvoiceController : Controller
    {
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();
        // GET: AdminInvoice
        public ActionResult Index()
        {
            return View();
        }
        //Vendor Invoice List
        public ActionResult VendorInvoiceList()
        {
           
            var VendorJobRequest = db.VendorInvoice.OrderByDescending(m => m.InvoiceDate);
            return View(VendorJobRequest.ToList());

        }
        public ActionResult Details(Guid id)
        {
            VendorInvoice model = db.VendorInvoice.Find(id);

            return View(model);

        }

        //customer invoice to admin
        public ActionResult CustomerInvoiceList()
        {

            var CustomerJobRequest = db.CustomerInvoice.OrderByDescending(m => m.InvoiceDate);
            return View(CustomerJobRequest.ToList());

        }
        public ActionResult CustomerDetails(Guid id)
        {
            CustomerInvoice model = db.CustomerInvoice.Find(id);

            return View(model);

        }
    }
}