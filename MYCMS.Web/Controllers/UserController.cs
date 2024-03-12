using Microsoft.AspNetCore.Mvc;
using MYCMS.Core.Constants;
using MYCMS.Core.Dtos;
using MYCMS.Core.Dtos.Helpers;
using MYCMS.Infrastructure.Services.Users;

namespace MYCMS.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var result =await _userService.GetAll(pagination, query);
            return Json(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _userService.Create(userDto);
                return Ok(MyResults.AddSuccessResult());
            }
            return View(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user =await _userService.Get(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateUserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _userService.Update(userDto);
                return Ok(MyResults.EditSuccessResult());
            }
            return View(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.Delete(id);
            return Ok(MyResults.DeleteSuccessResult());

        }


    }
}
