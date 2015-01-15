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
    public class MedicamentPriceHistoryValidator : IValidator<MedicamentPriceHistory>
    {
        private readonly IRepository<MedicamentPriceHistory> _medicamentPriceHistoryRepository;

        public MedicamentPriceHistoryValidator(IRepository<MedicamentPriceHistory> medicamentPriceHistoryRepository)
        {
            _medicamentPriceHistoryRepository = medicamentPriceHistoryRepository;
        }

        public bool IsValid(MedicamentPriceHistory entity)
        {
            var medicamentPriceHistory = _medicamentPriceHistoryRepository.FindAll().Where(m => m.MedicamentId == entity.MedicamentId).Any(history => history.MedicamentId == entity.MedicamentId && history.Price == entity.Price);
            return !medicamentPriceHistory;
        }
    }
}
