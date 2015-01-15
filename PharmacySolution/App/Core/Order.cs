using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Order : BaseEntity
    {
        public int PharmacyId { get; set; }
        public DateTime OperationDate { get; set; }
        public OperationType OperationType { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public virtual ICollection<OrderDetails> OrderDetailses { get; set; }

        public Order()
        {
            OrderDetailses = new List<OrderDetails>();
        }
    }
}