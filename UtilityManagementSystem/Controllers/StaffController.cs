using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityManagementSystem.Models;

namespace UtilityManagementSystem.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();
        private FormValidation Val = new FormValidation();
        // GET: Staff

        public Byte[] BufferFromImage(HttpPostedFileBase file, int width, int height)
        {
            Byte[] buffer = null;
            ImageConverter converter = new ImageConverter();
            using (var srcImage = Image.FromStream(file.InputStream, true, true))
            {

                using (var newImage = new Bitmap(width, height))
                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.Low;
                    graphics.PixelOffsetMode = PixelOffsetMode.Half;
                    graphics.DrawImage(srcImage, new Rectangle(0, 0, width, height));
                    buffer = (byte[])converter.ConvertTo(newImage, typeof(byte[]));

                }
            }


            return buffer;
        }
        public ActionResult Index()
        {
            if (GlobalClass.SystemSession)
            {
                var staffList = db.StaffList.Where(m => m.CompanyKey == GlobalClass.Company.CompanyKey && m.IsDelete == false).OrderBy(m => m.PName);
                return View(staffList.ToList());
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }

        }
        public ActionResult DIndex()
        {
            if (GlobalClass.SystemSession)
            {
                var staffList = db.StaffList.Where(m => m.CompanyKey == GlobalClass.Company.CompanyKey && m.IsDelete == false).OrderBy(m => m.PName);
                return View(staffList.ToList());
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }

        }
        // GET: Staff/Details/5
        public ActionResult Details(Guid? id)
        {
            if (GlobalClass.SystemSession)
            {
                StaffList staffList = db.StaffList.Find(id);

                return View(staffList);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
        public ActionResult MyProfile(Guid? id)
        {
            if (GlobalClass.SystemSession)
            {
                StaffList staffList = db.StaffList.Find(GlobalClass.LoginUser.PersonnelKey);

                return View(staffList);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            if (GlobalClass.SystemSession)
            {
                ViewBag.mess = "";
                ViewBag.Usergr = new SelectList(db.Usergroup.Where(m => m.CompanyKey == GlobalClass.Company.CompanyKey).OrderBy(m => m.GroupName), "UserGroupKey", "GroupName");

                return View();
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffClass staffList, HttpPostedFileBase file)
        {
            if (GlobalClass.SystemSession)
            {
                ViewBag.mess = "";
                bool flag = true;
                if (string.IsNullOrEmpty(staffList.PID))
                {

                }
                else
                {
                    var uid = from x in db.StaffList where x.PID == staffList.PID && x.CompanyKey == GlobalClass.Company.CompanyKey select x;
                    if (uid.Count() > 0)
                    {
                        ViewBag.mess = "Duplicate ID";
                        flag = false;
                    }
                    else { }
                }
                if (flag == true)
                {
                    if (file != null)
                    {
                        byte[] data = null;

                        data = BufferFromImage(file, 50, 80);
                        staffList.Pic = data;
                        staffList.PicType = file.ContentType;
                    }
                    staffList = Val.ValidateStaff(staffList, true);
                    StaffList model = new StaffList();
                    model.PersonnelKey = Guid.NewGuid();
                    model.IsUser = true;
                    model.IsDelete = false;
                    model.Pic = staffList.Pic; model.PicType = staffList.PicType;
                    model.PID = staffList.PID;
                    model.PName = staffList.PName;
                    model.Mobile = staffList.Mobile;
                    model.Mail = staffList.Mail;
                    model.Designation = staffList.Designation;
                    model.Department = staffList.Department;
                    model.Username = staffList.Username;
                    model.Password = staffList.Password;
                    model.Usergr = staffList.Usergr;
                    model.CompanyKey = GlobalClass.Company.CompanyKey;
                    db.StaffList.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Usergr = new SelectList(db.Usergroup.Where(m => m.CompanyKey == GlobalClass.Company.CompanyKey).OrderBy(m => m.GroupName), "UserGroupKey", "GroupName", staffList.Usergr);

                return View(staffList);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (GlobalClass.SystemSession)
            {
                StaffList staffList = db.StaffList.Find(id);
                ViewBag.mess = "";

                ViewBag.Usergr = new SelectList(db.Usergroup, "UserGroupKey", "GroupName", staffList.Usergr);
                return View(staffList);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffList staffList, HttpPostedFileBase file)
        {
            if (GlobalClass.SystemSession)
            {
                ViewBag.mess = "";
                bool flag = true;
                if (string.IsNullOrEmpty(staffList.PID))
                {

                }
                else
                {
                    var uid = from x in db.StaffList where x.PID == staffList.PID && x.PersonnelKey != staffList.PersonnelKey && x.CompanyKey == GlobalClass.Company.CompanyKey select x;
                    if (uid.Count() > 0)
                    {
                        ViewBag.mess = "Duplicate ID";
                        flag = false;
                    }
                    else { }
                }
                if (flag == true)
                {
                    StaffList model = db.StaffList.Find(staffList.PersonnelKey);
                    if (file != null)
                    {
                        byte[] data = null;

                        data = BufferFromImage(file, 50, 80);
                        model.Pic = data;
                        model.PicType = file.ContentType;
                    }
                    model.PID = staffList.PID;
                    model.PName = staffList.PName;
                    model.Mobile = staffList.Mobile;
                    model.Department = staffList.Department;
                    model.Designation = staffList.Designation;
                    model.Username = staffList.Username;
                    model.Usergr = staffList.Usergr;
                    model.Mail = staffList.Mail;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Usergr = new SelectList(db.Usergroup, "UserGroupKey", "GroupName", staffList.Usergr);
                return View(staffList);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (GlobalClass.SystemSession)
            {

                StaffList staffList = db.StaffList.Find(id);
                staffList.IsDelete = true;
                db.SaveChanges();
                return RedirectToAction("DIndex");
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            StaffList staffList = db.StaffList.Find(id);
            db.StaffList.Remove(staffList);
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