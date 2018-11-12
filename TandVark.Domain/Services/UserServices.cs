using System;
using System.Threading.Tasks;
using TandVark.Domain.DTO;
using TandVark.Domain.Models;
using TandVark.Domain.Repositories.Interfaces;
using TandVark.Domain.Services.Interfaces;

namespace TandVark.Domain.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _iUserRepository;

        public UserServices(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public async Task<UserDTO> GetUserForAuthenticationAsync(User _User)
        {
            var value = await _iUserRepository.GetUserAsync(_User.UserName);

            if (value == null)
            {
                throw new NullReferenceException("User does not exist");
            }
            else if (_User.UserName == value.FldAccountName && _User.PassWord == value.FldPassword)
            {
                var User = new UserDTO { UserName = value.FldAccountName, UserType = value.FldUserType.FldEmployeeTypeName };
                return User;
            }
            throw new ArgumentException("User credentials missmatch");
            
        }

    }
}
