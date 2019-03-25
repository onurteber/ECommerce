using System;
using System.Collections.Generic;

namespace ECommerce.Data
{
    public partial class ProductPhoto
    {
        public int ProductId { get; set; }
        public int PhotoId { get; set; }
        public int Queue { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual Product Product { get; set; }
    }
}
