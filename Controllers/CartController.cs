

namespace NET105.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NET105.Entities;
    using NET105.Interfaces;
    using NET105.Models;

    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        private readonly ICartDetail cartDetailSvc;

        public CartController(ICartDetail _cartDetailSvc)
        {
            this.cartDetailSvc = _cartDetailSvc;
        }

        public IActionResult Index()
        {
            var carts = cartDetailSvc.GetCarts(HttpContext.Session);
            if(carts != null) {
                ViewData["Total"] = carts.Sum(c => c.Price * c.Quantity);
                carts.ForEach(p => p.Total = p.Price * p.Quantity);
            }
            return View(carts);
        }

        [HttpGet]
        public IActionResult Carts()
        {
            var carts = cartDetailSvc.GetCarts(HttpContext.Session);
            return Json(new DataJsonResult()
            {
                Message = "Lấy danh sách giỏ hàng thành công!",
                IsSuccess = true,
                Data = carts
            });

        }



        [HttpPost]
        public async Task<IActionResult> Add(Guid id, int quantity)
        {
            return Json(await cartDetailSvc.AddCartAsync(HttpContext.Session, id, quantity));
        }

        [HttpDelete]
        public IActionResult Remove(Guid id)
        {

            return Json(cartDetailSvc.Remove(HttpContext.Session, id));
        }

    }
}