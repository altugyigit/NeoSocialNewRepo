using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NeoSocial.Database.Models.Mapping
{
    public class UserLoginMap : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserName)
                .HasMaxLength(15);

            this.Property(t => t.UserPassword)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("UserLogin");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.UserPassword).HasColumnName("UserPassword");
            this.Property(t => t.UserRegisterID).HasColumnName("UserRegisterID");

            // Relationships
            this.HasRequired(t => t.UserRegister)
                .WithMany(t => t.UserLogins)
                .HasForeignKey(d => d.UserRegisterID);

        }
    }
}
