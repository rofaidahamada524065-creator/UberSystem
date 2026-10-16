using UberSystem.Model;

namespace UberSystem.Repo.Interface
{
    public interface IuserRepo:IgenaricRepo<User>
    {
        Task<User> GetEmail(string Email);
        Task<User> SearchByName(string Name);
    }
}
