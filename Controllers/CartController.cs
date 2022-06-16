

namespace NET105.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
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
        private readonly IAccount accountSvc;

        private readonly Icart cartSvc;

        private readonly IEmailSender emailSender;

        public CartController(ICartDetail cartDetailSvc, IAccount accountSvc, Icart cartSvc, IEmailSender emailSender)
        {
            this.cartDetailSvc = cartDetailSvc;
            this.accountSvc = accountSvc;
            this.cartSvc = cartSvc;
            this.emailSender = emailSender;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var carts = cartDetailSvc.GetCarts(HttpContext.Session);
            if (carts != null)
            {
                ViewData["Total"] = carts.Sum(c => c.Price * c.Quantity);
                var user = await accountSvc.GetUserAsync(User);
                ViewData["FullName"] = user.FullName;
                ViewData["Email"] = user.Email;
                ViewData["Address"] = user.Address;
                carts.ForEach(p => p.Total = p.Price * p.Quantity);
            }
            return View(carts);
        }


        public async Task<IActionResult> CheckOut()
        {
            var user = await accountSvc.GetUserAsync(User);

            var cartDetails = SessionHelper.GetObjectFormJson<List<CartDetail>>(HttpContext.Session, "carts");
            var cart = new Cart()
            {
                CartId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Address = user.Address,
                UserId = user.Id,
                Status = Cart.StatusType.Shipping,
                Total = cartDetails.Sum(c => c.Price)
            };
            // add cartDetailt từ sesion 
            cartDetails.ForEach(p => { p.CartId = cart.CartId; p.Product = null; });
            await cartSvc.CreateAsync(cart);
            await cartSvc.AddRangeCartDetail(cartDetails);
            HttpContext.Session.Clear();
            var callbackUrl = Url.ActionLink(
            action: "View",
            controller: "Cart",
            values: new
            {
                id = cart.CartId,
            }, protocol: Request.Scheme
            );
            await emailSender.SendEmailAsync(user.Email, "Thông tin hóa đơn",
             $"Bạn đã đặt món thành công tại shop Food nhấn vào  <a href='{callbackUrl}'>xem chi tiết</a> để theo dõi đơn hàng");

            return View("View", await cartSvc.GetViewCartAsync(cart.CartId));
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid? id)
        {

            var cart = await cartSvc.GetViewCartAsync(id);
            return View(cart);
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


        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> History()
        {
           var user = await accountSvc.GetUserAsync(User);
           ViewData["Name"] = user.FullName;
           var carts = await cartSvc.GetCartsByUserIdAsync(user.Id);
           
           return View(carts);
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