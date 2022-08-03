using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.BusinessLogic.Services.Contracts;
using Shop.Models.DatabaseModels;
using Shop.Common.Models;
using Shop.Models;

namespace Shop.BusinessLogic.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, ApplicationContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProductModel GetProduct(int id)
        {
            if (!ProductExists(id))
            {
                throw new ArgumentException($"Product with id: {id} doesn't exist.");
            }

            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                throw new ArgumentException("Product was not found.");
            }

            return _mapper.Map<Product, ProductModel>(product);
        }

        public void Create(ProductModel product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product), "Parameter was null.");
            }

            var dbProduct = _mapper.Map<ProductModel, Product>(product);

            _context.Products.Add(dbProduct);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Products.Remove(_mapper.Map<ProductModel, Product>(GetProduct(id)));
            _context.SaveChanges();
        }

        public void Update(int id, ProductModel product)
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
            dbProduct = _mapper.Map<ProductModel, Product>(product);

            _context.SaveChanges();
        }

        private bool ProductExists(int id) => _context.Products.Any(p => p.Id == id);
    }
}
