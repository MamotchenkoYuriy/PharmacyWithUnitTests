using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Pharmacy :BaseEntity
    {
        public string Address { get; set; }
        public string Number { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime OpenDate { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Pharmacy()
        {
            Storages = new List<Storage>();
            Orders = new List<Order>();
        }
    }
}
