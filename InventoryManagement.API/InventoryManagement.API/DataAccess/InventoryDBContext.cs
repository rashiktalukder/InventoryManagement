using InventoryManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.API.DataAccess
{
    public class InventoryDBContext : DbContext
    {
        public InventoryDBContext(DbContextOptions<InventoryDBContext> options) : base (options)   
        {
            
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }
    }
}
