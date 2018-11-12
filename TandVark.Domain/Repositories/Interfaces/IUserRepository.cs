using System.Threading.Tasks;
using TandVark.Data.Data1;

namespace TandVark.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        
        Task<TblUser> GetUserAsync(string _userName);
    }
}