namespace LogisticService.Models
{
    public class User
    {

        public User() { }

        public User(string name, 
            string surname, 
            int age, 
           string username,
           string password, 
           UserRole role, 
           DateTime createdAt = default,
           Guid salt = default)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Username = username;
            Password = password;
            Role = UserRole.User;
            CreatedAt = DateTime.Now;
            Salt = Guid.NewGuid();
        }

        public User(int id,
            string name,
            string surname,
            int age,
            string username,
            string password, 
            UserRole role, 
            DateTime createdAt,
            Guid salt)
            : this(name, surname, age, username, password, role, createdAt, salt)
        {
            UserId = id;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid Salt { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Order> Orders { get; set; }
    }

    public enum UserRole
    {
        User,
        Admin,
        SuperAdmin
    }
}
