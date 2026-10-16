using Microsoft.EntityFrameworkCore;
using UberSystem.Data;
using UberSystem.Model;
using UberSystem.Repo.Interface;

namespace UberSystem.Repo.Impelementation
{
    public class RatingCustom : Genaricepo<Rating>, IRatingCustom
    {
        private readonly AppDbcontext _context;
        public RatingCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<ICollection<Rating>> TopDrivers()
        {
            return await _context.ratings.Include(a=>a.ride).ThenInclude(a=>a.Driver).OrderByDescending(a => a.Score).ToListAsync();
        }
    }
}
