using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UtilityManagementSystem.Models;


namespace UtilityManagementSystem.Controllers
{
    public class CustomerInvoiceController : Controller
    {
        // GET: CustomerInvoice
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();
        public ActionResult JobListForInvoice()
        {
            var customerJobRequest = db.Job.Where(m => m.CustomerId == GlobalClass.LoginCustomerUser.Id).OrderByDescending(m=>m.EntryDate);
            return View(customerJobRequest.ToList());

        }
     
        public ActionResult InvoiceList(int id)
        {
            ViewBag.JoKey = id;
            var customerJobRequest = db.CustomerInvoice.Where(m => m.JobKey == id).OrderByDescending(m => m.InvoiceDate);
            return View(customerJobRequest.ToList());

        }
      
        public ActionResult Details(Guid id)
        {
            CustomerInvoice model = db.CustomerInvoice.Find(id);
          
            return View(model);

        }
        public ActionResult Create(int id)
        {
            CustomerInvoice model = new CustomerInvoice();
            model.JobKey = id;
            model.CustomerKey = GlobalClass.LoginCustomerUser.Id;
            GlobalClass.CustomerItem = new List<CustomerItemList>();
            ViewBag.message = "";
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerInvoice model,string add,string save, string delete,string ItemName,int? Quantity,decimal? Rate)
        {
            if (!string.IsNullOrEmpty(delete))
            {
                foreach (var chk in GlobalClass.CustomerItem)
                {
                    if (chk.ItemName == delete)
                    {
                        GlobalClass.CustomerItem.Remove(chk);
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(add))
            {
                if(!string.IsNullOrEmpty(ItemName) && Quantity!=null && Rate!=null)
                {
                    CustomerItemList c = new CustomerItemList();
                    c.ItemName = ItemName;
                    c.Quantity = Quantity;
                    c.Rate = Rate;
                    GlobalClass.CustomerItem.Add(c);
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
                db.CustomerInvoice.Add(model);
                db.SaveChanges();
                if (GlobalClass.CustomerItem.Count() > 0)
                {

                    foreach(var item in GlobalClass.CustomerItem)
                    {
                        UtilityManagementDBEntities bc = new UtilityManagementDBEntities();
                        CustomerInvoiceDetail obj = new CustomerInvoiceDetail();
                        obj.InvoiceKey = model.InvoiceKey;
                        obj.ItemName = item.ItemName;
                        obj.Rate = item.Rate;
                        obj.Quantity = item.Quantity;
                        bc.CustomerInvoiceDetail.Add(obj);
                        bc.SaveChanges();
                        bc.Dispose();
                    }
                }
                GlobalClass.CustomerItem = new List<CustomerItemList>();
                return RedirectToAction("InvoiceList",new { id=model.JobKey});
            }

          
            return View(model);

        }

        public ActionResult Edit(Guid id)
        {
            CustomerInvoice model = db.CustomerInvoice.Find(id);          
            ViewBag.message = "";
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerInvoice model, string add, string save, int? delete, string ItemName, int? Quantity, decimal? Rate)
        {
            if (delete!=null)
            {
                UtilityManagementDBEntities bc = new UtilityManagementDBEntities();
                CustomerInvoiceDetail det = bc.CustomerInvoiceDetail.Find(delete);
                bc.CustomerInvoiceDetail.Remove(det);
                bc.SaveChanges();
                bc.Dispose();
            }

            if (!string.IsNullOrEmpty(add))
            {
                if (!string.IsNullOrEmpty(ItemName) && Quantity != null && Rate != null)
                {
                    UtilityManagementDBEntities bc = new UtilityManagementDBEntities();
                    CustomerInvoiceDetail obj = new CustomerInvoiceDetail();
                    obj.InvoiceKey = model.InvoiceKey;
                    obj.ItemName = ItemName;
                    obj.Rate = Rate;
                    obj.Quantity = Quantity;
                    bc.CustomerInvoiceDetail.Add(obj);
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
                CustomerInvoice inv = db.CustomerInvoice.Find(model.InvoiceKey);
                inv.InvoiceID = model.InvoiceID;
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
         
            CustomerInvoice inv = db.CustomerInvoice.Find(id);
            int? JobKey = inv.JobKey;
            if (inv == null)
            {
                return HttpNotFound();
            }
            var temp = from x in db.CustomerInvoiceDetail where x.InvoiceKey == inv.InvoiceKey select x;
            if (temp.Count() > 0)
            {
                db.CustomerInvoiceDetail.RemoveRange(temp);
            }
            db.CustomerInvoice.Remove(inv);
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