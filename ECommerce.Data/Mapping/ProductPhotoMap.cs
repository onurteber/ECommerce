using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Mapping
{
    public class ProductPhotoMap : EntityTypeConfiguration<ProductPhoto>
    {
        public ProductPhotoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ProductId, t.PhotoId });

            // Properties
            this.Property(t => t.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PhotoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ProductPhoto");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.PhotoId).HasColumnName("PhotoId");
            this.Property(t => t.Queue).HasColumnName("Queue");

            // Relationships
            this.HasRequired(t => t.Photo)
                .WithMany(t => t.ProductPhotoes)
                .HasForeignKey(d => d.PhotoId);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductPhotoes)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
