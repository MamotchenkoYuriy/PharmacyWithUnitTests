using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ConsoleApplication1.Models.Mapping
{
    public class MedicamentMap : EntityTypeConfiguration<Medicament>
    {
        public MedicamentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.SerialNumber)
                .IsRequired();

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.Manufactorer)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Medicaments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Manufactorer).HasColumnName("Manufactorer");
            this.Property(t => t.Price).HasColumnName("Price");
        }
    }
}
