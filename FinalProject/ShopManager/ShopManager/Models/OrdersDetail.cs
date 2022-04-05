using System;
using System.Collections.Generic;

#nullable disable

namespace ShopManager.Models
{
    public partial class OrdersDetail
    {
        public int Odid { get; set; }
        public int Pid { get; set; }
        public int Oid { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public virtual Order OidNavigation { get; set; }
        public virtual Product PidNavigation { get; set; }
    }
}
