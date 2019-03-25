using System;
using System.Collections.Generic;

namespace ECommerce.Data
{
    public partial class Photo
    {
        public Photo()
        {
            this.Categories = new List<Category>();
            this.ProductPhotoes = new List<ProductPhoto>();
        }

        public int Id { get; set; }
        public Nullable<int> FolderId { get; set; }
        public string FileUrl { get; set; }
        public int UserId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotoes { get; set; }
    }
}
