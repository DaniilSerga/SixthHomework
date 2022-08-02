using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.BusinessLogic.Services.Contracts;
using Shop.Models.DatabaseModels;
using Shop.Models;
using Shop.Common.Models;

namespace Shop.BusinessLogic.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<UserModel> GetAllUsers()
        {
            var users = _context.Users.AsNoTracking().ToList();

            return _mapper.Map<List<User>, List<UserModel>>(users);
        }

        public UserModel GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user is null)
            {
                throw new ArgumentException($"No user with id: {id} was found.", nameof(id));
            }

            return _mapper.Map<User, UserModel>(user);
        }

        public void Create(UserModel userModel)
        {
            if (userModel is null)
            {
                throw new ArgumentNullException(nameof(userModel), "User was null.");
            }

            var user = _mapper.Map<UserModel, User>(userModel);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_mapper.Map<UserModel, User>(GetUser(id)));
            _context.SaveChanges();
        }

        public void Update(int id, UserModel userModel)
        {
            if (userModel is null)
            {
                throw new ArgumentNullException(nameof(userModel), "User was null.");
            }

            var dbUser = _context.Users.FirstOrDefault(u => u.Id == id);

            if (dbUser is null)
            {
                throw new ArgumentException($"User with id: {id} doesn't exists.");
            }
            dbUser = _mapper.Map<UserModel, User>(userModel);

            _context.SaveChanges();
        }
    }
}
