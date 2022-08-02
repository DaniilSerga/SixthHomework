using Microsoft.EntityFrameworkCore;
using Shop.BusinessLogic.Services.Contracts;
using Shop.Models.DatabaseModels;
using Shop.Models;

namespace Shop.BusinessLogic.Services.Implementations
{
    public class ProductService : IProductService
    {
        private ApplicationContext _context;

        public ProductService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts() => _context.Products.AsNoTracking().ToList();

        public Product GetProduct(int id)
        {
            if (!ProductExists(id))
            {
                throw new ArgumentException($"Product with id: {id} doesn't exist.");
            }

            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Create(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product), "Parameter was null.");
            }

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Products.Remove(GetProduct(id));
            _context.SaveChanges();
        }

        public void Update(int id, Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product), "Parameter was null.");
            }

            if (!ProductExists(id))
            {
                throw new ArgumentException($"Product with id: {id} doesn't exist.");
            }

            var dbProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            dbProduct = product;

            _context.SaveChanges();
        }

        private bool ProductExists(int id) => _context.Products.Any(p => p.Id == id);
    }
}
