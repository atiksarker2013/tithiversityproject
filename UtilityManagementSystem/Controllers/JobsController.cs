﻿using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

            var job = db.Job.Where(m=>m.JobStatusId!=9 || m.JobStatusId!=8).Include(j => j.CustomerJobRequest).Include(j => j.JobStatus).Include(j => j.Vendor).Where(m=>m.JobStatusId!=9);
            return View(job.ToList());
        }

        //vendor job list
        public ActionResult VIndex()
        {

            var job = db.Job.Where(m => m.JobStatusId != 9 && m.JobStatusId>0 && m.JobStatusId<6 && m.VndorId==GlobalClass.LoginVendorUser.Id);
            return View(job.ToList());
        }
        //vendor job  detail
        public ActionResult vendorDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Job.Find(id);
            JobViewClass model = new JobViewClass();
            model.JobDescription = job.JobDescription;
            model.VendorName = job.Vendor.name;
            model.CompanyName = job.Vendor.companyName;
            model.JobRequestId = job.JobRequestId;
            model.JobStatusId = job.JobStatus.Name;
            model.Remark = job.Remark;
            model.EntryDate = job.CustomerJobRequest.EntryDate;
            model.ScheduleDate = job.CustomerJobRequest.ScheduleDate;
            model.VendorStartingDate = job.VendorStartingDate;
            model.VendorCompletionDate = job.VendorCompletionDate;
            model.JobCompletedDate = job.JobCompletedDate;


            if (job == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        public async Task<ActionResult> InvoiceAgree(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Job.Find(id);
            JobViewClass model = new JobViewClass();
            model.JobDescription = job.JobDescription;
            model.VendorName = job.Vendor.name;
            model.CompanyName = job.Vendor.companyName;
            model.JobRequestId = job.JobRequestId;
            model.JobStatusId = job.JobStatus.Name;
            model.Remark = job.Remark;
            model.EntryDate = job.CustomerJobRequest.EntryDate;
            model.ScheduleDate = job.CustomerJobRequest.ScheduleDate;
            model.VendorStartingDate = job.VendorStartingDate;
            model.VendorCompletionDate = job.VendorCompletionDate;
            model.JobCompletedDate = job.JobCompletedDate;
            if (job == null)
            {
                return HttpNotFound();
            }
            var client = new SendGridClient("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");
            var from = new EmailAddress(GlobalClass.LoginVendorUser.Email,GlobalClass.LoginVendorUser.companyName);
            var subject = "Vendor accepted work";
            var to = new EmailAddress("husnaafrin@gmail.com", "Husna");
            var htmlContentValue ="We will provide service to this customer.I will give invoice after completing the work";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContentValue);
            var response = await client.SendEmailAsync(msg);
           
            return await Task.Run(() => View(model));
        }
        //public ActionResult SendJobDetailsToVendorReport()
        //{

        //    var job = db.Job.Where(m => m.JobStatusId == 2).Include(j => j.CustomerJobRequest).Include(j => j.JobStatus).Include(j => j.Vendor);
        //    return View(job.ToList());
        //}

        //public ActionResult VendorAcceptEstimateReport()
        //{

        //    var job = db.Job.Where(m => m.JobStatusId == 3).Include(j => j.CustomerJobRequest).Include(j => j.JobStatus).Include(j => j.Vendor);
        //    return View(job.ToList());
        //}

        //public ActionResult VendorJobCompleteReport()
        //{

        //    var job = db.Job.Where(m => m.JobStatusId == 4).Include(j => j.CustomerJobRequest).Include(j => j.JobStatus).Include(j => j.Vendor);
        //    return View(job.ToList());
        //}

        //public ActionResult VendorStartWorkReport()
        //{

        //    var job = db.Job.Where(m => m.JobStatusId == 4).Include(j => j.CustomerJobRequest).Include(j => j.JobStatus).Include(j => j.Vendor);
        //    return View(job.ToList());
        //}

        public ActionResult CompletedJob()
        {

            var job = db.Job.Where(m=>m.JobStatusId==8).Include(j => j.CustomerJobRequest).Include(j => j.JobStatus).Include(j => j.Vendor);
            return View(job.ToList());

        }

        //public ActionResult PaymentReceive()
        //{

        //    var job = db.Job.Where(m => m.JobStatusId == 6).Include(j => j.CustomerJobRequest).Include(j => j.JobStatus).Include(j => j.Vendor);
        //    return View(job.ToList());

        //}


        public ActionResult VendorJob()
        {
            var job = db.Job.Where(m => m.VndorId == GlobalClass.LoginVendorUser.Id).Include(j => j.CustomerJobRequest).Include(j => j.JobStatus);
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
        //Customer job details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Job.Find(id);
            JobViewClass model = new JobViewClass();
            model.JobDescription = job.JobDescription;
            model.VendorName = job.Vendor.name;
            model.CompanyName = job.Vendor.companyName;
            model.JobRequestId = job.JobRequestId;
            model.JobStatusId = job.JobStatus.Name;
            model.Remark = job.Remark;
            model.EntryDate = job.CustomerJobRequest.EntryDate;
            model.ScheduleDate = job.CustomerJobRequest.ScheduleDate;
            model.VendorStartingDate = job.VendorStartingDate;
            model.VendorCompletionDate = job.VendorCompletionDate;
            model.JobCompletedDate = job.JobCompletedDate;
            if (job == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        public ActionResult CDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Job.Find(id);
            JobViewClass model = new JobViewClass();
            model.JobDescription = job.JobDescription;
            model.VendorName = job.Vendor.name;
            model.CompanyName = job.Vendor.companyName;
            model.JobRequestId = job.JobRequestId;
            model.JobStatusId = job.JobStatus.Name;
            model.Remark = job.Remark;
            model.EntryDate = job.CustomerJobRequest.EntryDate;
            model.ScheduleDate = job.CustomerJobRequest.ScheduleDate;
            model.VendorStartingDate = job.VendorStartingDate;
            model.VendorCompletionDate = job.VendorCompletionDate;
            model.JobCompletedDate = job.JobCompletedDate;
            if (job == null)
            {
                return HttpNotFound();
            }

            return View(model);
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
        //admin creat job for vendor
        public ActionResult Create()
        {
            ViewBag.JobRequestId = new SelectList(db.CustomerJobRequest.Where(m=>m.JobStatusId==1), "Id", "JobName");
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name");
            ViewBag.VndorId = new SelectList(db.Vendor.Where(m=>m.IsEnabled==true), "Id", "companyName");
            ViewBag.CustomerId = new SelectList(db.Customer,"Id","name");
            ViewBag.ServiceDescription= new SelectList(db.ServiceType ,"Id", "ServiceName");
            return View();

        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Job job)
        {
            if (ModelState.IsValid)
            {
                job.EntryDate = System.DateTime.Now;
                CustomerJobRequest req = db.CustomerJobRequest.Find(job.JobRequestId);
                job.CustomerId = req.CustomerId;
                db.Job.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.JobRequestId = new SelectList(db.CustomerJobRequest.Where(m => m.JobStatusId == 1), "Id", "JobName", job.JobRequestId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", job.JobStatusId);
            ViewBag.VndorId = new SelectList(db.Vendor.Where(m => m.IsEnabled == true), "Id", "companyName",job.VndorId);
            ViewBag.ServiceDescription = new SelectList(db.ServiceType, "Id", "ServiceName",job.ServiceDescription);
           // ViewBag.CustomerId = new SelectList(db.Customer, "Id", "name",job.CustomerId);

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
            ViewBag.VendorId = new SelectList(db.Vendor, "Id", "CompanyName", job.VndorId);
            ViewBag.ServiceDescription = new SelectList(db.ServiceType, "Id", "ServiceName",job.ServiceDescription);
            return View(job);
        }

        //Get:
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
            ViewBag.VendorId = new SelectList(db.Vendor, "Id", "CompanyName", job.VndorId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                //Job model = db.Job.Find(job.Id);
                //model.JobName = job.JobName;
               db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobRequestId = new SelectList(db.CustomerJobRequest, "Id", "JobName", job.JobRequestId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", job.JobStatusId);
            ViewBag.VendorId = new SelectList(db.Vendor, "Id", "CompanyName", job.VndorId);
            return View(job);
        }

        //Admin panel job on Process Edit view...................................
        // GET: Jobs/Edit/5
        public ActionResult JobProcessEdit(int? id)
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

            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "name", job.CustomerId);

            ViewBag.JobRequestId = new SelectList(db.CustomerJobRequest, "Id", "JobName", job.JobRequestId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", job.JobStatusId);
            ViewBag.VndorId = new SelectList(db.Vendor, "Id", "companyName", job.VndorId);
            

            ViewBag.ServiceDescription = new SelectList(db.ServiceType, "Id", "ServiceName", job.ServiceDescription);
            return View(job);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JobProcessEdit(Job job)
        {
          
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customer,"Id","name",job.CustomerId);
            ViewBag.JobRequestId = new SelectList(db.CustomerJobRequest, "Id", "JobName", job.JobRequestId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", job.JobStatusId);
            ViewBag.VndorId = new SelectList(db.Vendor, "Id", "companyName", job.VndorId);
            return View(job);
        }

        //Admin Completed job Edit view

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VendorEdit( Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("VendorJob");
            }

            ViewBag.JobRequestId = new SelectList(db.CustomerJobRequest, "Id", "JobName", job.JobRequestId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "Id", "Name", job.JobStatusId);
            ViewBag.VendorId = new SelectList(db.Vendor, "Id", "CompanyName", job.VndorId);
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
        // Admin Completed job Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Job.Find(id);
            db.Job.Remove(job);
            db.SaveChanges();
            return RedirectToAction("CompletedJob");

        }
        public ActionResult DirectDelete(int id)
        {
          Job job = db.Job.Find(id);
            job.JobStatusId = 9;
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
