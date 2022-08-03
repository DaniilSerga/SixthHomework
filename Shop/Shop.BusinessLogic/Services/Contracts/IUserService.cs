using Shop.Common.Models;

namespace Shop.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        UserModel GetUser(int id);
        void Create(UserModel user);
        void Delete(int id);
        void Update(int id, UserModel user);
    }
}
