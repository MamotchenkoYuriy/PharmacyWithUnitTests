using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ConsoleApplication1.Models.Mapping
{
    public class StorageMap : EntityTypeConfiguration<Storage>
    {
        public StorageMap()
        {
            // Primary Key
            this.HasKey(t => new { t.MedicamentId, t.PharmacyId });

            // Properties
            this.Property(t => t.MedicamentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PharmacyId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Storages");
            this.Property(t => t.MedicamentId).HasColumnName("MedicamentId");
            this.Property(t => t.PharmacyId).HasColumnName("PharmacyId");
            this.Property(t => t.Count).HasColumnName("Count");

            // Relationships
            this.HasRequired(t => t.Medicament)
                .WithMany(t => t.Storages)
                .HasForeignKey(d => d.MedicamentId);
            this.HasRequired(t => t.Pharmacy)
                .WithMany(t => t.Storages)
                .HasForeignKey(d => d.PharmacyId);

        }
    }
}
