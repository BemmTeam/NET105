using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using NET105.Entities;
using Z.PagedList;
namespace NET105.Interfaces 
{
    public interface IPayment
    {
        public IQueryable<Payment> GetPayments() ;
 
        public Task<Payment> GetPaymentAsync(Guid? id);

        public Task<bool> EditAsync(Guid id , Payment payment);

        public  Task<bool> DeleteAsync(Guid id);

        public Task<bool> CreateAsync(Payment payment);

        public Task<Payment> FindPaymentAsync(Guid? id);
  
 

    }
}