using System;
using System.Collections.Generic;

namespace ECommerce.Data
{
    public partial class ShippingTime
    {
        public ShippingTime()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }
        public string ShippingTime1 { get; set; }
        public string ColorCode { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
