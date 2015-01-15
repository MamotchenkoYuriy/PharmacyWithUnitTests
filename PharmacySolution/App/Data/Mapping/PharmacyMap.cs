using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Mapping
{
    public class PharmacyMap :EntityTypeConfiguration<Pharmacy>
    {
        public PharmacyMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Number).IsRequired().HasColumnName("Number");
            Property(m => m.OpenDate).IsRequired().HasColumnName("OpenDate");
            Property(m => m.PhoneNumber).IsRequired().HasColumnName("PhoneNumber");
            Property(m => m.Address).IsRequired().HasColumnName("Address");
        }
    }
}
