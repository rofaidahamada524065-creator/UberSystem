using UberSystem.Data;
using UberSystem.Model;
using UberSystem.Repo.Interface;

namespace UberSystem.Repo.Impelementation
{
    public class UnitOfWork : IunitOfWork
    {
        private readonly AppDbcontext _contexxt;
        public UnitOfWork(AppDbcontext appDbcontext,IuserRepo iuserRepo,IgenaricRepo<Vehicle> igenaricRepo,IRideCustom rideCustom,IpaymentDTo ipaymentDTo,IRatingCustom ratingCustom)
        {
            _contexxt = appDbcontext;
            user = iuserRepo;
            vehicle = igenaricRepo;
            ride = rideCustom;
            payment = ipaymentDTo;
            rating = ratingCustom;
        }
        public IuserRepo user { get; }

        public IgenaricRepo<Vehicle> vehicle { get; }

        public IRideCustom ride { get; }

        public IpaymentDTo payment { get; }

        public IRatingCustom rating { get; }

        public async Task<int> SavechangeAsync()
        {
            return await _contexxt.SaveChangesAsync();
        }
    }
}
