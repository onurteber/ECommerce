using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Photo { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
    }
}