using Microsoft.EntityFrameworkCore;
using UberSystem.Data;
using UberSystem.DTOs.payments;
using UberSystem.Model;
using UberSystem.Repo.Interface;

namespace UberSystem.Repo.Impelementation
{
    public class PaymentDTo : Genaricepo<Payment>, IpaymentDTo
    {
        private readonly AppDbcontext _context;
        public PaymentDTo(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<PaymentStatistic> Payment()
        {
            return  new PaymentStatistic
            {
              TotalPayments=await _context.payments.CountAsync(),
              TotalAmount=await _context.payments.Where(a=>a.status== "Successful").SumAsync(a=>a.Amount),
              SuccessfulPayments=await _context.payments.CountAsync(a=>a.status== "Successful"),
              FailedPayments=await  _context.payments.CountAsync(a=>a.status== "Failed")
            };
        }
    }
}
