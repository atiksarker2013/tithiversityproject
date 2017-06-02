using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilityManagementSystem.Models
{
    public class DataReturn
    {
        public int flag { get; set; }
        public Guid? key { get; set; }
        public string mess { get; set; }
        public int Pkey { get; set; }
    }
}