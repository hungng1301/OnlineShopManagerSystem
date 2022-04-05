using System;
using System.Collections.Generic;

#nullable disable

namespace ShopManager.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public int Cid { get; set; }
        public string Cname { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public ProductCategory(string cname)
        {
            Cname = cname;
        }
    }
}
