using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilityManagementSystem.Models
{
    public class CustomerItemList
    {
        public string ItemName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Rate { get; set; }
    }
}