using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ConsoleApplication1.Models.Mapping
{
    public class PharmacyMap : EntityTypeConfiguration<Pharmacy>
    {
        public PharmacyMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Address)
                .IsRequired();

            this.Property(t => t.Number)
                .IsRequired();

            this.Property(t => t.PhoneNumber)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Pharmacies");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.OpenDate).HasColumnName("OpenDate");
        }
    }
}
