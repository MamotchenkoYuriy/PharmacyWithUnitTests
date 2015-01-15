using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Models
{
    public partial class Medicament
    {
        public Medicament()
        {
            this.MedicamentPriceHistories = new List<MedicamentPriceHistory>();
            this.OrderDetails = new List<OrderDetail>();
            this.Storages = new List<Storage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public string Manufactorer { get; set; }
        public Nullable<decimal> Price { get; set; }
        public virtual ICollection<MedicamentPriceHistory> MedicamentPriceHistories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
