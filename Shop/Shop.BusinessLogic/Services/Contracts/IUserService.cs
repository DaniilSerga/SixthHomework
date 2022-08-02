using Shop.Models.DatabaseModels;

namespace Shop.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        void Create(User user);
        void Delete(int id);
        void Update(int id, User user);
    }
}
