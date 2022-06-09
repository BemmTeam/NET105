using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NET105.Entities;
using NET105.Models;

namespace NET105.Interface

{

    public interface ICartDetail 
    {
        List<CartDetail> GetCarts(ISession Session) ;

        Task<DataJsonResult> AddCartAsync(ISession Session,Guid id, int quantity) ;

        DataJsonResult Remove(ISession Session, Guid id);




    }
}