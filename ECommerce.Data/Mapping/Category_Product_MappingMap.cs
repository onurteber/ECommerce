using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Mapping
{
    public class Category_Product_MappingMap : EntityTypeConfiguration<Category_Product_Mapping>
    {
        public Category_Product_MappingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CategoryId, t.ProductId });

            // Properties
            this.Property(t => t.CategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Category_Product_Mapping");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Queue).HasColumnName("Queue");
            this.Property(t => t.SpecialProduct).HasColumnName("SpecialProduct");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Category_Product_Mapping)
                .HasForeignKey(d => d.CategoryId);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.Category_Product_Mapping)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
