using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class MedicamentPriceHistory : BaseEntity
    {
        public int MedicamentId { get; set; }
        public decimal Price { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual Medicament Medicament { get; set; }

        public MedicamentPriceHistory()
        {
            
        }
    }
}
