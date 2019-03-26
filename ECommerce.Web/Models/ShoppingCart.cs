using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Models
{
    public class ShoppingCartModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Link { get; set; }
        public string PhotoLink { get; set; }
    }
}