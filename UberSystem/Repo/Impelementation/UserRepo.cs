using Microsoft.EntityFrameworkCore;
using UberSystem.Data;
using UberSystem.Model;
using UberSystem.Repo.Interface;

namespace UberSystem.Repo.Impelementation
{
    public class UserRepo : Genaricepo<User>, IuserRepo
    {
        private readonly AppDbcontext _Context;
        public UserRepo(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _Context = appDbcontext;
        }

        public async Task<User> GetEmail(string Email)
        {
            return await _Context.users.SingleOrDefaultAsync(a => a.Email == Email);
        }

        public async Task<User> SearchByName(string Name)
        {
            return await _Context.users.Where(a => a.FullName.Contains(Name)).FirstOrDefaultAsync();
        }
    }
}
