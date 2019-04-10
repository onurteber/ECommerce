using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class CategoryIndexModel
    {
        public int Id { get; set; }
        [Display(Name = "İsim")]
        public string Name { get; set; }
        public string PhotoURL { get; set; }
        [Display(Name = "Sıra")]
        public int Queue { get; set; }
        [Display(Name = "Ürün Sayısı")]
        public int ProductCount { get; set; }

    }

    public class CategoryEditCreateModel
    {
        public int Id { get; set; }
        [Display(Name = "İsim")]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        [Display(Name = "Sıra")]
        public int Queue { get; set; }
        public bool ShowOnHomePage { get; set; }
        public HttpPostedFileBase Photo{ get; set; }
        public string PhotoURL { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}