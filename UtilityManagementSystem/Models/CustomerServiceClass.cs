using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilityManagementSystem.Models
{
    public class CustomerServiceClass
    {
        public string JobName{ get; set; }
        public string CustomerName { get; set; }
        public string serviceDescription{ get; set; }
        public string ScheduleDate { get; set; }
        public string JobCompletedDate { get; set; }
        public decimal Cost{ get; set; }
        public string ItemsNeeded{ get; set; }
        public string ServiceType { get; set; }
        

    }
}