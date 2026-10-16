using UberSystem.Model;

namespace UberSystem.Repo.Interface
{
    public interface IunitOfWork
    {
        IuserRepo user { get; }
        IgenaricRepo<Vehicle> vehicle { get; }
        IpaymentDTo payment { get; }
        IRatingCustom rating { get; }

        IRideCustom ride { get; }
        Task<int> SavechangeAsync();
    }
}
