using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace netmvc_relatable.Models
{
    public class CartItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}