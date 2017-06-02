using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UtilityManagementSystem.Models;

namespace UtilityManagementSystem.Controllers
{
    public class CompaniesController : Controller
    {
        // GET: Companies
        // GET: Companies
        // GET: Companies
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();
        private FormValidation val = new FormValidation();
        // GET: Companies
        public ActionResult Index()
        {
            if (GlobalClass.MasterSession)
                return View(db.Company.ToList().Where(m => m.IsDelete == false));
            else
            {
                Exception e = new Exception("Session Expired");
                return View("Error", new HandleErrorInfo(e, "AdminLogin", "UserHome"));
            }

        }

        // GET: Companies/Details/5
        public ActionResult Details(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Company company = db.Company.Find(id);
                if (company == null)
                {
                    return HttpNotFound();
                }
                return View(company);

            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "AdminLogin", "UserHome"));
            }
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "AdminLogin", "UserHome"));
            }
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        byte[] data = null;
                        using (Stream inputStream = file.InputStream)
                        {
                            MemoryStream memoryStream = inputStream as MemoryStream;
                            if (memoryStream == null)
                            {
                                memoryStream = new MemoryStream();
                                inputStream.CopyTo(memoryStream);
                            }
                            data = memoryStream.ToArray();
                        }
                        company.Logo = data;
                        company.LogoType = file.ContentType;
                    }
                    company = val.ValidateCompany(company);
                    company.IsDelete = false;
                    company.CompanyKey = Guid.NewGuid();
                    db.Company.Add(company);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(company);
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "AdminLogin", "UserHome"));
            }
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Company company = db.Company.Find(id);
                if (company == null)
                {
                    return HttpNotFound();
                }
                return View(company);
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "AdminLogin", "UserHome"));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Company obj = db.Company.Find(company.CompanyKey);
                    if (file != null)
                    {
                        byte[] data = null;
                        using (Stream inputStream = file.InputStream)
                        {
                            MemoryStream memoryStream = inputStream as MemoryStream;
                            if (memoryStream == null)
                            {
                                memoryStream = new MemoryStream();
                                inputStream.CopyTo(memoryStream);
                            }
                            data = memoryStream.ToArray();
                        }
                        obj.Logo = data;
                        obj.LogoType = file.ContentType;
                    }
                    company = val.ValidateCompany(company);
                    obj.CompanyID = company.CompanyID;
                    obj.CompanyName = company.CompanyName;
                    obj.CityKey = company.CityKey;
                    obj.StateCode = company.StateCode;
                    obj.CityKey = company.CityKey;
                    obj.CompanyAddress = company.CompanyAddress;
                    obj.CompanyPhone = company.CompanyPhone;
                    obj.CompanyMobile = company.CompanyMobile;
                    obj.CompanyEmail = company.CompanyEmail;
                    obj.CompanyWebsite = company.CompanyWebsite;
                    obj.CompanyFax = company.CompanyFax;
                    obj.ContactPersonName = company.ContactPersonName;
                    obj.ContactPersonNo = company.ContactPersonNo;
                    obj.Title = company.Title;
                    obj.ContactEmail = company.ContactEmail;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(company);
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "AdminLogin", "UserHome"));
            }
        }



        public ActionResult UserEdit()
        {
            try
            {
                Company company = db.Company.Find(GlobalClass.Company.CompanyKey);
                CompanyClass model = val.FillCompanyInfo(company);
                return View(model);
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Index", "UserHome"));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(CompanyClass company, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Company obj = db.Company.Find(company.CompanyKey);
                    if (file != null)
                    {
                        byte[] data = null;
                        using (Stream inputStream = file.InputStream)
                        {
                            MemoryStream memoryStream = inputStream as MemoryStream;
                            if (memoryStream == null)
                            {
                                memoryStream = new MemoryStream();
                                inputStream.CopyTo(memoryStream);
                            }
                            data = memoryStream.ToArray();
                        }
                        obj.Logo = data;
                        obj.LogoType = file.ContentType;
                    }
                    company = val.ValidateCompanyClass(company);
                    obj.CompanyID = company.CompanyID;
                    obj.CompanyName = company.CompanyName;
                    obj.ZIPKey = company.ZIPKey;
                    obj.StateCode = company.StateCode;
                    obj.CityKey = company.CityKey;
                    obj.CompanyAddress = company.CompanyAddress;
                    obj.CompanyPhone = company.CompanyPhone;
                    obj.CompanyMobile = company.CompanyMobile;
                    obj.CompanyEmail = company.CompanyEmail;
                    obj.CompanyWebsite = company.CompanyWebsite;
                    obj.CompanyFax = company.CompanyFax;
                    obj.ContactPersonName = company.ContactPersonName;
                    obj.ContactPersonNo = company.ContactPersonNo;
                    obj.Title = company.Title;
                    obj.ContactEmail = company.ContactEmail;
                    db.SaveChanges();
                    return RedirectToAction("UserDetails");
                }
                return View(company);
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Index", "UserHome"));
            }
        }
        public ActionResult UserDetails()
        {
            try
            {

                Company company = db.Company.Find(GlobalClass.Company.CompanyKey);
                if (company == null)
                {
                    return HttpNotFound();
                }
                return View(company);

            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Index", "UserHome"));
            }
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Company company = db.Company.Find(id);
                company.IsDelete = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "AdminLogin", "UserHome"));
            }
        }

        public ActionResult ConpanyUserAcess(Guid id)
        {
            if (GlobalClass.MasterSession)
            {
                Company model = db.Company.Find(id);
                ViewBag.CompanyKey = new SelectList(db.Company.Where(m => m.CompanyKey == id), "CompanyKey", "CompanyName", id);
                return View(model);
            }
            else
            {
                Exception e = new Exception("Session Expired");
                return View("Error", new HandleErrorInfo(e, "AdminLogin", "UserHome"));
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConpanyUserAcess(Company model, Guid?[] unformlist, Guid?[] formlist)
        {
            if (GlobalClass.MasterSession)
            {
                if (unformlist == null)
                {
                }
                else
                {
                    if (unformlist.Count() > 0)
                    {
                        foreach (var temp in unformlist)
                        {
                            db = new UtilityManagementDBEntities();
                            CompanyForm a = db.CompanyForm.Find(temp);
                            Guid? comkey = a.CompanyKey;
                            Guid? moduleKey = a.ModuleKey;
                            Guid? formKey = a.FormKey;
                            db.CompanyForm.Remove(a);
                            db.SaveChanges();
                            CheckCompanyForModule(comkey, moduleKey);

                            db = new UtilityManagementDBEntities();
                            var fg = from m in db.UserGroupForm where m.FormKey == formKey && m.CompanyKey == comkey select m;
                            if (fg.Count() > 0)
                            {
                                foreach (var item in fg)
                                {
                                    UtilityManagementDBEntities nr = new UtilityManagementDBEntities();
                                    UserGroupForm b = nr.UserGroupForm.SingleOrDefault(m => m.UserGroupFormKey == item.UserGroupFormKey);
                                    Guid k = (Guid)b.ModuleKey;
                                    Guid uk = (Guid)b.UserGroupKey;
                                    nr.UserGroupForm.Remove(b);
                                    nr.SaveChanges();
                                    CheckUserGroupForModule(k, uk);
                                }
                            }
                        }
                    }
                }
                if (formlist == null)
                {
                }
                else
                {
                    if (formlist.Count() > 0)
                    {
                        foreach (var temp in formlist)
                        {
                            db = new UtilityManagementDBEntities();
                            Forms o = db.Forms.Find(temp);
                            AddModulesToCompany(o, model.CompanyKey);
                            CompanyForm a = new CompanyForm();
                            a.CompanyFormKey = Guid.NewGuid();
                            a.FormKey = temp;
                            a.CompanyKey = model.CompanyKey;
                            a.ModuleKey = o.ModuleID;
                            db.CompanyForm.Add(a);
                            db.SaveChanges();
                        }
                    }
                }
                model = db.Company.Find(model.CompanyKey);
                ViewBag.CompanyKey = new SelectList(db.Company, "CompanyKey", "CompanyName", model.CompanyKey);
                return View(model);
            }
            else
            {
                Exception e = new Exception("Session Expired");
                return View("Error", new HandleErrorInfo(e, "AdminLogin", "UserHome"));
            }

        }
        private void CheckCompanyForModule(Guid? comkey, Guid? moduleKey)
        {
            var t = from x in db.CompanyForm where x.ModuleKey == moduleKey && x.CompanyKey == comkey select x;

            if (!(t.Count() > 0))
            {
                CompanyModule a = db.CompanyModule.SingleOrDefault(x => x.ModuleKey == moduleKey && x.CompanyKey == comkey);
                db.CompanyModule.Remove(a);
                db.SaveChanges();
            }


        }
        private void AddModulesToCompany(Forms obj, Guid id)
        {
            var t = from x in db.CompanyModule where x.ModuleKey == obj.ModuleID && x.CompanyKey == id select x;

            if (!(t.Count() > 0))
            {
                db = new UtilityManagementDBEntities();
                CompanyModule a = new CompanyModule();
                a.CompanyModuleID = Guid.NewGuid();
                a.CompanyKey = id;
                a.ModuleKey = obj.ModuleID;
                db.CompanyModule.Add(a);
                db.SaveChanges();
            }


        }

        private void CheckUserGroupForModule(Guid obj, Guid grKey)
        {
            var t = from x in db.UserGroupForm where x.ModuleKey == obj && x.UserGroupKey == grKey select x;

            if (!(t.Count() > 0))
            {
                var ts = from x in db.UserGroupModule where x.ModuleKey == obj && x.UserGroupKey == grKey select x;
                foreach (var item in ts)
                {
                    UserGroupModule a = db.UserGroupModule.SingleOrDefault(x => x.UserGroupModuleKey == item.UserGroupModuleKey);
                    db.UserGroupModule.Remove(a);
                    db.SaveChanges();
                }

            }


        }
        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Company company = db.Company.Find(id);
            db.Company.Remove(company);
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