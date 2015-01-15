using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Core
{
    public class BaseEntity : IDbEntity
    {
        public int Id { get; set; }

        public BaseEntity()
        {
            
        }
    }
}
