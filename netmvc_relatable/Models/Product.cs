using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace netmvc_relatable.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Thumbnail { get; set; }
        [DisplayName("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

    }
}