using Microsoft.EntityFrameworkCore;
using PMA.Store_Domain.Categories.Entities;
using PMA.Store_Domain.Customers.Entities;
using PMA.Store_Domain.Masters.Entities;
using PMA.Store_Domain.Orders.Entities;
using PMA.Store_Domain.Photos.Entities;

namespace PMA.Store_Infrastructures
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions opt) : base(opt)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<MasterProduct> MasterProducts { get; set; }
        public DbSet<MasterProductPhoto> MasterProductPhotos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        }
    }
}