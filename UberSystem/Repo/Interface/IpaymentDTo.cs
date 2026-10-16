using UberSystem.DTOs.payments;
using UberSystem.Model;

namespace UberSystem.Repo.Interface
{
    public interface IpaymentDTo:IgenaricRepo<Payment>
    {
        Task <PaymentStatistic> Payment();
    }
}
