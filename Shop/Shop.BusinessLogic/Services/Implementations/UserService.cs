using Microsoft.EntityFrameworkCore;
using Shop.BusinessLogic.Services.Contracts;
using Shop.Models.DatabaseModels;
using Shop.Models;

namespace Shop.BusinessLogic.Services.Implementations
{
    internal class UserService : IUserService
    {
        public readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers() => _context.Users.AsNoTracking().ToList();

        public User GetUser(int id)
        {
            if (!UserExists(id))
            {
                throw new ArgumentException("No matches found.", nameof(id));
            }

            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Create(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user), "User was null.");
            }

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(GetUser(id));
            _context.SaveChanges();
        }

        public void Update(int id, User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user), "User was null.");
            }

            if (!UserExists(id))
            {
                throw new ArgumentNullException(nameof(id), $"User with id: {id} doesn't exist.");
            }

            var dbUser = _context.Users.FirstOrDefault(u => u.Id == id);
            dbUser = user;

            _context.SaveChanges();
        }

        public bool UserExists(int id) => _context.Users.FirstOrDefault(u => u.Id == id) != null;
    }
}
