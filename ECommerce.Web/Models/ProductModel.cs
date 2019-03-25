using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Full { get; set; }
        public string Slug { get; set; }
        public decimal Price { get; set; }
        public decimal? PastPrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public DateTime? SpecialPriceStartDate { get; set; }
        public DateTime? SpecialPriceFinishDate { get; set; }
        public int? Stock { get; set; }
        public string ShipmentDay { get; set; }
        public List<string> Photos { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public List<ProductModel> RelatedProducts { get; set; }
    }
}