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

        

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       

        // GET: Staff/Edit/5
      

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
     

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