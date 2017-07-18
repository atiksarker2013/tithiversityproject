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
            return View(db.JobStatus.ToList());
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
        public ActionResult Create([Bind(Include = "Id,Name")] JobStatus jobStatus)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult Edit([Bind(Include = "Id,Name")] JobStatus jobStatus)
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
            db.JobStatus.Remove(jobStatus);
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
