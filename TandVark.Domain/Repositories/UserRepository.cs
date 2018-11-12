using TandVark.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TandVark.Data.Data1;

namespace TandVark.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TandVerkContext _tandVardContext;

        public UserRepository(TandVerkContext tandVardContext)
        {
            _tandVardContext = tandVardContext;
        }

        public async Task<TblUser> GetUserAsync(string _userName)
        {
            var value = await _tandVardContext.TblUsers.Include(e => e.FldUserType).
                FirstOrDefaultAsync(table => table.FldAccountName.Equals(_userName));
            return value;
        }
    }

    
}


