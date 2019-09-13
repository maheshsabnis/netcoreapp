using Microsoft.EntityFrameworkCore;
using netcoreapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoreapp.Services
{
    public class CategoryRepository : IRepository<Category, int>
    {

        private readonly CoreFisContext context;
        // DI for CoreFisContext class
        public CategoryRepository(CoreFisContext context)
        {
            this.context = context;
        }

        public async Task<Category> CreateAsync(Category entity)
        {
            var result = await context.Categories.AddAsync(entity);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cat = await context.Categories.FindAsync(id);
            if (cat == null)
            {
                return false;
            }
            context.Categories.Remove(cat);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task<Category> UpdateAsync(int id, Category entity)
        {
            var cat = await context.Categories.FindAsync(id);
            if (cat != null)
            {
                cat.CategoryId = entity.CategoryId;
                cat.CategoryName = entity.CategoryName;
                cat.BasePrice = entity.BasePrice;
                await context.SaveChangesAsync();
            }
            return cat;             
        }
    }
}
