using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customerservice.Models
{
    public class Sales
    {
        public int OrderNum { get; set; }
        public int ReferenceNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime PostingDate { get; set; }
        public string Address { get; set; }
        public int DocTotal { get; set; }
        public string State { get; set; }
        public Int64 Zipcode { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string SalesPerson { get; set; }
        public int ItemNo { get; set; }
        public int Quantityordered { get; set; }
        public decimal Price { get; set; }
        public decimal linetotal { get; set; }
    }
}