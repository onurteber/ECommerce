using System;
using System.Collections.Generic;

namespace ECommerce.Data
{
    public partial class Category_Product_Mapping
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public int Queue { get; set; }
        public bool SpecialProduct { get; set; }
        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
