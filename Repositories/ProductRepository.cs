
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET105.Entities;
using NET105.Interface;
using Z.PagedList;

namespace NET105.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly ShopContext context;

        public ProductRepository(ShopContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(Product product)
        {
            product.ProductId = Guid.NewGuid();
            try
            {
                await context.AddAsync(product);
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
                var product = await FindProductAsync(id);
                Console.WriteLine("Product is null ? : "  + product==null );
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditAsync(Guid id, Product product)
        {
           
            try
            {
                context.Update(product);
                var result =  await context.SaveChangesAsync();
                
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Product> FindProductAsync(Guid? id)
        {
            if (id is null) return null;
            return await context.Products.FindAsync(id);
        }

        public async Task<Product> GetProductAsync(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var product = await context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            return product;
        }

        public IQueryable<Product> GetProductsAsync()
        {
            IQueryable<Product> product = context.Products.Include(p => p.Category);

            return product;
        }

        public SelectList GetSelectListCategory(int CategoryId = 0)
        {
            if(CategoryId == 0) 
            return new SelectList(context.Categories, "CategoryId", "Name");

            return new SelectList(context.Categories, "CategoryId", "Name", CategoryId);
        }

        private bool ProductExists(Guid id)
        {
            return context.Products.Any(e => e.ProductId == id);
        }

    }
}