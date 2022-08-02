using Microsoft.EntityFrameworkCore;
using Shop.BusinessLogic.Services.Contracts;
using Shop.Models.DatabaseModels;
using Shop.Models;

namespace Shop.BusinessLogic.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly ApplicationContext _context;

        public SaleService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Sale> GetAllSales() => _context.Sales.AsNoTracking().ToList();

        public Sale GetSale(int id)
        {
            if (!SaleExists(id))
            {
                throw new ArgumentException($"Sale with id:{id} doesn't exists.");
            }

            return _context.Sales.FirstOrDefault(s => s.Id == id);
        }

        public void Create(int userId, int productId)
        {
            if (!UserExists(userId))
            {
                throw new ArgumentException("User doesn't exists.");
            }

            if (!ProductExists(productId))
            {
                throw new ArgumentException("Product doesn't exists.");
            }

            _context.Sales.Add(new Sale { ProductId = productId, UserId = userId });
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Sales.Remove(GetSale(id));
            _context.SaveChanges();
        }

        public void Update(int id, Sale sale)
        {
            if (!SaleExists(id))
            {
                throw new ArgumentException($"Sale with id:{id} doesn't exists.");
            }

            if (sale is null)
            {
                throw new ArgumentNullException(nameof(sale), "Parameter is null");
            }

            var dbSale = _context.Sales.FirstOrDefault(s => s.Id == id);
            dbSale = sale;
            
            _context.SaveChanges();
        }

        private bool SaleExists(int id) => _context.Sales.Any(s => s.Id == id);
        private bool UserExists(int userId) => _context.Users.Any(u => u.Id == userId);
        private bool ProductExists(int productId) => _context.Products.Any(p => p.Id == productId);
    }
}
