using TandVark.Domain.Models.Interfaces;

namespace TandVark.Domain.Models
{
    public class User : IUser
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string UserType { get; set; }

        public User(string _userName, string _passWord)
        {
            UserName = _userName;
            PassWord = _passWord;
        }
        public User() { }
        
    }
}
