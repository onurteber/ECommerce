using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data
{
    public partial class Basket
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
