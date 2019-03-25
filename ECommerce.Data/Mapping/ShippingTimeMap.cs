using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Mapping
{
    public class ShippingTimeMap : EntityTypeConfiguration<ShippingTime>
    {
        public ShippingTimeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ShippingTime1)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.ColorCode)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ShippingTime");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ShippingTime1).HasColumnName("ShippingTime");
            this.Property(t => t.ColorCode).HasColumnName("ColorCode");
        }
    }
}
