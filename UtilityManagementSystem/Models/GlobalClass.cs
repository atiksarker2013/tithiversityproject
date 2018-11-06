using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilityManagementSystem.Models
{
    public class GlobalClass
    {
        static private string _MasterSession = "MasterSession";
        public static bool MasterSession
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._MasterSession] == null)
                {
                    return false;
                }
                else
                {
                    return (bool)(HttpContext.Current.Session[GlobalClass._MasterSession]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._MasterSession] = value;
            }
        }
        static private string _CustomerItem = "CustomerItem";
        public static List<CustomerItemList> CustomerItem
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._CustomerItem] == null)
                {
                    return null;
                }
                else
                {
                    return (List<CustomerItemList>)(HttpContext.Current.Session[GlobalClass._CustomerItem]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._CustomerItem] = value;
            }
        }
        static private string _SystemSession = "SystemSession";
        public static bool SystemSession
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._SystemSession] == null)
                {
                    return false;
                }
                else
                {
                    return (bool)(HttpContext.Current.Session[GlobalClass._SystemSession]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._SystemSession] = value;
            }
        }
        static private string _LoginUser = "LoginUser";
        public static StaffList LoginUser
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._LoginUser] == null)
                {
                    return null;
                }
                else
                {
                    return (StaffList)(HttpContext.Current.Session[GlobalClass._LoginUser]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._LoginUser] = value;
            }
        }

        static private string _LoginCustomerUser = "LoginCustomerUser";
        public static Customer LoginCustomerUser
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._LoginCustomerUser] == null)
                {
                    return null;
                }
                else
                {
                    return (Customer)(HttpContext.Current.Session[GlobalClass._LoginCustomerUser]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._LoginCustomerUser] = value;
            }
        }

        static private string _LoginVendorUser = "LoginVendorUser";
        public static Vendor LoginVendorUser
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._LoginVendorUser] == null)
                {
                    return null;
                }
                else
                {
                    return (Vendor)(HttpContext.Current.Session[GlobalClass._LoginVendorUser]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._LoginVendorUser] = value;
            }
        }

        static private string _VendorItem = "VendorItem";
        public static List<VendorItemList> VendorItem
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._VendorItem] == null)
                {
                    return null;
                }
                else
                {
                    return (List<VendorItemList>)(HttpContext.Current.Session[GlobalClass._VendorItem]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._VendorItem] = value;
            }
        }
    }
}