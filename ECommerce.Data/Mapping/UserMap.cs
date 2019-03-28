using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.UserName)
                .HasMaxLength(250);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.LastLoginDate);

            this.Property(t => t.LastLoginIp)
                .HasMaxLength(250);

            this.Property(n => n.Phone)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.CargoAddressId).HasColumnName("CargoAddressId");
            this.Property(t => t.BillingAddressId).HasColumnName("BillingAddressId");
            this.Property(t => t.ApprovedEmail).HasColumnName("ApprovedEmail");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.LastLoginDate).HasColumnName("LastLoginDate");
            this.Property(t => t.LastLoginIp).HasColumnName("LastLoginIp");
            this.Property(t => t.RegisterDate).HasColumnName("RegisterDate");
            this.Property(t => t.Phone).HasColumnName("Phone");

            // Relationships
            this.HasOptional(t => t.Address)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.BillingAddressId)
                .WillCascadeOnDelete(false);
            this.HasOptional(t => t.Address1)
                .WithMany(t => t.Users1)
                .HasForeignKey(d => d.CargoAddressId)
                .WillCascadeOnDelete(false);

        }
    }
}
