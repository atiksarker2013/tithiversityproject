using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityManagementSystem.Models;

namespace UtilityManagementSystem.Controllers
{
    public class CommonReportsController : Controller
    {
        private UtilityManagementDBEntities db = new UtilityManagementDBEntities();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomerService()
        {
            var joblist = db.Job.Where(m=>m.JobStatusId==8 && m.JobStatusId!=9).OrderByDescending(m => m.EntryDate);
            List<CustomerServiceClass> obj = new List<CustomerServiceClass>();
            foreach(var item in joblist)
            {
                CustomerServiceClass model = new CustomerServiceClass();
                model.JobCompletedDate = item.JobCompletedDate == null ? "" : item.JobCompletedDate.Value.ToShortDateString();
                model.ScheduleDate = item.ScheduleDate == null ? "" : item.ScheduleDate.Value.ToShortDateString();
                model.JobName = item.JobName;
                model.serviceDescription = item.JobDescription;
                model.ServiceType = item.ServiceType.ServiceName;
                var tempcost = from x in db.CustomerInvoice
                               join y in db.CustomerInvoiceDetail on x.InvoiceKey equals y.InvoiceKey
                               where x.JobKey == item.Id
                               select y;
                if (tempcost.Count() > 0)
                {
                    var tempItem = tempcost;
                    model.Cost = tempcost.Sum(m => (m.Rate * m.Quantity)).Value;
                    foreach (var t in tempItem)
                    {
                        model.ItemsNeeded = model.ItemsNeeded + t.ItemName + " Quantity - " + t.Quantity.ToString() + "\n";
                    }
                }
                else
                {
                    model.Cost = 0;
                    model.ItemsNeeded = "";
                }
                obj.Add(model);
            }
            return View(obj.ToList());
        }
    }
}