namespace LogisticService.Models
{
    public class UserRequest
    {
        public UserRequest(string userLogin, string password)
        {
            UserLogin = userLogin;
            Password = password;
        }

        public string UserLogin { get; set; }
        public string Password { get; set; }
    }
}
