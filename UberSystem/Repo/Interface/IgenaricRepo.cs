namespace UberSystem.Repo.Interface
{
    public interface IgenaricRepo<T> where T:class
    {
        void Delete(int id);
        void Update(T en);
        Task CreateAsync(T enet);
        Task<T> GetByid(int id);
        Task<ICollection<T>> GetAll();
    }
}
