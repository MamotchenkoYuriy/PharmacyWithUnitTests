using System;
using System.CodeDom;
using System.Linq;
using Core;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class MedicamentPriceHistoryTestClass
    {
        [TestMethod]
        public void MedicamentPriceHistoryAddNewRecordTest()
        {
            var firstMedicament = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().FirstOrDefault();
            if (firstMedicament == null) {throw new AssertFailedException();}
            var currentCountRecords = DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().FindAll().Count();
            DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().Add(
                new MedicamentPriceHistory()
                {
                    Medicament = firstMedicament, 
                    ModifiedDate = DateTime.Now, 
                    Price = new Random().Next(100500)
                });
            var newCountRecords = DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().FindAll().Count();
            Assert.AreEqual(currentCountRecords + 1, newCountRecords);
        }

        [TestMethod]
        public void MedicamentPriceHistoryDeleteRecordTest()
        {
            var firstMedicament = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().FirstOrDefault();
            if (firstMedicament == null) { throw new AssertFailedException(); }
            DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().Add(
                new MedicamentPriceHistory()
                {
                    Medicament = firstMedicament,
                    ModifiedDate = DateTime.Now,
                    Price = new Random().Next(100500)
                });
            var currentCountRecords = DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().FindAll().Count();
            var removeEntity = DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().FindAll().FirstOrDefault();
            if (removeEntity == null)
            {
                throw new AssertFailedException();
            }
            DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().Remove(removeEntity);
            var newCountRecords = DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().FindAll().Count();
            Assert.AreEqual(currentCountRecords - 1, newCountRecords);
        }

        [TestMethod]
        public void MedicamentPriceHistoryEditRecordTest()
        {
            var firstRecord = DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().FindAll().FirstOrDefault();
            if (firstRecord == null) { throw new AssertFailedException();}
            var id = firstRecord.Id;
            var oldPrice = firstRecord.Price;
            var newPrice = new Random().Next(100500);
            firstRecord.Price = newPrice;
            DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().SaveChanges();
            var changedRecord =
                DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().Find(m => m.Id == id && 
                    m.Price == newPrice).FirstOrDefault();
            Assert.IsNotNull(changedRecord);
            changedRecord.Price = oldPrice;
            DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().SaveChanges();
            changedRecord =
                DAO.DAO.GetInstance().Manager<MedicamentPriceHistory>().Find(m => m.Id == id &&
                    m.Price == newPrice).FirstOrDefault();
            Assert.IsNull(changedRecord);
        }
    }
}
