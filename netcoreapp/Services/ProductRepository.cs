using Microsoft.EntityFrameworkCore;
using netcoreapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoreapp.Services
{
    public class ProductRepository : IRepository<Product, int>
    {

        private readonly CoreFisContext context;
        // DI for CoreFisContext class
        public ProductRepository(CoreFisContext context)
        {
            this.context = context;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            var result = await context.Products.AddAsync(entity);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var prd = await context.Products.FindAsync(id);
            if (prd == null)
            {
                return false;
            }
            context.Products.Remove(prd);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<Product> UpdateAsync(int id, Product entity)
        {
            var prd = await context.Products.FindAsync(id);
            if (prd != null)
            {
                prd.ProductId = entity.ProductId;
                prd.ProductName = entity.ProductName;
                prd.Manufacturer = entity.Manufacturer;
                prd.Price = entity.Price;
                prd.CategoryRowId = entity.CategoryRowId;
                await context.SaveChangesAsync();
            }
            return prd;             
        }
    }
}
