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

    public class PaymentController : Controller
    {
        private readonly IPayment repository;

        public PaymentController(IPayment repository)
        {
            this.repository = repository;
        }
        [TempData]
        public string Message { get; set; }

        [TempData]
        public string MessageType { get; set; }
        // GET: Payment
        public async Task<IActionResult> Index(int? page, string searchString)
        {
            page ??= 1;

            IQueryable<Payment> payments = repository.GetPayments();

            if (!string.IsNullOrEmpty(searchString))
            {
                payments = payments.Where(category => category.Name.ToLower().Contains(searchString.ToLower()));

                ViewBag.searchString = searchString;
            }
            return View(await payments.ToPagedListAsync((int)page, 5));
        }

        // GET: Payment/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {

            var payment = await repository.GetPaymentAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,Name")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                if (await repository.CreateAsync(payment))
                {
                    Message = "Thêm thanh toán thành công !";
                    MessageType = MessageHelper.success;

                    return RedirectToAction(nameof(Index));

                }
            }
            Message = "Thêm thanh toán không thành công !";
            MessageType = MessageHelper.error;
            return View(payment);
        }

        // GET: Payment/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var payment = await repository.FindPaymentAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PaymentId,Name")] Payment payment)
        {
            if (id != payment.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (await repository.EditAsync(id, payment))
                {
                    Message = "Cập nhật thanh toán thành công !";
                    MessageType = MessageHelper.success;
                }
                return RedirectToAction(nameof(Index));
            }
            Message = "Cập nhật thanh toán thất bại";
            MessageType = MessageHelper.error;

            return View(payment);
        }

        // GET: Payment/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var category = await repository.GetPaymentAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
               if(await repository.DeleteAsync(id))
            {
                Message = "Xóa thanh toán thành công !";
                MessageType = MessageHelper.success;

                return RedirectToAction(nameof(Index));

            }
            Message = "Xóa thanh toán  không thành công ";
            MessageType = MessageHelper.error;
            return View();
        }

    }
}
