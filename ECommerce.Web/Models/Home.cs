using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Models
{
    public class HomePageModel
    {
        public IEnumerable<ProductModel> FeaturedProducts { get; set; }
        public IEnumerable<ProductModel> TopViewedProducts { get; set; }
        public IEnumerable<HomePageCategoriesModel> FeaturedCategories { get; set; }
        public ProductModel SpecialProduct { get; set; }
        public List<SlideShowModel> Blog { get; set; }
        public dynamic Slider { get; set; }
    }

    public class SlideShowModel
    {
        public string SlidePhoto { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ButtonName { get; set; }
        public string ButtonLink { get; set; }
    }

    public class HomePageCategoriesModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public int Queue { get; set; }
        public string Slug { get; set; }
    }
}