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
    public class OrderValidator:IValidator<Order>
    {
        private readonly IRepository<Order> _orderRepository = null;
        public OrderValidator(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public bool IsValid(Order entity)
        {
            return _orderRepository.Find(m => m.Id == entity.Id).FirstOrDefault() == null;
        }
    }
}
