namespace TandVark.Domain.Models
{
    public class UserViewModel 
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string UserType { get; set; }

        public UserViewModel(string userName, string passWord)
        {
            UserName = userName;
            PassWord = passWord;
        }
        
        
    }
}
