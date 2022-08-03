using Microsoft.AspNetCore.Mvc;
using Shop.BusinessLogic.Services.Contracts;
using Shop.Common.Models;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult GetUser(int id)
        {
            _userService.GetUser(id);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

        [HttpPost]
        public ActionResult CreateUser(UserModel user)
        {
            _userService.Create(user);
            return Ok();
        }
    }
}
