using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data
{
    public partial class Category
    {
        public Category()
        {
            this.Category_Product_Mapping = new List<Category_Product_Mapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public Nullable<int> ParentCategoryId { get; set; }
        public Nullable<int> PhotoId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        [Required]
        [StringLength(250)]
        public string Slug { get; set; }
        public bool ShowHomePage { get; set; }
        public int Queue { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual ICollection<Category_Product_Mapping> Category_Product_Mapping { get; set; }
        public virtual User User { get; set; }
    }
}
