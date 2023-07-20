using Application.Interface;
using Application.ViewModel.UserViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class UserController : MainController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(string email,string password)
        {
         bool isRegister= await  _userService.RegisterAsync(email, password);
            if(!isRegister)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(string email,string password)
        {
            var token = await _userService.LoginAsync(email, password);
            if (token == null)
            {
                return BadRequest("Login failed");
            }
            return Ok(token);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateDTO updateObject)
        {
            var result = await _userService.UpdateUserInformation(updateObject);
            if (result) return Ok();
            else return BadRequest("Something went wrong");
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> ChangePassword(string oldPassword,string newPassword)
        {
            var result= await _userService.ChangePassword(oldPassword,newPassword);
            if (result) return Ok();
            else return BadRequest();
        }
    }
}
