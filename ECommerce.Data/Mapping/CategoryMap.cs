using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
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

            // Table & Column Mappings
            this.ToTable("Category");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ShortDescription).HasColumnName("ShortDescription");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ParentCategoryId).HasColumnName("ParentCategoryId");
            this.Property(t => t.PhotoId).HasColumnName("PhotoId");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Slug).HasColumnName("Slag");

            // Relationships
            this.HasOptional(t => t.Photo)
                .WithMany(t => t.Categories)
                .HasForeignKey(d => d.PhotoId)
                .WillCascadeOnDelete(false);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Categories)
                .HasForeignKey(d => d.UserId)
                .WillCascadeOnDelete(false);

        }
    }
}
