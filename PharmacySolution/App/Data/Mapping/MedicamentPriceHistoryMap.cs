using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Data.Mapping
{
    public class MedicamentPriceHistoryMap : EntityTypeConfiguration<MedicamentPriceHistory>
    {
        public MedicamentPriceHistoryMap()
        {
            HasKey(m =>m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.ModifiedDate).IsRequired().HasColumnName("ModifiedDate");
            Property(m => m.Price).IsRequired().HasColumnName("Price");
            HasRequired(m=>m.Medicament).WithMany(m=>m.MedicamentPriceHistories).HasForeignKey(m=>m.MedicamentId).WillCascadeOnDelete(true);
        }
    }
}
