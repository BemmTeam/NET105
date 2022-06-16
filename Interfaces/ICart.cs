using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using NET105.Entities;
using Z.PagedList;
namespace NET105.Interfaces
{
    public interface Icart
    {
        public IQueryable<Cart> GetCarts() ;
 
        public Task<Cart> GetCartAsync(Guid? id);
        public Task<Cart> GetViewCartAsync(Guid? id);


        public Task<bool> EditAsync(Guid id , Cart cart);

        public  Task<bool> DeleteAsync(Guid id);

        public Task<bool> CreateAsync(Cart cart);

        public Task<Cart> FindCartAsync(Guid? id);

        public Task<bool> UpdateStatusAsync(Guid? id , int Status);

        public Task<bool> AddRangeCartDetail(List<CartDetail> cartDetails);

        Task<List<Cart>> GetCartsByUserIdAsync(string id);
        public SelectList GetSelectListUsers();



    }
}