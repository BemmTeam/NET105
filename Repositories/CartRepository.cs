
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET105.Entities;

namespace NET105.Repository
{
    public class CartRepository : Interfaces.Icart
    {
        private readonly ShopContext context;

        public CartRepository(ShopContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(Cart cart)
        {
             try
            {
                await context.Carts.AddAsync(cart);
                var result = await context.SaveChangesAsync();
                return result > 0;

            }
            catch
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var cart = await FindCartAsync(id);
                context.Carts.Remove(cart);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditAsync(Guid id, Cart cart)
        {
              try
            {
                context.Carts.Update(cart);
                var result =  await context.SaveChangesAsync();
                
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(cart.CartId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Cart> FindCartAsync(Guid? id)
        {
            return await context.Carts.FindAsync(id);
        }

        public IQueryable<Cart> GetCarts()
        {
            return  context.Carts.Include(c => c.Payment).Include(c => c.User);
        }

     
      

        public async Task<Cart> GetCartAsync(Guid? id)
        {
          var  cart = await context.Carts.Include(m => m.Payment).Include(m => m.User).FirstOrDefaultAsync(m => m.CartId == id);
          return cart;
        }

        private bool CartExists(Guid id)
        {
            return context.Carts.Any(e => e.CartId == id);
        }

        public SelectList GetSelectListUsers()
        {
            return new SelectList(context.Users, "Id", "Id");

        }

        public SelectList GetSelectListPayments()
        {
          return new SelectList(context.Payments, "PaymentId", "Name");

        }
    }
}