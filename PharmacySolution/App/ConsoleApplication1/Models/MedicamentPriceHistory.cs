using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Models
{
    public partial class MedicamentPriceHistory
    {
        public int Id { get; set; }
        public int MedicamentId { get; set; }
        public decimal Price { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual Medicament Medicament { get; set; }
    }
}
