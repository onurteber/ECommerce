using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Mapping
{
    public class BasketMap : EntityTypeConfiguration<Basket>
    {
        public BasketMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.ProductId });

            // Properties
            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Basket");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Count).HasColumnName("Count");
            this.Property(t => t.Price).HasColumnName("Price");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.Baskets)
                .HasForeignKey(d => d.ProductId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Baskets)
                .HasForeignKey(d => d.UserId);

        }
    }
}
