using System.Threading.Tasks;
using TandVark.Domain.DTO;
using TandVark.Domain.Models;

namespace TandVark.Domain.Services.Interfaces
{
    public interface IUserServices
    {
        Task<UserDTO> GetUserForAuthenticationAsync(User _User);
    }
}