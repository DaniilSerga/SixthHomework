using Microsoft.AspNetCore.Mvc;
using Shop.BusinessLogic.Services.Contracts;
using Shop.Common.Models;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> GetProducts()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet]
        public ActionResult GetProduct(int id)
        {
            _productService.GetProduct(id);
            return Ok();
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductModel product)
        {
            _productService.Create(product);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateProduct(int id, ProductModel product)
        {
            _productService.Update(id, product);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            _productService.Delete(id);

            return Ok();
        }
    }
}
