using System;
using System.Collections.Generic;

namespace ECommerce.Data
{
    public partial class User
    {
        public User()
        {
            this.Addresses = new List<Address>();
            this.Baskets = new List<Basket>();
            this.Categories = new List<Category>();
            this.Orders = new List<Order>();
            this.Photos = new List<Photo>();
            this.CreatedProducts = new List<Product>();
            this.DeletedProducts = new List<Product>();
            this.UpdatedProducts = new List<Product>();
        }

        public int Id { get; set; }
        public System.Guid Guid { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Nullable<int> CargoAddressId { get; set; }
        public Nullable<int> BillingAddressId { get; set; }
        public bool ApprovedEmail { get; set; }
        public bool Active { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIp { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual Address Address { get; set; }
        public virtual Address Address1 { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Product> CreatedProducts { get; set; }
        public virtual ICollection<Product> DeletedProducts { get; set; }
        public virtual ICollection<Product> UpdatedProducts { get; set; }
    }
}
