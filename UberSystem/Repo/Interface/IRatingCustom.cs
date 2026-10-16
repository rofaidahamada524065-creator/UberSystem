using UberSystem.Model;

namespace UberSystem.Repo.Interface
{
    public interface IRatingCustom:IgenaricRepo<Rating>
    {
        Task<ICollection<Rating>> TopDrivers();
    }
}
