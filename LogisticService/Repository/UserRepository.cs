using LogisticService.Models;

namespace LogisticService.Repository
{
    public class UserRepository : IRepository<User, UserRequest>
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _dataContext.Users.Remove(user);
            _dataContext.SaveChanges();
        }

        public User Get(int id)
        {
            return _dataContext.Users.FirstOrDefault(x => x.UserId == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _dataContext.Users;
        }

        public void Update(User user)
        {
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();
        }

        public User Find(UserRequest userRequest)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Username == userRequest.UserLogin && x.Password == userRequest.Password);
        }
    }
}
