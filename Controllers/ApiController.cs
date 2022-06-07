

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
    using NET105.Interface;
    using NET105.Models;

    [ApiController]
    [Route("Api/[action]")]

    public class ApiController : Controller
    {
        private readonly ICategory categorySvc;
        private readonly IProduct productSvc;

        public ApiController(ICategory categorySvc, IProduct productSvc)
        {
            this.categorySvc = categorySvc;
            this.productSvc = productSvc;
        }


        [HttpGet]
        public  IActionResult Carts()
        {
            
            var carts = SessionHelper.GetObjectFormJson<List<CartDetail>>(HttpContext.Session, "carts");
          
            if(carts != null)
            {
                 ViewBag.total = carts.Sum( x=> x.Product.Price * x.Quantity);
            } 
            else
            {
               carts = new();
            }
            return Ok(carts);
        }   


        private  int  FindCart(Guid Id)
        {
            var carts = SessionHelper.GetObjectFormJson<List<CartDetail>>(HttpContext.Session, "carts");

            if(carts != null)
            {
                for(var i = 0; i < carts.Count ; i++)
                {
                    if(carts[i].Product.ProductId == Id)
                    {
                        return i;
                    }
                }
            } 
            return -1;
        }   

        [HttpPost]
        public async Task<IActionResult> Carts(Guid id , int quantity)
        {
        
            var product = await productSvc.FindProductAsync(id);
            CartDetail cart = null;
            var carts = SessionHelper.GetObjectFormJson<List<CartDetail>>(HttpContext.Session, "carts");
            try
            {
          
            if( carts == null)
            {
                carts = new List<CartDetail>();
                carts.Add(cart = new() {Product = product , Quantity = quantity});
            }
            else 
            {
                int index = FindCart(id);
                if(index != -1)
                {
                    cart = new() ;
                    cart = carts[index];
                    carts[index].Quantity += quantity;

                }   
                
                else
                {
                    carts.Add(cart = new() {Product = product , Quantity = quantity});
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session,"carts" , carts);
            }catch(Exception e)
            {
                return Ok(new{Success = false , Message = e.ToString() , CartItem = cart});
            }
            return Ok(new{Success = true, Message ="Thêm vào giỏ hàng thành công" , CartItem = cart});
        }
 
    }
}