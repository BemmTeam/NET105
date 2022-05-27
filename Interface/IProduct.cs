using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using NET105.Entities;
using Z.PagedList;
namespace NET105.Interface 
{
    public interface IProduct
    {
        public IQueryable<Product> GetProductsAsync() ;
 
        public Task<Product> GetProductAsync(Guid? id);

        public Task<bool> EditAsync(Guid id , Product product);

        public  Task<bool> DeleteAsync(Guid id);

        public Task<bool> CreateAsync(Product product);

        public Task<Product> FindProductAsync(Guid? id);
  
        public SelectList GetSelectListCategory(int CategoryId); 

    }
}