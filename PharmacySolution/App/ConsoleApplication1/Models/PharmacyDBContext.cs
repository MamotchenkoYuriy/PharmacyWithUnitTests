using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ConsoleApplication1.Models.Mapping;

namespace ConsoleApplication1.Models
{
    public partial class PharmacyDBContext : DbContext
    {
        static PharmacyDBContext()
        {
            Database.SetInitializer<PharmacyDBContext>(null);
        }

        public PharmacyDBContext()
            : base("Name=PharmacyDBContext")
        {
        }

        public DbSet<MedicamentPriceHistory> MedicamentPriceHistories { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MedicamentPriceHistoryMap());
            modelBuilder.Configurations.Add(new MedicamentMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new PharmacyMap());
            modelBuilder.Configurations.Add(new StorageMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
