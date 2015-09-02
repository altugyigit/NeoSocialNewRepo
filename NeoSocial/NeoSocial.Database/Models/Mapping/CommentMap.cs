using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NeoSocial.Database.Models.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.CommentID);

            // Properties
            this.Property(t => t.CommentText)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.CommentDate)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Comment");
            this.Property(t => t.CommentID).HasColumnName("CommentID");
            this.Property(t => t.CommentText).HasColumnName("CommentText");
            this.Property(t => t.CommentOwnerID).HasColumnName("CommentOwnerID");
            this.Property(t => t.CommentDate).HasColumnName("CommentDate");

            // Relationships
            this.HasRequired(t => t.UserProfile)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.CommentOwnerID);

        }
    }
}
