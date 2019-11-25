using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreDAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=Jewerly")
        {
            base.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<JewerlyType> JewerlyTypes { get; set; }
        public DbSet<Stone> Stones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JewerlyType>()
                .HasMany(p => p.Products)
                .WithRequired(j => j.JewerlyType)
                .HasForeignKey(j => j.JewerlyType_Id);
        }

    }
}
