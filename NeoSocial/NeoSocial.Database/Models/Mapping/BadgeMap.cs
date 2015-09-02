using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NeoSocial.Database.Models.Mapping
{
    public class BadgeMap : EntityTypeConfiguration<Badge>
    {
        public BadgeMap()
        {
            // Primary Key
            this.HasKey(t => t.BadgeID);

            // Properties
            this.Property(t => t.BadgeName)
                .IsFixedLength()
                .HasMaxLength(40);

            this.Property(t => t.BadgeIconPath)
                .IsFixedLength()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Badge");
            this.Property(t => t.BadgeID).HasColumnName("BadgeID");
            this.Property(t => t.BadgeName).HasColumnName("BadgeName");
            this.Property(t => t.BadgeIconPath).HasColumnName("BadgeIconPath");
        }
    }
}
