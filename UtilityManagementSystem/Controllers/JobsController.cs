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
    public class JobsController : Controller
    {
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();



        // GET: Jobs
        public ActionResult Index()
        {

            var job = db.Job.Include(j => j.CustomerJobRequest).Include(j => j.JobStatus).Include(j => j.Vendor);
            return View(job.ToList());
        }

        public ActionResult CompletedJob()
        {

            var job = db.Job.Where(m=>m.JobStatusId==5).Include(j => j.CustomerJobRequest).Include(j => j.JobStatus).Include(j => j.Vendor);
            return View(job.ToList());

        }


        public ActionResult VendorJob()
        {
            var job = db.Job.Include(j => j.CustomerJobRequest).Include(j => j.JobStatus).Include(j => j.Vendor).Where(m=>m.VendorId== GlobalClass.LoginVendorUser.Id);
            return View(job.ToList());

        }

        public ActionResult CustomerJobDetailsDetails(int? id)
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

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        }

        public ActionResult VendorJobDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Job job = db.Job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.JobRequestId = new SelectList(db.CustomerJobRequest.Where(m=>m.JobStatusId==1), "Id", "JobName");
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name");
            ViewBag.VendorId = new SelectList(db.Vendor, "Id", "CompanyName");
            return View();

        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JobRequestId,VendorId,VendorCharge,MeterialDescription,MaterialCost,JobStatusId")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Job.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.JobRequestId = new SelectList(db.CustomerJobRequest.Where(m => m.JobStatusId == 1), "Id", "JobName", job.JobRequestId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", job.JobStatusId);
            ViewBag.VendorId = new SelectList(db.Vendor, "Id", "CompanyName", job.VendorId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Job job = db.Job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobRequestId = new SelectList(db.CustomerJobRequest, "Id", "JobName", job.JobRequestId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", job.JobStatusId);
            ViewBag.VendorId = new SelectList(db.Vendor, "Id", "CompanyName", job.VendorId);
            return View(job);
        }


        public ActionResult VendorEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobRequestId = new SelectList(db.CustomerJobRequest, "Id", "JobName", job.JobRequestId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", job.JobStatusId);
            ViewBag.VendorId = new SelectList(db.Vendor, "Id", "CompanyName", job.VendorId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JobRequestId,VendorId,VendorCharge,MeterialDescription,MaterialCost,JobStatusId")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobRequestId = new SelectList(db.CustomerJobRequest, "Id", "JobName", job.JobRequestId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", job.JobStatusId);
            ViewBag.VendorId = new SelectList(db.Vendor, "Id", "CompanyName", job.VendorId);
            return View(job);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VendorEdit([Bind(Include = "Id,JobRequestId,VendorId,VendorCharge,MeterialDescription,MaterialCost,JobStatusId")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("VendorJob");
            }
            ViewBag.JobRequestId = new SelectList(db.CustomerJobRequest, "Id", "JobName", job.JobRequestId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", job.JobStatusId);
            ViewBag.VendorId = new SelectList(db.Vendor, "Id", "CompanyName", job.VendorId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Job.Find(id);
            db.Job.Remove(job);
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
