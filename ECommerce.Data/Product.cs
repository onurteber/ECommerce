using System;
using System.Collections.Generic;

namespace ECommerce.Data
{
    public partial class Product
    {
        public Product()
        {
            this.Baskets = new List<Basket>();
            this.Category_Product_Mapping = new List<Category_Product_Mapping>();
            this.OrderProducts = new List<OrderProduct>();
            this.ProductPhotoes = new List<ProductPhoto>();
        }

        public int Id { get; set; }
        public bool Visibility { get; set; }
        public bool ShowOnHomePage { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool StockActive { get; set; }
        public Nullable<int> StockCount { get; set; }
        public string Slug { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public decimal Price { get; set; }
        public Nullable<decimal> PastPrice { get; set; }
        public Nullable<decimal> SpecialPrice { get; set; }
        public Nullable<System.DateTime> SpecialPriceStartDate { get; set; }
        public Nullable<System.DateTime> SpecialPriceFinishDate { get; set; }
        public Nullable<int> ShippingTimeId { get; set; }
        public int Queue { get; set; }
        public string StockCode { get; set; }
        public string AdminComment { get; set; }
        public int UserId { get; set; }
        public int Viewed { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<int> DeletedUserId { get; set; }
        public Nullable<int> LastUpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Category_Product_Mapping> Category_Product_Mapping { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ShippingTime ShippingTime { get; set; }
        public virtual User CreatorUser { get; set; }
        public virtual User WiperUser { get; set; }
        public virtual User LastUpdateUser { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotoes { get; set; }
    }
}
