
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET105.Entities;

namespace NET105.Repository
{
    public class PaymentRepository : Interface.IPayment
    {
        private readonly ShopContext context;

        public PaymentRepository(ShopContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(Payment payment)
        {
             try
            {
                await context.Payments.AddAsync(payment);
                var result = await context.SaveChangesAsync();
                return result > 0;

            }
            catch
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var payment = await FindPaymentAsync(id);
                context.Payments.Remove(payment);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditAsync(Guid id, Payment payment)
        {
              try
            {
                context.Payments.Update(payment);
                var result =  await context.SaveChangesAsync();
                
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(payment.PaymentId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Payment> FindPaymentAsync(Guid? id)
        {
            return await context.Payments.FindAsync(id);
        }

        public  IQueryable<Payment> GetPayments()
        {
            return  context.Payments.Select(p => p);
        }

     
      

        public async Task<Payment> GetPaymentAsync(Guid? id)
        {
          var  payment = await context.Payments.FirstOrDefaultAsync(m => m.PaymentId == id);
          return payment;
        }

        private bool PaymentExists(Guid id)
        {
            return context.Payments.Any(e => e.PaymentId == id);
        }

    
    }
}