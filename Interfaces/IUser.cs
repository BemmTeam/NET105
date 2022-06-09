using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using NET105.Entities;
using Z.PagedList;
namespace NET105.Interfaces 
{
    public interface IUser
    {
        public IQueryable<User> GetUsers() ;
 
        public Task<User> GetUserAsync(string id);

        public Task<bool> EditAsync(string id , User user );

        public Task<bool> CreateAsync(User user);

        public Task<User> FindUserAsync(string id);

        // public  Task<bool> changePassword(string id , string password);

 

    }
}