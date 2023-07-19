using Application.Interface;
using Application.ViewModel.UserViewModel;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class UserController : MainController
    {
        private readonly IUserService _userService;
        private readonly IClaimService _claimService;

        public UserController(IUserService userService, IClaimService claimService)
        {
            _userService = userService;
            _claimService = claimService;
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
    }
}
