using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;

namespace ServicesAndInterfacesLibary.Services
{
    public class UserService : IUserService
    {
        private readonly AuctionDbContext _context;

        public UserService(AuctionDbContext context)
        {
            _context = context;
        }

        public int Create(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();

            return user.UserID;
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int userId)
        {
            var user = _context.User.Find(userId);

            if (user == null)
            {
                throw new ArgumentException($"User with ID '{userId}' not found.");
            }

            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            return _context.User.Find(userId);
        }

        public User GetUserByEmail(string email)
        {
            return _context.User.SingleOrDefault(u => u.Email == email);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.User.ToList();
        }

        public User Authenticate(string email, string password)
        {
            return _context.User.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
