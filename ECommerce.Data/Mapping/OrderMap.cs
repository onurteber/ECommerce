using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Order");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.RealPrice).HasColumnName("RealPrice");
            this.Property(t => t.BillingAddressId).HasColumnName("BillingAddressId");
            this.Property(t => t.CargoAddressId).HasColumnName("CargoAddressId");
            this.Property(t => t.OrderStatus).HasColumnName("OrderStatus");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.UserId)
                .WillCascadeOnDelete(false);

        }
    }
}
