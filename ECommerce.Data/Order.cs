using System;
using System.Collections.Generic;

namespace ECommerce.Data
{
    public partial class Order
    {
        public Order()
        {
            this.OrderProducts = new List<OrderProduct>();
        }

        public int Id { get; set; }
        public System.Guid Guid { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal RealPrice { get; set; }
        public int BillingAddressId { get; set; }
        public int CargoAddressId { get; set; }
        public int OrderStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
