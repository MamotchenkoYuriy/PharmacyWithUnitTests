using System;
using System.Linq;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class OrderTestClass
    {
        /*Я так думаю что Order ни в коем случае изменяться не будет, разве что удаляться
         * Поэтому метод изменения не вижу смысла писать
         * Ну ради прикола напишу что изменилась дата :-) 
         */

        [TestMethod]
        public void OrderAddNewRecordTest()
        {
            var currentCountRecords = DAO.DAO.GetInstance().Manager<Order>().FindAll().Count();
            var firstPharmacy = DAO.DAO.GetInstance().Manager<Pharmacy>().FindAll().FirstOrDefault();
            if(firstPharmacy==null){throw new AssertFailedException();}
            DAO.DAO.GetInstance()
                .Manager<Order>()
                .Add(new Order()
                {
                    OperationDate = DateTime.Now,
                    OperationType = OperationType.Purchase,
                    Pharmacy = firstPharmacy
                });
            var newCountRecords = DAO.DAO.GetInstance().Manager<Order>().FindAll().Count();
            Assert.AreEqual(currentCountRecords + 1, newCountRecords);
        }

        [TestMethod]
        public void OrderDeleteRecordTest()
        {
            var firstPharmacy = DAO.DAO.GetInstance().Manager<Pharmacy>().FindAll().FirstOrDefault();
            DAO.DAO.GetInstance()
                .Manager<Order>()
                .Add(new Order()
                {
                    OperationDate = DateTime.Now,
                    OperationType = OperationType.Purchase,
                    Pharmacy = firstPharmacy
                });
            var currentCountRecords = DAO.DAO.GetInstance().Manager<Order>().FindAll().Count();
            var removeEntity = DAO.DAO.GetInstance().Manager<Order>().FindAll().FirstOrDefault();
            if (removeEntity == null)
            {
                throw new AssertFailedException();
            }
            DAO.DAO.GetInstance().Manager<Order>().Remove(removeEntity);
            var newCountRecords = DAO.DAO.GetInstance().Manager<Order>().FindAll().Count();
            Assert.AreEqual(currentCountRecords - 1, newCountRecords);
        }
        [TestMethod]
        public void OrderEditRecordTest()
        {
            var firstPharmacy = DAO.DAO.GetInstance().Manager<Pharmacy>().FindAll().FirstOrDefault();
            DAO.DAO.GetInstance()
                .Manager<Order>()
                .Add(new Order()
                {
                    OperationDate = DateTime.Now,
                    OperationType = OperationType.Purchase,
                    Pharmacy = firstPharmacy
                });
            var firstRecord = DAO.DAO.GetInstance().Manager<Order>().FindAll().FirstOrDefault();
            if (firstRecord == null)
            {
                throw new AssertFailedException();
            }
            var id = firstRecord.Id;
            var oldDate = firstRecord.OperationDate;
            var newDate = DateTime.Now;
            firstRecord.OperationDate = newDate;
            DAO.DAO.GetInstance().Manager<Order>().SaveChanges();
            var changedRecord =
                DAO.DAO.GetInstance().Manager<Order>().Find(m => m.Id == id).FirstOrDefault();
            Assert.IsNotNull(changedRecord);
            Assert.AreEqual(newDate, changedRecord.OperationDate);
            changedRecord.OperationDate = oldDate;
            DAO.DAO.GetInstance().Manager<Order>().SaveChanges();
            changedRecord =
                DAO.DAO.GetInstance().Manager<Order>().Find(m => m.OperationDate == oldDate).FirstOrDefault();
            if (changedRecord == null)
            {
                throw new AssertFailedException();
            }
            Assert.AreEqual(changedRecord.OperationDate, oldDate);
        }
    }
}
