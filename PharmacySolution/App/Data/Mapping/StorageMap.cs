using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Data.Mapping
{
    public class StorageMap :EntityTypeConfiguration<Storage>
    {
        public StorageMap()
        {
            HasKey(m => new {m.MedicamentId, m.PharmacyId});
            Property(m => m.Count).IsRequired().HasColumnName("Count");

            HasRequired(m => m.Medicament).WithMany(m => m.Storages).HasForeignKey(storage => storage.MedicamentId);
            HasRequired(m => m.Pharmacy).WithMany(m => m.Storages).HasForeignKey(storage => storage.PharmacyId);
        }
    }
}
