using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using NET105.Entities;
using Z.PagedList;
namespace NET105.Interface 
{
    public interface ICategory
    {
        public IQueryable<Category> GetCategories() ;
 
        public Task<Category> GetCategoryAsync(int? id);

        public Task<bool?> EditAsync(int id , Category category, bool update);

        public  Task<bool> DeleteAsync(int id);

        public Task<bool?> CreateAsync(Category category);

        public Task<Category> FindCategoryAsync(int? id);
  
 

    }
}