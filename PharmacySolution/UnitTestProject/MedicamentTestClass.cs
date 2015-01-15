using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class MedicamentTestClass
    {
        [TestMethod]
        public void MedicamentAddNewRecordTest()
        {
            var currentCountRecords = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().Count();
            DAO.DAO.GetInstance()
                .Manager<Medicament>()
                .Add(new Medicament()
                {
                    Description = Guid.NewGuid().ToString(),
                    Name = Guid.NewGuid().ToString(),
                    Price= (decimal) 100.25,
                    SerialNumber = Guid.NewGuid().ToString() 
                });
            var newCountRecords = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().Count();
            Assert.AreEqual(currentCountRecords + 1, newCountRecords);
        }

        [TestMethod]
        public void MedicamentDeleteRecordTest()
        {
            DAO.DAO.GetInstance()
                .Manager<Medicament>()
                .Add(new Medicament()
                {
                    Description = Guid.NewGuid().ToString(),
                    Name = Guid.NewGuid().ToString(),
                    Price = (decimal)100.25,
                    SerialNumber = Guid.NewGuid().ToString()
                });

            var currentCountRecords = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().Count();
            
            var removeEntity = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().FirstOrDefault();
            if (removeEntity == null)
            {
                throw new AssertFailedException();
            }
            DAO.DAO.GetInstance().Manager<Medicament>().Remove(removeEntity);
            var newCountRecords = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().Count();
            Assert.AreEqual(currentCountRecords - 1, newCountRecords);
        }

        [TestMethod]
        public void PharmacyEditRecordTest()
        {
            DAO.DAO.GetInstance()
                .Manager<Medicament>()
                .Add(new Medicament()
                {
                    Description = Guid.NewGuid().ToString(),
                    Name = Guid.NewGuid().ToString(),
                    Price = (decimal)100.25,
                    SerialNumber = Guid.NewGuid().ToString()
                });
            var firstRecord = DAO.DAO.GetInstance().Manager<Medicament>().FindAll().FirstOrDefault();
            if (firstRecord == null)
            {
                throw new AssertFailedException();
            }
            var oldName = firstRecord.Name;
            firstRecord.Name = "TestName";
            DAO.DAO.GetInstance().Manager<Medicament>().SaveChanges();
            var changedRecord =
                DAO.DAO.GetInstance().Manager<Medicament>().Find(m => m.Name == "TestName").FirstOrDefault();
            Assert.IsNotNull(changedRecord);
            changedRecord.Name = oldName;
            DAO.DAO.GetInstance().Manager<Medicament>().SaveChanges();
            changedRecord =
                DAO.DAO.GetInstance().Manager<Medicament>().Find(m => m.Name == "TestName").FirstOrDefault();
            Assert.IsNull(changedRecord);
        }
    }
}
