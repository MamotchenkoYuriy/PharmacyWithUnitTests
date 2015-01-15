using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Models
{
    public partial class Pharmacy
    {
        public Pharmacy()
        {
            this.Orders = new List<Order>();
            this.Storages = new List<Storage>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string PhoneNumber { get; set; }
        public System.DateTime OpenDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
