using System;
using System.Linq;
using BusinessLogic.Validators;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class StorageTestClass
    {
        [TestMethod]
        public void StorageAddNewRecordTest()
        {
            var currentCountRecords = DAO.DAO.GetInstance().Manager<Storage>().FindAll().Count();
            var firstMedicament = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().FirstOrDefault();
            var firstPharmacy = DAO.DAO.GetInstance().Manager<Pharmacy>().FindAll().FirstOrDefault();
            if (firstPharmacy == null || firstMedicament == null)
            {
                throw new AssertFailedException();
            }
            var existingEntity = DAO.DAO.GetInstance()
                .Manager<Storage>()
                .FindAll()
                .FirstOrDefault(m => m.MedicamentId == firstMedicament.Id && m.PharmacyId == firstPharmacy.Id);
            if (existingEntity != null)
            {
                return;
            }

            DAO.DAO.GetInstance().Manager<Storage>().Add(
                new Storage()
                {
                    Count = 10,
                    MedicamentId = firstMedicament.Id,
                    PharmacyId = firstPharmacy.Id,
                });
            var newCountRecords = DAO.DAO.GetInstance().Manager<OrderDetails>().FindAll().Count();
            Assert.AreEqual(currentCountRecords + 1, newCountRecords);
        }

        [TestMethod]
        public void OrderDetailsesDeleteRecordTest()
        {
            var firstMedicament = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().FirstOrDefault();
            var firstPharmacy = DAO.DAO.GetInstance().Manager<Pharmacy>().FindAll().FirstOrDefault();
            if (firstPharmacy == null || firstMedicament == null)
            {
                throw new AssertFailedException();
            }

            DAO.DAO.GetInstance().Manager<Storage>().Add(
                new Storage()
                {
                    Count = 10,
                    MedicamentId = firstMedicament.Id,
                    PharmacyId = firstPharmacy.Id,
                });
            var currentCountRecords = DAO.DAO.GetInstance().Manager<Storage>().FindAll().Count();
            var removeEntity = DAO.DAO.GetInstance().Manager<Storage>().FindAll().FirstOrDefault();
            if (removeEntity == null)
            {
                throw new AssertFailedException();
            }
            DAO.DAO.GetInstance().Manager<Storage>().Remove(removeEntity);
            var newCountRecords = DAO.DAO.GetInstance().Manager<Storage>().FindAll().Count();
            Assert.AreEqual(currentCountRecords - 1, newCountRecords);
        }

        [TestMethod]
        public void OrderDetailsesEditRecordTest()
        {
            var firstMedicament = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().FirstOrDefault();
            var firstPharmacy = DAO.DAO.GetInstance().Manager<Pharmacy>().FindAll().FirstOrDefault();
            if (firstPharmacy == null || firstMedicament == null)
            {
                throw new AssertFailedException();
            }

            DAO.DAO.GetInstance().Manager<Storage>().Add(
                new Storage()
                {
                    Count = 10,
                    MedicamentId = firstMedicament.Id,
                    PharmacyId = firstPharmacy.Id,
                });
            var firstRecord = DAO.DAO.GetInstance().Manager<Storage>().FindAll().FirstOrDefault();
            if (firstRecord == null)
            {
                throw new AssertFailedException();
            }
            var medicamentId = firstRecord.MedicamentId;
            var pharmacyId = firstRecord.PharmacyId;

            var oldCount = firstRecord.Count;
            var newCount = 100500;
            firstRecord.Count = newCount;
            DAO.DAO.GetInstance().Manager<Storage>().SaveChanges();
            var changedRecord =
                DAO.DAO.GetInstance().Manager<Storage>().Find(m => m.MedicamentId == medicamentId && m.PharmacyId == pharmacyId).FirstOrDefault();
            Assert.IsNotNull(changedRecord);
            Assert.AreEqual(newCount, changedRecord.Count);
            changedRecord.Count = oldCount;
            DAO.DAO.GetInstance().Manager<Storage>().SaveChanges();
            changedRecord =
                DAO.DAO.GetInstance().Manager<Storage>().Find(m => m.MedicamentId == medicamentId && m.PharmacyId == pharmacyId).FirstOrDefault();
            if (changedRecord == null)
            {
                throw new AssertFailedException();
            }
            Assert.AreEqual(changedRecord.Count, oldCount);
        }
    }
}