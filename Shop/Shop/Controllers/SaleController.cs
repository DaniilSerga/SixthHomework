using Shop.Common.Models;
using Shop.BusinessLogic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public ActionResult GetSale(int id)
        {
            return Ok(_saleService.GetSale(id));
        }

        [HttpPost]
        public ActionResult CreateSale(SaleModel saleModel)
        {
            _saleService.Create(saleModel);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteSale(int id)
        {
            _saleService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateSale(int id, SaleModel sale)
        {
            _saleService.Update(id, sale);
            return Ok();
        }
    }
}
