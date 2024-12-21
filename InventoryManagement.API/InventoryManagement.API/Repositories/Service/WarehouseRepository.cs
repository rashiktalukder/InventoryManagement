using InventoryManagement.API.DataAccess;
using InventoryManagement.API.Models;
using InventoryManagement.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.API.Repositories.Service
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly InventoryDBContext context;

        public WarehouseRepository(InventoryDBContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Warehouse warehouse)
        {
            context.Warehouses.Add(warehouse);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var warehouse = context.Warehouses.FirstOrDefault(w => w.Id == id);
            if (warehouse != null)
            {
                context.Warehouses.Remove(warehouse);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await context.Warehouses.Include(x=>x.Products).ToListAsync();
        }

        public async Task<Warehouse> GetByIdAsync(int id)
        {
            return await context.Warehouses.Include(x => x.Products).FirstOrDefaultAsync(w=>w.Id==id);
        }

        public async Task UpdateAsync(Warehouse warehouse)
        {
            context.Warehouses.Update(warehouse);
            await context.SaveChangesAsync();
        }
    }
}
