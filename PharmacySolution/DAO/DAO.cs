using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Managers;
using BusinessLogic.Validators;
using Contracts;
using Contracts.Manager;
using Contracts.Repository;
using Contracts.Validation;
using Core;
using Data;
using Data.Repository;

namespace DAO
{
    public class DAO
    {
        private static DAO instance;
        private readonly DataContext _context;
        private readonly IDictionary<string, object> _repositoryDictionary;
        private readonly IDictionary<string, object> _validatorsDictionary;
        private readonly IDictionary<string, object> _managersDictionary;

        //private readonly IDictionary<string, object> _validatorsDictionary;
        
        private DAO()
        {
            _context = new DataContext();
            _repositoryDictionary = new Dictionary<string, object>
            {
                {typeof (Pharmacy).Name, new Repository<Pharmacy>(_context)},
                {typeof (Medicament).Name, new Repository<Medicament>(_context)},
                {typeof (MedicamentPriceHistory).Name, new Repository<MedicamentPriceHistory>(_context)},
                {typeof (Storage).Name, new Repository<Storage>(_context)},
                {typeof (Order).Name, new Repository<Order>(_context)},
                {typeof (OrderDetails).Name, new Repository<OrderDetails>(_context)}
            };
            
            _validatorsDictionary = new Dictionary<string, object>{
                {typeof (Pharmacy).Name, new PharmacyValidator(_repositoryDictionary[typeof (Pharmacy).Name] as IRepository<Pharmacy>)},
                {typeof (Order).Name, new OrderValidator(_repositoryDictionary[typeof (Order).Name] as IRepository<Order>)},
                {typeof (OrderDetails).Name, new OrderDetailsValidator(_repositoryDictionary[typeof (OrderDetails).Name] as IRepository<OrderDetails>)},
                {typeof (Medicament).Name, new MedicamentValidator(_repositoryDictionary[typeof (Medicament).Name] as IRepository<Medicament>)},
                {typeof (MedicamentPriceHistory).Name, new MedicamentPriceHistoryValidator(_repositoryDictionary[typeof (MedicamentPriceHistory).Name] as IRepository<MedicamentPriceHistory>)},
                {typeof (Storage).Name, new StorageValidator(_repositoryDictionary[typeof (Storage).Name] as IRepository<Storage>)}
            };

            _managersDictionary = new Dictionary<string, object>{
                {typeof (Pharmacy).Name, new Manager<Pharmacy>((IValidator<Pharmacy>)_validatorsDictionary[typeof (Pharmacy).Name], (IRepository<Pharmacy>)_repositoryDictionary[typeof (Pharmacy).Name])},
                {typeof (Order).Name, new Manager<Order>((IValidator<Order>)_validatorsDictionary[typeof (Order).Name], (IRepository<Order>)_repositoryDictionary[typeof (Order).Name])},
                {typeof (OrderDetails).Name, new Manager<OrderDetails>((IValidator<OrderDetails>)_validatorsDictionary[typeof (OrderDetails).Name], (IRepository<OrderDetails>)_repositoryDictionary[typeof (OrderDetails).Name])},
                {typeof (Medicament).Name, new Manager<Medicament>((IValidator<Medicament>)_validatorsDictionary[typeof (Medicament).Name], (IRepository<Medicament>)_repositoryDictionary[typeof (Medicament).Name])},
                {typeof (MedicamentPriceHistory).Name, new Manager<MedicamentPriceHistory>((IValidator<MedicamentPriceHistory>)_validatorsDictionary[typeof (MedicamentPriceHistory).Name], (IRepository<MedicamentPriceHistory>)_repositoryDictionary[typeof (MedicamentPriceHistory).Name])},
                {typeof (Storage).Name, new Manager<Storage>((IValidator<Storage>)_validatorsDictionary[typeof (Storage).Name], (IRepository<Storage>)_repositoryDictionary[typeof (Storage).Name])}
            };
        }

        public static DAO GetInstance()
        {
            if (instance != null)
                return instance;
            else
                instance = new DAO();
            return instance;
        }

        public IManager<T> Manager<T>() where T:class
        {
            return (IManager<T>)_managersDictionary[typeof(T).Name];
        }
    }
}
