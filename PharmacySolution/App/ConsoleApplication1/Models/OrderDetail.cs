using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Models
{
    public partial class OrderDetail
    {
        public int MedicamentId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Count { get; set; }
        public virtual Medicament Medicament { get; set; }
        public virtual Order Order { get; set; }
    }
}
