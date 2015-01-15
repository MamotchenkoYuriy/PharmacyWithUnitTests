using System;
using System.Linq;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class OrderDetailsesTestClass
    {
        [TestMethod]
        public void OrderDetailsesAddNewRecordTest()
        {
            var currentCountRecords = DAO.DAO.GetInstance().Manager<OrderDetails>().FindAll().Count();
            var firstMedicament = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().FirstOrDefault();
            var firstOrder = DAO.DAO.GetInstance().Manager<Order>().FindAll().FirstOrDefault();
            if (firstOrder == null || firstMedicament == null)
            {
                throw new AssertFailedException();
            }

            DAO.DAO.GetInstance().Manager<OrderDetails>().Add(
                new OrderDetails()
                {
                    Count = 10,
                    MedicamentId = firstMedicament.Id,
                    OrderId = firstOrder.Id,
                    UnitPrice = (decimal)2015.02
                });
            var newCountRecords = DAO.DAO.GetInstance().Manager<OrderDetails>().FindAll().Count();
            Assert.AreEqual(currentCountRecords + 1, newCountRecords);
        }

        [TestMethod]
        public void OrderDetailsesDeleteRecordTest()
        {
            var firstMedicament = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().FirstOrDefault();
            var firstOrder = DAO.DAO.GetInstance().Manager<Order>().FindAll().FirstOrDefault();
            if (firstOrder == null || firstMedicament == null)
            {
                throw new AssertFailedException();
            }

            DAO.DAO.GetInstance().Manager<OrderDetails>().Add(
                new OrderDetails()
                {
                    Count = 10,
                    MedicamentId = firstMedicament.Id,
                    OrderId = firstOrder.Id,
                    UnitPrice = (decimal)2015.02
                });
            var currentCountRecords = DAO.DAO.GetInstance().Manager<OrderDetails>().FindAll().Count();
            var removeEntity = DAO.DAO.GetInstance().Manager<OrderDetails>().FindAll().FirstOrDefault();
            if (removeEntity == null)
            {
                throw new AssertFailedException();
            }
            DAO.DAO.GetInstance().Manager<OrderDetails>().Remove(removeEntity);
            var newCountRecords = DAO.DAO.GetInstance().Manager<OrderDetails>().FindAll().Count();
            Assert.AreEqual(currentCountRecords - 1, newCountRecords);
        }

        [TestMethod]
        public void OrderDetailsesEditRecordTest()
        {
            var firstMedicament = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().FirstOrDefault();
            var firstOrder = DAO.DAO.GetInstance().Manager<Order>().FindAll().FirstOrDefault();
            if (firstOrder == null || firstMedicament == null)
            {
                throw new AssertFailedException();
            }

            DAO.DAO.GetInstance().Manager<OrderDetails>().Add(
                new OrderDetails()
                {
                    Count = 10,
                    MedicamentId = firstMedicament.Id,
                    OrderId = firstOrder.Id,
                    UnitPrice = (decimal)2015.02
                });
            var firstRecord = DAO.DAO.GetInstance().Manager<OrderDetails>().FindAll().FirstOrDefault();
            if (firstRecord == null)
            {
                throw new AssertFailedException();
            }
            var medicamentId = firstRecord.MedicamentId;
            var orderId = firstRecord.OrderId;

            var oldCount = firstRecord.Count;
            var newCount = 100500;
            firstRecord.Count = newCount;
            DAO.DAO.GetInstance().Manager<OrderDetails>().SaveChanges();
            var changedRecord =
                DAO.DAO.GetInstance().Manager<OrderDetails>().Find(m => m.MedicamentId == medicamentId && m.OrderId == orderId).FirstOrDefault();
            Assert.IsNotNull(changedRecord);
            Assert.AreEqual(newCount, changedRecord.Count);
            changedRecord.Count = oldCount;
            DAO.DAO.GetInstance().Manager<OrderDetails>().SaveChanges();
            changedRecord =
                DAO.DAO.GetInstance().Manager<OrderDetails>().Find(m => m.MedicamentId == medicamentId && m.OrderId == orderId).FirstOrDefault();
            if (changedRecord == null)
            {
                throw new AssertFailedException();
            }
            Assert.AreEqual(changedRecord.Count, oldCount);
        }
    }
}