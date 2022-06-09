
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET105.Entities;

namespace NET105.Repository
{
    public class UserRepository : Interfaces.IUser
    {
        private readonly ShopContext context;

        // private readonly UserManager<User> userManager;

        public UserRepository(ShopContext context)
        {
            this.context = context;
            // this.userManager = userManager;
        }

        public async Task<bool> CreateAsync(User user)
        {
            try
            {
                await context.Users.AddAsync(user);
                var result = await context.SaveChangesAsync();
                return result > 0;

            }
            catch
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var user = await FindUserAsync(id);
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditAsync(string id, User user)
        {
            try
            {
                context.Users.Update(user);
                var result = await context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<User> FindUserAsync(string id)
        {
            return await context.Users.FindAsync(id);
        }

        public IQueryable<User> GetUsers()
        {
            return context.Users.Select(p => p);
        }




        public async Task<User> GetUserAsync(string id)
        {
            var user = await context.Users.FirstOrDefaultAsync(m => m.Id == id);
            return user;
        }

        private bool CategoryExists(int id)
        {
            return context.Categories.Any(e => e.CategoryId == id);
        }

        private bool UserExists(string id)
        {
            return context.Users.Any(e => e.Id == id);
        }

        // public async Task<bool> changePassword(string id , string password)
        // {
        //     User user = await userManager.FindByIdAsync(id);
        //     if (user == null)
        //     {
        //         return false;
        //     }
        //     user.PasswordHash = userManager.PasswordHasher.HashPassword(user,password);
        //     var result = await userManager.UpdateAsync(user);
        //     if (!result.Succeeded)
        //     {
        //       return true;

        //     }
        //     return false;
        // }
    }
}