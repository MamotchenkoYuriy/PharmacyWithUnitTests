using System;
using System.Linq;
using Core;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class PharmacyTestClass
    {
        [TestMethod]
        public void PharmacyAddNewRecordTest()
        {
            var currentCountRecords = DAO.DAO.GetInstance().Manager<Pharmacy>().FindAll().Count();
            DAO.DAO.GetInstance().Manager<Pharmacy>().Add(new Pharmacy() { Address = Guid.NewGuid().ToString(), Number = Guid.NewGuid().ToString(), OpenDate = DateTime.Now, PhoneNumber = Guid.NewGuid().ToString() });
            var newCountRecords = DAO.DAO.GetInstance().Manager<Pharmacy>().FindAll().Count();
            Assert.AreEqual(currentCountRecords + 1, newCountRecords);
        }

        [TestMethod]
        public void PharmacyDeleteRecordTest()
        {
            DAO.DAO.GetInstance().Manager<Pharmacy>().Add(new Pharmacy() { Address = Guid.NewGuid().ToString(), Number = Guid.NewGuid().ToString(), OpenDate = DateTime.Now, PhoneNumber = Guid.NewGuid().ToString() });
            var currentCountRecords = DAO.DAO.GetInstance().Manager<Pharmacy>().FindAll().Count();
            var removeEntity = DAO.DAO.GetInstance().Manager<Pharmacy>().FindAll().FirstOrDefault();
            if (removeEntity == null)
            {
                throw new AssertFailedException();
            }
            DAO.DAO.GetInstance().Manager<Pharmacy>().Remove(removeEntity);
            var newCountRecords = DAO.DAO.GetInstance().Manager<Pharmacy>().FindAll().Count();
            Assert.AreEqual(currentCountRecords - 1, newCountRecords);
        }

        [TestMethod]
        public void PharmacyEditRecordTest()
        {
            var firstRecord = DAO.DAO.GetInstance().Manager<Pharmacy>().FindAll().FirstOrDefault();
            if (firstRecord == null) { throw new AssertFailedException();}
            var oldNumber = firstRecord.Number;
            firstRecord.Number = "TestNumber";
            DAO.DAO.GetInstance().Manager<Pharmacy>().SaveChanges();
            var changedRecord =
                DAO.DAO.GetInstance().Manager<Pharmacy>().Find(m => m.Number == "TestNumber").FirstOrDefault();
            Assert.IsNotNull(changedRecord);
            changedRecord.Number = oldNumber;
            DAO.DAO.GetInstance().Manager<Pharmacy>().SaveChanges();
            changedRecord =
                DAO.DAO.GetInstance().Manager<Pharmacy>().Find(m => m.Number == "TestNumber").FirstOrDefault();
            Assert.IsNull(changedRecord);
        }
    }
}
