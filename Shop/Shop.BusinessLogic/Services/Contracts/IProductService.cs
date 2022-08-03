using Shop.Models.DatabaseModels;
using Shop.Common.Models;

namespace Shop.BusinessLogic.Services.Contracts
{
    public interface IProductService
    {
        ProductModel GetProduct(int id);
        void Create(ProductModel product);
        void Delete(int id);
        void Update(int id, ProductModel product);
    }
}
