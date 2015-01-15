using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ConsoleApplication1.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Orders");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PharmacyId).HasColumnName("PharmacyId");
            this.Property(t => t.OperationDate).HasColumnName("OperationDate");
            this.Property(t => t.OperationType).HasColumnName("OperationType");

            // Relationships
            this.HasRequired(t => t.Pharmacy)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.PharmacyId);

        }
    }
}
