using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UtilityManagementSystem.Models;
namespace UtilityManagementSystem.Controllers
{
    public class VendorInvoiceController : Controller
    {
        // GET: VendorInvoice
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();
        
        
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendorInvoice model, string add, string save, string delete, string ItemName, int? Quantity, decimal? Rate)
        {
            if (!string.IsNullOrEmpty(delete))
            {
                foreach (var chk in GlobalClass.VendorItem)
                {
                    if (chk.ItemName == delete)
                    {
                        GlobalClass.VendorItem.Remove(chk);
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(add))
            {
                if (!string.IsNullOrEmpty(ItemName) && Quantity != null && Rate != null)
                {
                    VendorItemList c = new VendorItemList();
                    c.ItemName = ItemName;
                    c.Quantity = Quantity;
                    c.Rate = Rate;
                    GlobalClass.VendorItem.Add(c);
                }
                else
                {
                    ViewBag.message = "Please enter the Line items correctly";
                }
            }

            if (!string.IsNullOrEmpty(save))
            {
                model.InvoiceKey = Guid.NewGuid();
                ViewBag.message = "";
                model.IsPaid = false;
                db.VendorInvoice.Add(model);
                db.SaveChanges();
                if (GlobalClass.VendorItem.Count() > 0)
                {

                    foreach (var item in GlobalClass.VendorItem)
                    {
                        UtilityManagementDBEntities bc = new UtilityManagementDBEntities();
                        VndorInvoiceDetail obj = new VndorInvoiceDetail();
                        obj.InvoiceKey = model.InvoiceKey;
                        obj.ItemName = item.ItemName;
                        obj.Rate = item.Rate;
                        obj.Quantity = item.Quantity;
                        bc.VndorInvoiceDetail.Add(obj);
                        bc.SaveChanges();
                        bc.Dispose();
                    }
                }
                GlobalClass.VendorItem = new List<VendorItemList>();
                return RedirectToAction("InvoiceList", new { id = model.JobKey });
            }


            return View(model);

        }

        public ActionResult Edit(Guid id)
        {
            VendorInvoice model = db.VendorInvoice.Find(id);
            ViewBag.message = "";
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VendorInvoice model, string add, string save, int? delete, string ItemName, int? Quantity, decimal? Rate)
        {
            if (delete != null)
            {
                UtilityManagementDBEntities bc = new UtilityManagementDBEntities();
                VndorInvoiceDetail det = bc.VndorInvoiceDetail.Find(delete);
                bc.VndorInvoiceDetail.Remove(det);
                bc.SaveChanges();
                bc.Dispose();
            }

            if (!string.IsNullOrEmpty(add))
            {
                if (!string.IsNullOrEmpty(ItemName) && Quantity != null && Rate != null)
                {
                    UtilityManagementDBEntities bc = new UtilityManagementDBEntities();
                    VndorInvoiceDetail obj = new VndorInvoiceDetail();
                    obj.InvoiceKey = model.InvoiceKey;
                    obj.ItemName = ItemName;
                    obj.Rate = Rate;
                    obj.Quantity = Quantity;
                    bc.VndorInvoiceDetail.Add(obj);
                    bc.SaveChanges();
                    bc.Dispose();
                }
                else
                {
                    ViewBag.message = "Please enter the Line items correctly";
                }
            }

            if (!string.IsNullOrEmpty(save))
            {

                ViewBag.message = "";
                VendorInvoice inv = db.VendorInvoice.Find(model.InvoiceKey);
                inv.InvoiceId = model.InvoiceId;
                inv.InvoiceDate = model.InvoiceDate;
                inv.WorkPerformed = model.WorkPerformed;
                db.SaveChanges();

                return RedirectToAction("InvoiceList", new { id = model.JobKey });
            }


            return View(model);

        }
        public ActionResult Remove(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VendorInvoice inv = db.VendorInvoice.Find(id);
            int? JobKey = inv.JobKey;
            if (inv == null)
            {
                return HttpNotFound();
            }
            var temp = from x in db.VndorInvoiceDetail where x.InvoiceKey == inv.InvoiceKey select x;
            if (temp.Count() > 0)
            {
                db.VndorInvoiceDetail.RemoveRange(temp);
            }
            db.VendorInvoice.Remove(inv);
            db.SaveChanges();
            return RedirectToAction("InvoiceList", new { id = JobKey });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
   }