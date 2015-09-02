using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NeoSocial.Database.Models.Mapping
{
    public class UserRegisterMap : EntityTypeConfiguration<UserRegister>
    {
        public UserRegisterMap()
        {
            // Primary Key
            this.HasKey(t => t.UserRegisterID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Surname)
                .HasMaxLength(50);

            this.Property(t => t.BirthDate)
                .HasMaxLength(15);

            this.Property(t => t.Email)
                .HasMaxLength(30);

            this.Property(t => t.CityID)
                .IsFixedLength()
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("UserRegister");
            this.Property(t => t.UserRegisterID).HasColumnName("UserRegisterID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Surname).HasColumnName("Surname");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.CityID).HasColumnName("CityID");

            // Relationships
            this.HasOptional(t => t.Country)
                .WithMany(t => t.UserRegisters)
                .HasForeignKey(d => d.CountryID);
            this.HasOptional(t => t.TurkeyCity)
                .WithMany(t => t.UserRegisters)
                .HasForeignKey(d => d.CityID);

        }
    }
}
