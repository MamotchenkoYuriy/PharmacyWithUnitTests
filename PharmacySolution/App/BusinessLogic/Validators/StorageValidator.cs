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
    public class StorageValidator: IValidator<Storage>
    {
        private readonly IRepository<Storage> _storageRepository = null;

        public StorageValidator(IRepository<Storage> storageRepository)
        {
            _storageRepository = storageRepository;
        }
        public bool IsValid(Storage entity)
        {
            return
                _storageRepository.FindAll()
                    .FirstOrDefault(m => m.MedicamentId == entity.MedicamentId && m.PharmacyId == entity.PharmacyId) ==
                null;
        }
    }
}
