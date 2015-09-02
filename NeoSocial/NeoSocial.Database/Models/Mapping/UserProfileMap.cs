using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NeoSocial.Database.Models.Mapping
{
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            // Primary Key
            this.HasKey(t => t.UserProfileID);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserProfile");
            this.Property(t => t.UserProfileID).HasColumnName("UserProfileID");
            this.Property(t => t.UserRegisterID).HasColumnName("UserRegisterID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.IconID).HasColumnName("IconID");

            // Relationships
            this.HasOptional(t => t.Icon)
                .WithMany(t => t.UserProfiles)
                .HasForeignKey(d => d.IconID);
            this.HasOptional(t => t.UserLogin)
                .WithMany(t => t.UserProfiles)
                .HasForeignKey(d => d.UserID);

        }
    }
}
