using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.BusinessLogic.Services.Contracts;
using Shop.Models.DatabaseModels;
using Shop.Models;
using Shop.Common.Models;

namespace Shop.BusinessLogic.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public SaleService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SaleModel> GetAllSales()
        {
            return _mapper.Map<List<Sale>, List<SaleModel>>(_context.Sales.AsNoTracking().ToList());
        }


        public SaleModel GetSale(int id)
        {
            if (!SaleExists(id))
            {
                throw new ArgumentException($"Sale with id:{id} doesn't exists.");
            }

            var sale = _context.Sales.FirstOrDefault(s => s.Id == id);

            if (sale is null)
            {
                throw new ArgumentException("Sale was not found");
            }

            return _mapper.Map<Sale, SaleModel>(sale);
        }

        public void Create(SaleModel sale)
        {
            if (!UserExists(sale.UserId))
            {
                throw new ArgumentException("User doesn't exists.");
            }

            if (!ProductExists(sale.ProductId))
            {
                throw new ArgumentException("Product doesn't exists.");
            }

            var dbSale = _mapper.Map<SaleModel, Sale>(sale);
            
            _context.Sales.Add(dbSale);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Sales.Remove(_mapper.Map<SaleModel, Sale>(GetSale(id)));
            _context.SaveChanges();
        }

        public void Update(int id, SaleModel sale)
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
            dbSale = _mapper.Map<SaleModel, Sale>(sale);
            
            _context.SaveChanges();
        }

        private bool SaleExists(int id) => _context.Sales.Any(s => s.Id == id);
        private bool UserExists(int userId) => _context.Users.Any(u => u.Id == userId);
        private bool ProductExists(int productId) => _context.Products.Any(p => p.Id == productId);
    }
}
