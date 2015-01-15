using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ConsoleApplication1.Models.Mapping
{
    public class MedicamentPriceHistoryMap : EntityTypeConfiguration<MedicamentPriceHistory>
    {
        public MedicamentPriceHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MedicamentPriceHistories");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MedicamentId).HasColumnName("MedicamentId");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Medicament)
                .WithMany(t => t.MedicamentPriceHistories)
                .HasForeignKey(d => d.MedicamentId);

        }
    }
}
