using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Address1)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Country)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.PostCode)
                .HasMaxLength(50);

            this.Property(t => t.Company)
                .HasMaxLength(250);

            this.Property(t => t.TaxNo)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Address");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Address1).HasColumnName("Address");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.PostCode).HasColumnName("PostCode");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.TaxNo).HasColumnName("TaxNo");
            this.Property(t => t.Phone).HasColumnName("Phone");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.UserId)
                .WillCascadeOnDelete(false);

        }
    }
}
