using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NeoSocial.Database.Models.Mapping
{
    public class ArticlePostMap : EntityTypeConfiguration<ArticlePost>
    {
        public ArticlePostMap()
        {
            // Primary Key
            this.HasKey(t => t.PostID);

            // Properties
            this.Property(t => t.PostHeader)
                .HasMaxLength(150);

            this.Property(t => t.PostContent)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.PostDate)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ArticlePost");
            this.Property(t => t.PostID).HasColumnName("PostID");
            this.Property(t => t.PostHeader).HasColumnName("PostHeader");
            this.Property(t => t.PostContent).HasColumnName("PostContent");
            this.Property(t => t.PostDate).HasColumnName("PostDate");
            this.Property(t => t.PostOwnerID).HasColumnName("PostOwnerID");
            this.Property(t => t.PostLikeCount).HasColumnName("PostLikeCount");
            this.Property(t => t.PostCommentID).HasColumnName("PostCommentID");

            // Relationships
            this.HasRequired(t => t.UserLogin)
                .WithMany(t => t.ArticlePosts)
                .HasForeignKey(d => d.PostOwnerID);

        }
    }
}
