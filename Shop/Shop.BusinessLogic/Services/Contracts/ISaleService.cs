using Shop.Models.DatabaseModels;

namespace Shop.BusinessLogic.Services.Contracts
{
    public interface ISaleService
    {
        List<Sale> GetAllSales();
        Sale GetSale(int id);
        void Create(int userId, int productId);
        void Delete(int id);
        void Update(int id, Sale sale);
    }
}
