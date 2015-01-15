using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Models
{
    public partial class Storage
    {
        public int MedicamentId { get; set; }
        public int PharmacyId { get; set; }
        public int Count { get; set; }
        public virtual Medicament Medicament { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
    }
}
