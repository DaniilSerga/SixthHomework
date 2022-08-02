using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.BusinessLogic.Services.Contracts;
using Shop.Common.Models;

namespace Shop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> GetUsers() => Ok(_userService.GetAllUsers());

        [HttpGet]
        public ActionResult GetUser(int id) => Ok(_userService.GetUser(id));

        [HttpPost]
        public ActionResult Create(UserModel user) => Ok(_userService.Create(user));
    }
}
