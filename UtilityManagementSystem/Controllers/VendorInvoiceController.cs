using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityManagementSystem.Models;
namespace UtilityManagementSystem.Controllers
{
    public class VendorInvoiceController : Controller
    {
        // GET: VendorInvoice
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JobListForInvoice()
        {
            var VendorJobRequest = db.Job.Where(m => m.VndorId == GlobalClass.LoginVendorUser.Id).OrderByDescending(m => m.EntryDate);
            return View(VendorJobRequest.ToList());

        }
        public ActionResult InvoiceList(int id)
        {
            ViewBag.JoKey = id;
            var VendorJobRequest = db.VendorInvoice.Where(m => m.JobKey == id).OrderByDescending(m => m.InvoiceDate);
            return View(VendorJobRequest.ToList());

        }
        public ActionResult Details(Guid id)
        {
            VendorInvoice model = db.VendorInvoice.Find(id);

            return View(model);

        }
        public ActionResult Create(int id)
        {
            VendorInvoice model = new VendorInvoice();
            model.JobKey = id;
            model.VendorKey = GlobalClass.LoginVendorUser.Id;
            GlobalClass.VendorItem = new List<VendorItemList>();
            ViewBag.message = "";
            return View(model);


        }
    }