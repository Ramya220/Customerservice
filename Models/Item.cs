using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customerservice.Models
{
    public class Item
    {
        public int itemcode { get; set; }
        public string itemname { get; set; }
        public int QuantityonHand { get; set; }
        public decimal price { get; set; }
        public bool webenabled { get; set; }
      
    }
}