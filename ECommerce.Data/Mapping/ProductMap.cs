using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.ShortDescription)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.Slug)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.StockCode)
                .HasMaxLength(250);

            this.Property(t => t.AdminComment)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Product");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Visibility).HasColumnName("Visibility");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.ShortDescription).HasColumnName("ShortDescription");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.StockActive).HasColumnName("StockActive");
            this.Property(t => t.StockCount).HasColumnName("StockCount");
            this.Property(t => t.Slug).HasColumnName("Slug");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.PastPrice).HasColumnName("PastPrice");
            this.Property(t => t.SpecialPrice).HasColumnName("SpecialPrice");
            this.Property(t => t.SpecialPriceStartDate).HasColumnName("SpecialPriceStartDate");
            this.Property(t => t.SpecialPriceFinishDate).HasColumnName("SpecialPriceFinishDate");
            this.Property(t => t.ShippingTimeId).HasColumnName("ShippingTimeId");
            this.Property(t => t.StockCode).HasColumnName("StockCode");
            this.Property(t => t.AdminComment).HasColumnName("AdminComment");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");
            this.Property(t => t.LastUpdateUserId).HasColumnName("LastUpdateUserId");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");

            // Relationships
            this.HasOptional(t => t.ShippingTime)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.ShippingTimeId);
            this.HasRequired(t => t.CreatorUser)
                .WithMany(t => t.CreatedProducts)
                .HasForeignKey(d => d.UserId);
            this.HasOptional(t => t.WiperUser)
                .WithMany(t => t.DeletedProducts)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.LastUpdateUser)
                .WithMany(t => t.UpdatedProducts)
                .HasForeignKey(d => d.LastUpdateUserId);

        }
    }
}
