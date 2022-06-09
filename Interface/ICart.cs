using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using NET105.Entities;
using Z.PagedList;
namespace NET105.Interface 
{
    public interface Icart
    {
        public IQueryable<Cart> GetCarts() ;
 
        public Task<Cart> GetCartAsync(Guid? id);

        public Task<bool> EditAsync(Guid id , Cart cart);

        public  Task<bool> DeleteAsync(Guid id);

        public Task<bool> CreateAsync(Cart cart);

        public Task<Cart> FindCartAsync(Guid? id);

        public SelectList GetSelectListUsers();

        public SelectList GetSelectListPayments();


    }
}