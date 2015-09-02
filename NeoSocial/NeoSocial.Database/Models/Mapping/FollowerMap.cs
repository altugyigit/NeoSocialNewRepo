using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NeoSocial.Database.Models.Mapping
{
    public class FollowerMap : EntityTypeConfiguration<Follower>
    {
        public FollowerMap()
        {
            // Primary Key
            this.HasKey(t => t.FollowerID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Follower");
            this.Property(t => t.ProfileID).HasColumnName("ProfileID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.FollowerID).HasColumnName("FollowerID");

            // Relationships
            this.HasOptional(t => t.UserLogin)
                .WithMany(t => t.Followers)
                .HasForeignKey(d => d.UserID);
            this.HasOptional(t => t.UserProfile)
                .WithMany(t => t.Followers)
                .HasForeignKey(d => d.ProfileID);

        }
    }
}
