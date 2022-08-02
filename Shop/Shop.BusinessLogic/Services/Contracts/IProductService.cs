using Shop.Models.DatabaseModels;

namespace Shop.BusinessLogic.Services.Contracts
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        void Create(Product product);
        void Delete(int id);
        void Update(int id, Product product);
    }
}
