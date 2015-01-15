using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repository;
using Contracts.Validation;
using Core;

namespace BusinessLogic.Validators
{
    public class OrderDetailsValidator: IValidator<OrderDetails>
    {
        private readonly IRepository<OrderDetails> _orderDetailsRepository = null;
        public OrderDetailsValidator(IRepository<OrderDetails> orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }
        
        public bool IsValid(OrderDetails entity)
        {
            return
                _orderDetailsRepository.FindAll().FirstOrDefault(m => m.MedicamentId == entity.MedicamentId && m.OrderId == entity.OrderId) == null;
        }
    }
}
