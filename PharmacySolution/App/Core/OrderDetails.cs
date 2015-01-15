using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Core
{
    public class OrderDetails : IDbEntity
    {
        public int OrderId { get; set; }
        public int MedicamentId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Count { get; set; }
        public virtual Order Order { get; set; }
        public virtual Medicament Medicament { get; set; }

        public OrderDetails()
        {
            
        }
    }
}
