
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET105.Entities;

namespace NET105.Repository
{
    public class CategoryRepository : Interface.ICategory
    {
        private readonly ShopContext context;

        public CategoryRepository(ShopContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(Category category)
        {
             try
            {
                await context.Categories.AddAsync(category);
                var result = await context.SaveChangesAsync();
                return result > 0;

            }
            catch
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var category = await FindCategoryAsync(id);
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditAsync(int id, Category category)
        {
              try
            {
                context.Categories.Update(category);
                var result =  await context.SaveChangesAsync();
                
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.CategoryId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Category> FindCategoryAsync(int? id)
        {
            return await context.Categories.FindAsync(id);
        }

        public  IQueryable<Category> GetCategories()
        {
            return  context.Categories.Select(p => p);
        }

     
      

        public async Task<Category> GetCategoryAsync(int? id)
        {
          var  category = await context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);
          return category;
        }

         private bool CategoryExists(int id)
        {
            return context.Categories.Any(e => e.CategoryId == id);
        }
    }
}