using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilityManagementSystem.Models
{
    public class JobViewClass
    {
        public int Id { get; set; }
        public string VendorName { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> JobRequestId { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string ServiceDescription { get; set; }
        public string JobStatusId { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> ScheduleDate { get; set; }
        public Nullable<System.DateTime> VendorStartingDate { get; set; }
        public Nullable<System.DateTime> VendorCompletionDate { get; set; }
        public Nullable<System.DateTime> JobCompletedDate { get; set; }

     
    }
}