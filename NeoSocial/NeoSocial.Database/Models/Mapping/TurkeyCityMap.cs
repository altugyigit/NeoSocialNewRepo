using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NeoSocial.Database.Models.Mapping
{
    public class TurkeyCityMap : EntityTypeConfiguration<TurkeyCity>
    {
        public TurkeyCityMap()
        {
            // Primary Key
            this.HasKey(t => t.CityCode);

            // Properties
            this.Property(t => t.CityCode)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.CityName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TurkeyCities");
            this.Property(t => t.CityCode).HasColumnName("CityCode");
            this.Property(t => t.CityName).HasColumnName("CityName");
        }
    }
}
