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
    public class CustomerJobRequestsController : Controller
    {
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();

        // GET: CustomerJobRequests
        public ActionResult Index()
        {
            var customerJobRequest = db.CustomerJobRequest.Include(c => c.Customer).Include(c => c.JobStatus).Include(c => c.ServiceType);
            return View(customerJobRequest.ToList());
        }

        public ActionResult CustomerJobRequest()
        {
            var customerJobRequest = db.CustomerJobRequest.Include(c => c.Customer).Include(c => c.JobStatus).Include(c => c.ServiceType).Where(m=>m.CustomerId== GlobalClass.LoginCustomerUser.Id);
            return View(customerJobRequest.ToList());
        }

        // GET: CustomerJobRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerJobRequest customerJobRequest = db.CustomerJobRequest.Find(id);
            if (customerJobRequest == null)
            {
                return HttpNotFound();
            }
            return View(customerJobRequest);
        }

        // GET: CustomerJobRequests/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name");
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name");
            ViewBag.ServiceTypeId = new SelectList(db.ServiceType, "Id", "ServiceName");
            return View();
        }

        public ActionResult CreateByCustomer()
        {
            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name");
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name");
            ViewBag.ServiceTypeId = new SelectList(db.ServiceType, "Id", "ServiceName");
            return View();
        }

        // POST: CustomerJobRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JobName,CustomerId,Contact,ServiceAddress,ServiceTypeId,ServiceDetails,CustomerBudget,EntryDate,ScheduleDate,ReturnScheduleDate,JobStatusId")] CustomerJobRequest customerJobRequest)
        {
            if (ModelState.IsValid)
            {
                db.CustomerJobRequest.Add(customerJobRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name", customerJobRequest.CustomerId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", customerJobRequest.JobStatusId);
            ViewBag.ServiceTypeId = new SelectList(db.ServiceType, "Id", "ServiceName", customerJobRequest.ServiceTypeId);
            return View(customerJobRequest);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateByCustomer([Bind(Include = "Id,JobName,CustomerId,Contact,ServiceAddress,ServiceTypeId,ServiceDetails,CustomerBudget,EntryDate,ScheduleDate,ReturnScheduleDate,JobStatusId")] CustomerJobRequest customerJobRequest)
        {
            if (ModelState.IsValid)
            {
                db.CustomerJobRequest.Add(customerJobRequest);
                db.SaveChanges();
                return RedirectToAction("CustomerJobRequest");
            }

            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name", customerJobRequest.CustomerId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", customerJobRequest.JobStatusId);
            ViewBag.ServiceTypeId = new SelectList(db.ServiceType, "Id", "ServiceName", customerJobRequest.ServiceTypeId);
            return View(customerJobRequest);
        }

        // GET: CustomerJobRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerJobRequest customerJobRequest = db.CustomerJobRequest.Find(id);
            if (customerJobRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name", customerJobRequest.CustomerId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", customerJobRequest.JobStatusId);
            ViewBag.ServiceTypeId = new SelectList(db.ServiceType, "Id", "ServiceName", customerJobRequest.ServiceTypeId);
            return View(customerJobRequest);
        }

        // POST: CustomerJobRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JobName,CustomerId,Contact,ServiceAddress,ServiceTypeId,ServiceDetails,CustomerBudget,EntryDate,ScheduleDate,ReturnScheduleDate,JobStatusId")] CustomerJobRequest customerJobRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerJobRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name", customerJobRequest.CustomerId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", customerJobRequest.JobStatusId);
            ViewBag.ServiceTypeId = new SelectList(db.ServiceType, "Id", "ServiceName", customerJobRequest.ServiceTypeId);
            return View(customerJobRequest);
        }

        // GET: CustomerJobRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerJobRequest customerJobRequest = db.CustomerJobRequest.Find(id);
            if (customerJobRequest == null)
            {
                return HttpNotFound();
            }
            return View(customerJobRequest);
        }

        // POST: CustomerJobRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerJobRequest customerJobRequest = db.CustomerJobRequest.Find(id);
            db.CustomerJobRequest.Remove(customerJobRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
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
