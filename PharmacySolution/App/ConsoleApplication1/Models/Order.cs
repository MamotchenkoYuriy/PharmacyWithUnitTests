using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Models
{
    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public int Id { get; set; }
        public int PharmacyId { get; set; }
        public System.DateTime OperationDate { get; set; }
        public int OperationType { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
    }
}
