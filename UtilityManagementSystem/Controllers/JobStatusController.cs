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
    public class JobStatusController : Controller
    {
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();

        // GET: JobStatus
        public ActionResult Index()
        {
            return View(db.JobStatus.Where(m=>m.IsEnabled==true).ToList());
        }

        // GET: JobStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobStatus jobStatus = db.JobStatus.Find(id);
            if (jobStatus == null)
            {
                return HttpNotFound();
            }
            return View(jobStatus);
        }

        // GET: JobStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( JobStatus jobStatus)
        {
            if (ModelState.IsValid)
            {
                jobStatus.IsEnabled = true;
                db.JobStatus.Add(jobStatus);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobStatus);
        }

        // GET: JobStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobStatus jobStatus = db.JobStatus.Find(id);
            if (jobStatus == null)
            {
                return HttpNotFound();
            }
            return View(jobStatus);
        }

        // POST: JobStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobStatus jobStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobStatus);
        }

        // GET: JobStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobStatus jobStatus = db.JobStatus.Find(id);
            if (jobStatus == null)
            {
                return HttpNotFound();
            }
            return View(jobStatus);
        }

        // POST: JobStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobStatus jobStatus = db.JobStatus.Find(id);
            jobStatus.IsEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DirectDelete(int id)

        {
            JobStatus jobstatus = db.JobStatus.Find(id);
            
            jobstatus.IsEnabled = false;
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
