using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Core
{
    public class Storage :IDbEntity
    {
        public int MedicamentId { get; set; }
        public int PharmacyId { get; set; }
        public int Count { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public virtual Medicament Medicament { get; set; }

        public Storage()
        {
            
        }
    }
}