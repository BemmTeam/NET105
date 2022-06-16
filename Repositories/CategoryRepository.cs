
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET105.Entities;
using NET105.Helper;

namespace NET105.Repository
{
    public class CategoryRepository : Interfaces.ICategory
    {
        private readonly ShopContext context;

        private readonly Interfaces.IUploadHelper uploadHelper;

        public CategoryRepository(ShopContext context, Interfaces.IUploadHelper uploadHelper)
        {
            this.context = context;
            this.uploadHelper = uploadHelper;
        }

        public async Task<bool?> CreateAsync(Category category)
        {
            try
            {
                bool? upload = await uploadHelper.UploadFileAsync(category.Upload);
                if (upload is null) return null;
                else if (upload == true)
                {
                    category.ImageUrl = category.Upload.FileName;
                    await context.Categories.AddAsync(category);
                    var result = await context.SaveChangesAsync();
                    return result > 0;

                }

                return false;

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
                uploadHelper.DeleteFile(category.ImageUrl);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool?> EditAsync(int id, Category category , bool update)
        {
                try
            {
                if (update)
                {
                    bool? upload = await uploadHelper.UploadFileAsync(category.Upload);
                    if (upload is null) return null;
                    else if (upload == true)
                    {
                        // xóa file cũ đi 
                        uploadHelper.DeleteFile(category.ImageUrl);
                        // cập nhật url file mới
                        category.ImageUrl = category.Upload.FileName;

                    }
                }

                context.Categories.Update(category);
                var result = await context.SaveChangesAsync();
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
            return  context.Categories.OrderBy(p => p.Name);
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