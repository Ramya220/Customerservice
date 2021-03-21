using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customerservice.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string Customername { get; set; }
        public string Address { get; set; }
        public string street { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public Int64  phone { get; set; }
        public int zipcode { get; set; }
    }
}