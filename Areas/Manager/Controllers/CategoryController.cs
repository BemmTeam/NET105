using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET105;
using NET105.Entities;
using NET105.Helper;
using NET105.Interfaces;
using NET105.Models;
using Z.PagedList;

namespace NET105.Areas.Controllers
{
    [Area("Manager")]
    [Route("Manager/[controller]/[action]/{id?}")]
    [Authorize(Roles = RoleName.Admin)]

    public class CategoryController : Controller
    {
       
        private readonly ICategory repository;

        public CategoryController(ICategory repository)
        {
            this.repository = repository;
          
        }

        [TempData]
        public string Message {get;set;}

        [TempData]
        public string MessageType {get;set;}

        // GET: Category
        public async Task<IActionResult> Index(int? page , string searchString)
        {
            page??= 1;
        
            IQueryable<Category> categories =  repository.GetCategories();

            if(!string.IsNullOrEmpty(searchString)) 
            {
                categories = categories.Where(category => category.Name.ToLower().Contains(searchString.ToLower()));
                
                ViewBag.searchString = searchString;
            }
            return View (await categories.ToPagedListAsync((int)page, 5));
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var category = await repository.GetCategoryAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Name,Desc,ImageUrl,Upload")] Category category)
        {
            if (ModelState.IsValid)
            {
                if(await repository.CreateAsync(category) == true)
                {
                    Message = "Thêm danh mục thành công !";
                    MessageType = MessageHelper.success;

                    return RedirectToAction(nameof(Index));

                }
            }
            Message = "Thêm danh mục không thành công !";
            MessageType = MessageHelper.error;
            return View(category);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
             var category = await repository.FindCategoryAsync(id);
            if (category == null)
            {
                return NotFound();
            }
          
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Name,Desc,ImageUrl,Upload")] Category category)
        {
             if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               Console.WriteLine(category.Desc);
                if(await repository.EditAsync(id , category , category.Upload != null) == true)
                {
                    Message = "Cập nhật danh mục thành công !";
                    MessageType = MessageHelper.success;
                }
                return RedirectToAction(nameof(Index));
            }
            Message = "Cập nhật danh mục thất bại";
            MessageType = MessageHelper.error;
        
            return View(category);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var category = await repository.GetCategoryAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
              if(await repository.DeleteAsync(id))
            {
                Message = "Xóa danh mục thành công !";
                MessageType = MessageHelper.success;

                return RedirectToAction(nameof(Index));

            }
            Message = "Xóa danh mục  không thành công ";
            MessageType = MessageHelper.error;
            return View();
        }

       
    }
}
