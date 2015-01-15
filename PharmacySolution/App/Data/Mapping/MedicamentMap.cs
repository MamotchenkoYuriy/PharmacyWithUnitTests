using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Data.Mapping
{
    public class MedicamentMap : EntityTypeConfiguration<Medicament>
    {
        public MedicamentMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Name).IsRequired().HasColumnName("Name");
            //Property(m => m.Manufactorer).IsRequired().HasColumnName("Manufactorer");
            Property(m => m.SerialNumber ).IsRequired().HasColumnName("SerialNumber");
            Property(m => m.Description).IsRequired().HasColumnName("Description");
            Property(m => m.Price).IsOptional().HasColumnName("Price");
        }
    }
}
