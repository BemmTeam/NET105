
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NET105.Entities;
using NET105.Interface;
using NET105.Models;

namespace NET105.Repository
{
    public class CartDetailRepository : Interface.ICartDetail
    {
        private readonly IProduct productSvc ;

        public ISession Session {get;set;}


        public CartDetailRepository(IProduct productSvc)
        {
            this.productSvc = productSvc;
        }

      

        public async Task<DataJsonResult> AddCartAsync(ISession Session,Guid id, int quantity)
        {
            var product = await productSvc.FindProductAsync(id);
            float price = product.Price;
            CartDetail cart = null;
            var carts = SessionHelper.GetObjectFormJson<List<CartDetail>>(Session,"carts");
            try
            {

                if (carts == null)
                {
                    carts = new List<CartDetail>();
                    carts.Add(cart = new() { CartDetailId = Guid.NewGuid().ToString(), ProductId = product.ProductId, Product = product, Quantity = quantity, Price = price });
                }
                else
                {
                    int index = FindProduct(Session,id);
                    if (index != -1)
                    {
                        cart = new();
                        cart = carts[index];
                        carts[index].Quantity += quantity;

                    }

                    else
                    {
                        carts.Add(cart = new() { CartDetailId = Guid.NewGuid().ToString(), ProductId = product.ProductId, Product = product, Quantity = quantity, Price = price });
                    }
                }
                SessionHelper.SetObjectAsJson(Session,"carts", carts);
            }
            catch (Exception e)
            {
                return new DataJsonResult { IsSuccess = false, Message = e.ToString(), Data = cart };
            }
            return new DataJsonResult { IsSuccess = true, Message = "Thêm vào giỏ hàng thành công", Data = cart };
        }

        private int FindCart(ISession Session,Guid Id)
        {
             var carts = SessionHelper.GetObjectFormJson<List<CartDetail>>(Session, "carts");

            if (carts != null)
            {
                for (var i = 0; i < carts.Count; i++)
                {
                    if (carts[i].CartDetailId == Id.ToString())
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private int FindProduct(ISession Session,Guid Id)
        {
            var carts = SessionHelper.GetObjectFormJson<List<CartDetail>>(Session, "carts");

            if (carts != null)
            {
                for (var i = 0; i < carts.Count; i++)
                {
                    if (carts[i].Product.ProductId == Id)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public List<CartDetail> GetCarts(ISession Session)
        {
            var carts = SessionHelper.GetObjectFormJson<List<CartDetail>>(Session, "carts");
            return carts;
        }


        public DataJsonResult Remove(ISession Session,Guid id)
        {
            List<CartDetail> carts = SessionHelper.GetObjectFormJson<List<CartDetail>>(Session, "carts");
            int index = FindCart(Session,id);
            carts.RemoveAt(index);

            SessionHelper.SetObjectAsJson(Session, "carts", carts);
            return new DataJsonResult
            {
                Message = "Xóa thành công !",
                IsSuccess = true
            };
        }

      
    }
}