using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Data.Mapping;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<MedicamentPriceHistory> MedicamentPriceHistories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetailses { get; set; }
        public DbSet<Storage> Storages { get; set; }

        public DataContext() : base("Data Source=YURIY-PC;Initial Catalog=PharmacyDB;Integrated Security=True")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PharmacyMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailsMap());
            modelBuilder.Configurations.Add(new StorageMap());
            modelBuilder.Configurations.Add(new MedicamentMap());
            modelBuilder.Configurations.Add(new MedicamentPriceHistoryMap());
        }
    }
}
