using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ConsoleApplication1.Models.Mapping
{
    public class OrderDetailMap : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            // Primary Key
            this.HasKey(t => new { t.MedicamentId, t.OrderId });

            // Properties
            this.Property(t => t.MedicamentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OrderId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("OrderDetails");
            this.Property(t => t.MedicamentId).HasColumnName("MedicamentId");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.Count).HasColumnName("Count");

            // Relationships
            this.HasRequired(t => t.Medicament)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(d => d.MedicamentId);
            this.HasRequired(t => t.Order)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(d => d.OrderId);

        }
    }
}
