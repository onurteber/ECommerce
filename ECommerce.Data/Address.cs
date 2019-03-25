using System;
using System.Collections.Generic;

namespace ECommerce.Data
{
    public partial class Address
    {
        public Address()
        {
            this.Users = new List<User>();
            this.Users1 = new List<User>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string Company { get; set; }
        public string TaxNo { get; set; }
        public string Phone { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<User> Users1 { get; set; }
    }
}
