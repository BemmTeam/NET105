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
using NET105.Interfaces;
using Z.PagedList;
using Microsoft.AspNetCore.Authorization;
using NET105.Models;

namespace NET105.Areas.Controllers
{
    [Area("Manager")]
    [Route("Manager/[controller]/[action]/{id?}")]
    [Authorize(Roles = RoleName.Admin)]
    public class CartController : Controller
    {
        private readonly Icart repository;

        public CartController(Icart repository)
        {
            this.repository = repository;
        }
        [TempData]
        public string Message { get; set; }

        [TempData]
        public string MessageType { get; set; }

        // GET: Cart
        public async Task<IActionResult> Index(int? page, DateTime? searchDate)
        {
            page ??= 1;

            IQueryable<Cart> carts = repository.GetCarts();

            if (searchDate != null)
            {
                carts = carts.Where(category => category.CreatedDate <= searchDate);

                ViewBag.searchString = searchDate;
            }
            return View(await carts.ToPagedListAsync((int)page, 5));
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var cart = await repository.GetCartAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            ViewData["PaymentId"] = repository.GetSelectListPayments();
            ViewData["UserId"] = repository.GetSelectListUsers();
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,CreatedDate,Completed,Address,Status,CartDetail_Json,UserId,PaymentId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                if (await repository.CreateAsync(cart))
                {
                    Message = "Thêm giỏ hàng thành công !";
                    MessageType = MessageHelper.success;

                    return RedirectToAction(nameof(Index));

                }
            }
            Message = "Thêm giỏ hàng không thành công !";
            MessageType = MessageHelper.error;
            ViewData["PaymentId"] = repository.GetSelectListPayments();
            ViewData["UserId"] = repository.GetSelectListUsers();
            return View(cart);
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {


            var cart = await repository.FindCartAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["PaymentId"] = repository.GetSelectListPayments();
            ViewData["UserId"] = repository.GetSelectListUsers();
            return View(cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CartId,CreatedDate,Completed,Address,Status,CartDetail_Json,UserId,PaymentId")] Cart cart)
        {
            if (id != cart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (await repository.EditAsync(id, cart))
                {
                    Message = "Cập nhật giỏ hàng thành công !";
                    MessageType = MessageHelper.success;
                }
                return RedirectToAction(nameof(Index));
            }
            Message = "Cập nhật giỏ hàng thất bại";
            MessageType = MessageHelper.error;

            ViewData["PaymentId"] = repository.GetSelectListPayments();
            ViewData["UserId"] = repository.GetSelectListUsers();
            return View(cart);
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {


            var cart = await repository.GetCartAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if(await repository.DeleteAsync(id))
            {
                Message = "Xóa giỏ hàng thành công !";
                MessageType = MessageHelper.success;

                return RedirectToAction(nameof(Index));

            }
            Message = "Xóa giỏ hàng  không thành công ";
            MessageType = MessageHelper.error;
            return View();
        }


    }
}
