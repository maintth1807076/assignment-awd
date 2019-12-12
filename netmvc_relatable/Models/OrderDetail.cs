﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace netmvc_relatable.Models
{
    public class OrderDetail
    {
        [Key, Column(Order = 1)]
        public int OrderID { get; set; }
        [Key, Column(Order = 2)]
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}