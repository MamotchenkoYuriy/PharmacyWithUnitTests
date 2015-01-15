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
    public class MedicamentValidator : IValidator<Medicament>
    {
        private readonly IRepository<Medicament> _medicamentRepository;

        public MedicamentValidator(IRepository<Medicament> medicamentRepository)
        {
            _medicamentRepository = medicamentRepository; 
        }

        public bool IsValid(Medicament entity)
        {
            return _medicamentRepository.GetByPrimaryKey(entity.Id) == null || _medicamentRepository.Find(medicament => medicament.Name == entity.Name).FirstOrDefault() == null;
        }
    }
}
