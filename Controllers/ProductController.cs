
namespace NET105.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using NET105.Interfaces;
    using Z.PagedList;
    using System;
    using System.Linq;
    using NET105.Entities;
    using System.Threading.Tasks;
    using NET105.Models;

    [Route("[action]")]
    public class ProductController : Controller
    {
        private readonly IProduct productSvc;

        public ProductController(IProduct productSvc)
        {
            this.productSvc = productSvc;
        }

        [HttpGet("/Product")]
        public async Task<IActionResult> Index(PagedListModel model)
        {
            model.Page ??= 1;
            model.PageSize ??= 6;
            ViewBag.PagedListModel = model;
            IQueryable<Product> products ;
            if (model.IdCategory != null)
                products = productSvc.GetProductsWithIdCgr((int)model.IdCategory);
          
            else
                products = productSvc.GetProductsAsync();
                
            if (!string.IsNullOrEmpty(model.SearchString))
            {
                products = products.Where(product => product.Name.ToLower().Contains(model.SearchString.ToLower()));

            }
            if (model.OrderBy != null)
            {
                products = productSvc.ProductOder(products, model.OrderBy);
            }
            return View(await products.ToPagedListAsync((int)model.Page, (int)model.PageSize));
        }

       
        public async Task<IActionResult> ProductDetail(Guid id)
        {

            var product =await productSvc.GetProductAsync(id);

            return View(product);
        }
        


    }
}