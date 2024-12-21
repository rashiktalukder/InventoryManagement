using InventoryManagement.API.DataAccess;
using InventoryManagement.API.Models;
using InventoryManagement.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.API.Repositories.Service
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryDBContext context;

        public ProductRepository(InventoryDBContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var prodObj = await context.Products.FindAsync(id);
            if(prodObj!=null)
            {
                context.Products.Remove(prodObj);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products.Include(x=>x.Warehouse).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Products.Include(x=>x.Warehouse).FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task UpdateAsync(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
