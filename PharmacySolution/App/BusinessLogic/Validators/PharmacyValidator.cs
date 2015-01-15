using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repository;
using Contracts.Validation;
using Core;
using Data;

namespace BusinessLogic.Validators
{
    public class PharmacyValidator: IValidator<Pharmacy>
    {
        private readonly IRepository<Pharmacy> _pharmacyRepository;
        public PharmacyValidator(IRepository<Pharmacy> pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }
        public bool IsValid(Pharmacy entity)
        {
            return
                _pharmacyRepository.FindAll().FirstOrDefault(m => m.Number == entity.Number 
                    || m.PhoneNumber == entity.PhoneNumber ||
                    m.Address == entity.Address) == null;
        }
    }
}
