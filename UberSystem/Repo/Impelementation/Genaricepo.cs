using Microsoft.EntityFrameworkCore;
using UberSystem.Data;
using UberSystem.Repo.Interface;

namespace UberSystem.Repo.Impelementation
{
    public class Genaricepo<T> : IgenaricRepo<T> where T : class
    {
        private readonly AppDbcontext _context;
        public DbSet<T> db;
        public Genaricepo(AppDbcontext appDbcontext)
        {
            _context = appDbcontext;
            db = _context.Set<T>();
        }
        public async Task CreateAsync(T enet)
        {
           await db.AddAsync(enet);
        }

        public void Delete(int id)
        {
            var x = db.Find(id);
            if (x !=null)
            {
                db.Remove(x);
            }
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await db.ToListAsync();
        }

        public async Task<T> GetByid(int id)
        {
            return await db.FindAsync(id);
        }

        public void Update(T en)
        {
            db.Update(en);
        }
    }
}
