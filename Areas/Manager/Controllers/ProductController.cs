using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET105;
using NET105.Entities;
using NET105.Helper;
using NET105.Interface;
using Z.PagedList;

namespace NET105.Areas.Controllers
{
    [Area("Manager")]
    [Route("Manager/[controller]/[action]/{id?}")]
    public class ProductController : Controller
    {
        private readonly IProduct repository;

        
        [TempData]
        public string Message {get;set;}

        [TempData]
        public string MessageType {get;set;}
        public ProductController(IProduct _repository)
        {
           

            repository = _repository;
 
        }

        // GET: Product
        
        public async Task<IActionResult> Index(int? page , string searchString)
        {
            page??= 1;
        
            IQueryable<Product> products =  repository.GetProductsAsync();

            if(!string.IsNullOrEmpty(searchString)) 
            {
                products = products.Where(product => product.Name.ToLower().Contains(searchString.ToLower()));
                
                ViewBag.searchString = searchString;
            }
            return View (await products.ToPagedListAsync((int)page, 5));
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            
            var product = await repository.GetProductAsync(id);
            if(product is null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = repository.GetSelectListCategory(0);
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Quantity,Price,Desc,ImageUrl,Address,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                if(await repository.CreateAsync(product))
                {
                    Message = "Thêm món ăn thành công !";
                    MessageType = MessageHelper.success;

                    return RedirectToAction(nameof(Index));

                }
            }
            Message = "Thêm món ăn không thành công !";
            MessageType = MessageHelper.error;
            ViewData["CategoryId"] = repository.GetSelectListCategory(product.CategoryId);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var product = await repository.FindProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = repository.GetSelectListCategory(product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductId,Name,Quantity,Price,Desc,ImageUrl,Address,CategoryId")] Product product)
        {
            
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                if(await repository.EditAsync(id , product))
                {
                    Message = "Cập nhật thành công !";
                    MessageType = MessageHelper.success;
                }
                return RedirectToAction(nameof(Index));
            }
            Message = "Cập nhật thất bại";
            MessageType = MessageHelper.error;
            ViewData["CategoryId"] = repository.GetSelectListCategory(product.CategoryId);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var product = await repository.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if(await repository.DeleteAsync(id))
            {
                Message = "Xóa món ăn thành công !";
                MessageType = MessageHelper.success;

                return RedirectToAction(nameof(Index));

            }
            Message = "Xóa món ăn không thành công ";
            MessageType = MessageHelper.error;
            return View();
        }
    }
}
