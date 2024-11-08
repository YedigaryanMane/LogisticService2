using LogisticService.Models;

namespace LogisticService.UserService
{
    public abstract class Menu
    {
        public DataContext _dataContext { get; set; }

        public Menu() { }

        public Menu(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public abstract void Register(User user);
        public abstract string Login(string username, string password);
        public abstract string ComputeSha256Hash(string rawData);
    }
}
