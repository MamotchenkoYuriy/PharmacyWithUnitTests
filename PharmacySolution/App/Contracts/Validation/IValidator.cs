using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Validation
{
    public interface IValidator<in T> where T : class 
    {
        bool IsValid(T entity);
    }
}
