using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Mapping
{
    public class PhotoMap : EntityTypeConfiguration<Photo>
    {
        public PhotoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FileUrl)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Photo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FolderId).HasColumnName("FolderId");
            this.Property(t => t.FileUrl).HasColumnName("FileUrl");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Photos)
                .HasForeignKey(d => d.UserId)
                .WillCascadeOnDelete(false);

        }
    }
}
