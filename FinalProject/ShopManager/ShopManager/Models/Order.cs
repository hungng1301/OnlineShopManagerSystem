using System;
using System.Collections.Generic;

#nullable disable

namespace ShopManager.Models
{
    public partial class Order
    {
        public Order()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int Oid { get; set; }
        public DateTime? OrderDate { get; set; }
        public int Status { get; set; }
        public int Aid { get; set; }
        public double TotalPrice { get; set; }

        public virtual Account AidNavigation { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
