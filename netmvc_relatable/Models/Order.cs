using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace netmvc_relatable.Models
{
    public class Order
    {
        public int ID { get; set; }
        public double TotalPrice { get; set; }
        public int MemberID { get; set; }
        public int PaymentTypeID { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public long DeletedAt { get; set; }
        public int Status { get; set; }

        public enum OrderStatusType { Pending = 5, Confirmed = 4, Shipping = 3, Paid = 2, Done = 1, Cancel = 0, Deleted = -1 }
        public enum PaymentType { Cod = 1, InternetBanking = 2, DirectTransfer = 3 }
        public virtual  ICollection<OrderDetail> OrderDetails { get; set; }
    }
}