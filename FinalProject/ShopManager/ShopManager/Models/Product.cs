using System;
using System.Collections.Generic;

#nullable disable

namespace ShopManager.Models
{
    public partial class Product
    {
        public Product()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int Pid { get; set; }
        public string Pname { get; set; }
        public double Price { get; set; }
        public string Pimage { get; set; }
        public int Cid { get; set; }

        public virtual ProductCategory CidNavigation { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
